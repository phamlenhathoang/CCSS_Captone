using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
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
        Task<string> TicketCheck(TicketCheckRequest request);
        Task<string> UpdateTicketAccount(string id, TicketAccountRequest request);
        Task<bool> DeleteTicketAccount(string id);
    }

    public class TicketAccountService : ITicketAccountService
    {
        private readonly ITicketAccountRepository _ticketAccountRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private const string Base62Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public TicketAccountService(ITicketAccountRepository ticketAccountRepository, ITicketRepository ticketRepository, IMapper mapper)
        {
           
            _mapper = mapper;
            _ticketAccountRepository = ticketAccountRepository;
            _ticketRepository = ticketRepository;
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
                if (ticket.Quantity < request.quantitypurchased)
                {
                    throw new Exception("Not enough tickets available");
                }

                // ✅ Cập nhật số lượng Ticket
                ticket.Quantity -= request.quantitypurchased;

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
        public async Task<string> TicketCheck(TicketCheckRequest request)
        {
            var existingTicketAccount = await _ticketAccountRepository.GetTicketAccountByTicketCode(request.TicketCode);
            if (existingTicketAccount == null)
            {
                return "Ticket not found";
            }
            else if (existingTicketAccount.quantitypurchased == 0)
            {
                return "Ticket has expired";
            }
            else if (existingTicketAccount.quantitypurchased<request.quantity)
            {
                return "exceed ticket capacity";
            }

            _mapper.Map(request, existingTicketAccount);
            existingTicketAccount.quantitypurchased -= request.quantity;
            await _ticketAccountRepository.UpdateTicketAccount(existingTicketAccount);
            return "Check Success";
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
