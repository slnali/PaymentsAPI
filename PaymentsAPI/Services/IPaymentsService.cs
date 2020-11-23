using PaymentsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsAPI.Services
{
    /// <summary>
    /// Interface for defining behaviour of Payments service
    /// </summary>
    public interface IPaymentsService
    {
        /// <summary>
        /// Creates the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <returns></returns>
        Task<Payment> CreatePayment(Payment payment);

        /// <summary>
        /// Gets the payment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<PaymentDTO> GetPayment(long id);

        /// <summary>
        /// Gets the payments list.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Payment>> GetPaymentsList();

    }
}
