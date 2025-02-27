using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Repository.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPayment(string paymentId);
        Task<List<Payment>> GetAll();
        Task<bool> AddPayment(Payment payment);
        Task<bool> UpdatePayment(Payment payment);
        Task<bool> DeletePayment(Payment payment);
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
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetPayment(string paymentId)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId.Equals(paymentId));
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
    }
}