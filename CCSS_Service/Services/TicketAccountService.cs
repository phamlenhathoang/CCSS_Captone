using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface ITicketAccountService
    {
        Task<List<TicketAccountResponse>> GetAllTicketAccounts();
        Task<TicketAccountResponse> GetTicketAccount(string id);
        Task<string> AddTicketAccount(TicketAccountRequest request);
        Task<string> UpdateTicketAccount(string id, TicketAccountRequest request);
        Task<bool> DeleteTicketAccount(string id);
    }

    public class TicketAccountService : ITicketAccountService
    {
        private readonly ITicketAccountRepository _ticketAccountRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

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

        /// ✅ **Thêm mới TicketAccount**
        public async Task<string> AddTicketAccount(TicketAccountRequest request)
        {
            if (request == null)
            {
                return "Invalid request: TicketAccount is null";
            }

            try
            {
                // ✅ Lấy thông tin Ticket tương ứng
                var ticket = await _ticketRepository.GetTicket(request.TicketId);
                if (ticket == null)
                {
                    return "Ticket not found";
                }

                // ✅ Kiểm tra số lượng còn đủ không
                if (ticket.Quantity < request.quantitypurchased)
                {
                    return "Not enough tickets available";
                }

                // ✅ Cập nhật số lượng Ticket
                ticket.Quantity -= request.quantitypurchased;

                // ✅ Tạo mới TicketAccount
                var newTicketAccount = _mapper.Map<TicketAccount>(request);
                newTicketAccount.TicketAccountId = Guid.NewGuid().ToString();

                // ✅ Lưu TicketAccount vào DB
                await _ticketAccountRepository.AddTicketAccount(newTicketAccount);

                // ✅ Lưu cập nhật số lượng Ticket vào DB
                await _ticketRepository.UpdateTicket(ticket);

                return "Add Success";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
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
    }
}
