using PaymentsAPI.Models;
using System.Threading.Tasks;

namespace PaymentsAPI.Repositories
{
    /// <summary>
    /// Interface for defining behaviour of Bank repository
    /// Currently allows us to create a mock which implements the same and allows us to inject in unit tests
    /// Also allows us to create a "production" implementation where actual bank payments are processed
    /// </summary>
    public interface IBankRepository
    {
        /// <summary>
        /// Processes the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <returns></returns>
        Task<PaymentProcessResult> ProcessPayment(Payment payment);
    }
}
