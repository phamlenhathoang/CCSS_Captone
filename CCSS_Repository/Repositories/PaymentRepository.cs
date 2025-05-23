using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Repository.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPayment(string paymentId);
        Task<Payment> GetPaymentByTransactionId(string TransactionId);
        Task<List<Payment>> GetAll();
        Task<bool> AddPayment(Payment payment);
        Task<bool> UpdatePayment(Payment payment);
        Task<bool> DeletePayment(Payment payment);
        Task<List<Payment>> GetAllPayment();
        Task<List<Payment>> GetAllPaymentByContractId(string contracId);
        Task<List<Payment>> GetAllPaymentByAccountIdAndPurpose(string accountId,PaymentPurpose purpose);
    }

    public class PaymentRepository : IPaymentRepository
    {
        private readonly CCSSDbContext _context;
        public PaymentRepository(CCSSDbContext cCSSDbContext)
        {
            _context = cCSSDbContext;
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _context.Payments.Where(p=> p.Status == PaymentStatus.Complete).ToListAsync();
        }

        public async Task<Payment> GetPayment(string paymentId)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId.Equals(paymentId));
        }
        public async Task<Payment> GetPaymentByTransactionId(string Id)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.TransactionId.Equals(Id));
        }

        public async Task<bool> AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePayment(Payment payment)
        {
            _context.Payments.Remove(payment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Payment>> GetAllPayment()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<List<Payment>> GetAllPaymentByContractId(string contracId)
        {
            return await _context.Payments.Where(c => c.ContractId.Equals(contracId)).ToListAsync();
        }

        public async Task<List<Payment>> GetAllPaymentByAccountIdAndPurpose(string accountId, PaymentPurpose purpose)
        {
            if(purpose == PaymentPurpose.Order)
            {
                return await _context.Payments.Include(sc => sc.Order).Where(o => o.Order.AccountId.Equals(accountId)).ToListAsync();
            }else if(purpose == PaymentPurpose.BuyTicket)
            {
                return await _context.Payments.Include(sc => sc.TicketAccount).Where(t => t.TicketAccount.AccountId.Equals(accountId)).ToListAsync();
            }
            else
            {
                return await _context.Payments.Include(sc => sc.Contract).Where(c => c.Contract.CreateBy.Equals(accountId)).ToListAsync();
            }
        }

    }
}