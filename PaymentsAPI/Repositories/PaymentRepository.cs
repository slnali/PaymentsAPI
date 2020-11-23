using Microsoft.EntityFrameworkCore;
using PaymentsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsAPI.Repositories
{

    /// <summary>
    /// Repository for storing payments in database
    /// </summary>
    /// <seealso cref="PaymentsAPI.Repositories.IPaymentRepository" />
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRepository"/> class.
        /// </summary>
        /// <param name="paymentContext">The payment context.</param>
        public PaymentRepository(PaymentContext paymentContext)
        {
            _context = paymentContext;
        }

        /// <summary>
        /// Adds the payment to database.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <returns></returns>
        public async Task<Payment> AddPaymentToDatabase(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        /// <summary>
        /// Gets the list of payments from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Payment>> GetListOfPaymentsFromDatabase()
        {
            List<Payment> payments = await _context.Payments.ToListAsync();
            return payments;
        }

        /// <summary>
        /// Gets the payment from database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Payment> GetPaymentFromDatabase(long id)
        {
            Payment payment = await _context.Payments.FindAsync(id);
            return payment;
        }
    }
}
