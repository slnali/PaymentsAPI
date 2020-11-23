using PaymentsAPI.Models;
using PaymentsAPI.Utilities;
using System;
using System.Threading.Tasks;

namespace PaymentsAPI.Repositories
{
    /// <summary>
    /// Class to inject for mocking bank repository in uni tests
    /// </summary>
    /// <seealso cref="PaymentsAPI.Repositories.IBankRepository" />
    public class MockBankRepository : IBankRepository
    {

        /// <summary>
        /// Gets or sets a value indicating whethe ProcessPaymentSuccess [success/true or failure/false].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [success or failure]; otherwise, <c>false</c>.
        /// </value>
        public bool ProcessPaymentSuccess { get; set; }

        public MockBankRepository(bool processPaymentSuccess = true)
        {
            ProcessPaymentSuccess = processPaymentSuccess;
        }

        /// <summary>
        /// Processes the payment through the "Mock" bank.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <returns></returns>
        public async Task<PaymentProcessResult> ProcessPayment(Payment payment)
        {
            string bankProcessedId = Guid.NewGuid().ToString();
            payment.BankProcessedId = bankProcessedId;
            if (this.ProcessPaymentSuccess)
            {
                payment.PaymentStatus = (int)PaymentStatus.Success;
            }
            else
            {
                payment.PaymentStatus = (int)PaymentStatus.Failure;
            }
            return await Task.FromResult(new PaymentProcessResult { PaymentIdentifier = bankProcessedId, PaymentStatus = (PaymentStatus)payment.PaymentStatus, Payment = payment });
        }
    }
}
