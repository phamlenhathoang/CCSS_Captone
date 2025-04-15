using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface ITicketAccountService
    {
        Task<List<TicketAccountResponse>> GetAllTicketAccounts();
        Task<TicketAccountResponse> GetTicketAccount(string id);
        Task<List<TicketAccountResponse>> GetTicketAccountByAccountId(string id);
        Task<TicketAccountResponse> AddTicketAccount(TicketAccountRequest request);
        Task<TicketCheckResponse> TicketCheck(TicketCheckRequest request);
        Task<string> UpdateTicketAccount(string id, TicketAccountRequest request);
        Task<bool> DeleteTicketAccount(string id);
    }

    public class TicketAccountService : ITicketAccountService
    {
        private readonly ITicketAccountRepository _ticketAccountRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IEventRepository _eventrepository;

        private const string Base62Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public TicketAccountService(ITicketAccountRepository ticketAccountRepository, ITicketRepository ticketRepository, IMapper mapper, IAccountRepository accountRepository, IEventRepository eventrepository)
        {

            _mapper = mapper;
            _ticketAccountRepository = ticketAccountRepository;
            _ticketRepository = ticketRepository;
            _accountRepository = accountRepository;
            _eventrepository = eventrepository;
        }

        /// ✅ **Lấy danh sách tất cả TicketAccount**
        public async Task<List<TicketAccountResponse>> GetAllTicketAccounts()
        {
            var ticketAccounts = await _ticketAccountRepository.GetAllTicketAccounts();
            return _mapper.Map<List<TicketAccountResponse>>(ticketAccounts);
        }

        /// ✅ **Lấy TicketAccount theo ID**
        public async Task<TicketAccountResponse> GetTicketAccount(string id)
        {
            var ticketAccount = await _ticketAccountRepository.GetTicketAccount(id);
            return _mapper.Map<TicketAccountResponse>(ticketAccount);
        }
        public async Task<List<TicketAccountResponse>> GetTicketAccountByAccountId(string id)
        {
            var ticketAccounts = await _ticketAccountRepository.GetTicketAccountByAccountId(id);
            return _mapper.Map<List<TicketAccountResponse>>(ticketAccounts);
        }

        /// ✅ **Thêm mới TicketAccount**
        public async Task<TicketAccountResponse> AddTicketAccount(TicketAccountRequest request)
        {
            try
            {
                // ✅ Lấy thông tin Ticket tương ứng
                var ticket = await _ticketRepository.GetTicket(request.TicketId);
                if (ticket == null)
                {
                    throw new Exception("Ticket not found");
                }

                // ✅ Kiểm tra số lượng còn đủ không
                if (ticket.Quantity < request.Quantity)
                {
                    throw new Exception("Not enough tickets available");
                }

                // ✅ Cập nhật số lượng Ticket
                ticket.Quantity -= request.Quantity;

                // ✅ Tạo mới TicketAccount
                var newTicketAccount = _mapper.Map<TicketAccount>(request);
                newTicketAccount.TicketAccountId = Guid.NewGuid().ToString();

                // ✅ Tạo TicketCode từ TicketAccountId (6 ký tự)
                newTicketAccount.TicketCode = GenerateShortCode(newTicketAccount.TicketAccountId);

                // ✅ Lưu TicketAccount vào DB và kiểm tra kết quả
                bool isAdded = await _ticketAccountRepository.AddTicketAccount(newTicketAccount);
                if (!isAdded)
                {
                    throw new Exception("Failed to add TicketAccount");
                }

                // ✅ Lưu cập nhật số lượng Ticket vào DB
                await _ticketRepository.UpdateTicket(ticket);
                var response = _mapper.Map<TicketAccountResponse>(newTicketAccount);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }






        /// ✅ **Cập nhật TicketAccount**
        public async Task<string> UpdateTicketAccount(string id, TicketAccountRequest request)
        {
            var existingTicketAccount = await _ticketAccountRepository.GetTicketAccount(id);
            if (existingTicketAccount == null)
            {
                return "TicketAccount not found";
            }

            _mapper.Map(request, existingTicketAccount);
            await _ticketAccountRepository.UpdateTicketAccount(existingTicketAccount);
            return "Update Success";
        }

        /// ✅ **Xóa TicketAccount**
        public async Task<bool> DeleteTicketAccount(string id)
        {
            return await _ticketAccountRepository.DeleteTicketAccount(id);
        }
        public async Task<TicketCheckResponse> TicketCheck(TicketCheckRequest request)
        {
            var existingTicketAccount = await _ticketAccountRepository.GetTicketAccountByTicketCode(request.TicketCode);
            var requestEvent = await _eventrepository.GetEventByTicketId(existingTicketAccount.TicketId);
            var currentEvent = await _eventrepository.GetEventByEventId(request.eventId);

            if (existingTicketAccount == null || currentEvent.EventId != requestEvent.EventId)
            {
                return new TicketCheckResponse
                {
                    Notification = "Ticket not found"
                };
            }
            else if (existingTicketAccount.Quantity == 0)
            {
                return new TicketCheckResponse
                {
                    Notification = "Ticket has expired"
                };
            }
            else if (existingTicketAccount.Quantity < request.quantity)
            {
                return new TicketCheckResponse
                {
                    Notification = "exceed ticket capacity"
                };
            }
            var totalInitialTickets = existingTicketAccount.Quantity;
            //_mapper.Map(request, existingTicketAccount);
            existingTicketAccount.Quantity -= request.quantity;
             var update = await _ticketAccountRepository.UpdateTicketAccount(existingTicketAccount);
            if (!update)
            {
                throw new Exception("update ticket fail");
            }
            return new TicketCheckResponse
            {
                TotalInitialTickets = totalInitialTickets,
                TotalRemainingTickets = existingTicketAccount.Quantity,
                TicketCode=request.TicketCode,
                Notification = "Check Success"
            };
        }


        public static string GenerateShortCode(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                ulong number = BitConverter.ToUInt64(hashBytes, 0); // Lấy 8 byte đầu

                return ToBase62(number, 6); // Chuyển thành chuỗi 6 ký tự
            }
        }

        private static string ToBase62(ulong number, int length)
        {
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = Base62Chars[(int)(number % 62)];
                number /= 62;
            }
            return new string(result.Reverse().ToArray());
        }


    }
}
