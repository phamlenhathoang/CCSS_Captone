using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using System.Threading.Tasks;

namespace CCSS_Service
{
    public interface ITicketService
    {
        Task<Ticket> GetTicketAsync(string id);
        //Task<bool> AddTicketAsync(Ticket ticket);
        //Task<bool> UpdateTicketAsync(Ticket ticket);
        //Task<bool> DeleteTicketAsync(string ticketId);
    }

    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Ticket> GetTicketAsync(string id)
        {
            return await _ticketRepository.GetTicket(id);
        }

        //public async Task<bool> AddTicketAsync(Ticket ticket)
        //{
        //    return await _ticketRepository.AddTicket(ticket);
        //}

        //public async Task<bool> UpdateTicketAsync(Ticket ticket)
        //{
        //    return await _ticketRepository.UpdateTicket(ticket);
        //}

        //public async Task<bool> DeleteTicketAsync(string ticketId)
        //{
        //    var ticket = await _ticketRepository.GetTicket(ticketId);
        //    if (ticket == null) return false;
        //    return await _ticketRepository.DeleteTicket(ticket);
        //}
    }
}
