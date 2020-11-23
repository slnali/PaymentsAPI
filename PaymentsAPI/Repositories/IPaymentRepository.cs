using PaymentsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsAPI.Repositories
{
    /// <summary>
    /// Interface for defining behaviour of Payments repository
    /// </summary>
    public interface IPaymentRepository
    {
        /// <summary>
        /// Adds the payment to database.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <returns></returns>
        Task<Payment> AddPaymentToDatabase(Payment payment);

        /// <summary>
        /// Gets the payment from database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Payment> GetPaymentFromDatabase(long id);

        /// <summary>
        /// Gets the list of payments from database.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Payment>> GetListOfPaymentsFromDatabase();

    }
}
