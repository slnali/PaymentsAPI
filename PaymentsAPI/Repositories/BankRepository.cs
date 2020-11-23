using PaymentsAPI.Models;
using System;
using System.Threading.Tasks;

namespace PaymentsAPI.Repositories
{
    /// <summary>
    /// The "Production" implementation of the IBankRepository interface
    /// </summary>
    /// <seealso cref="PaymentsAPI.Repositories.IBankRepository" />
    public class BankRepository : IBankRepository
    {
        /// <summary>
        /// Processes the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<PaymentProcessResult> ProcessPayment(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
