using PaymentsAPI.Models;
using PaymentsAPI.Repositories;
using PaymentsAPI.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsAPI.Services
{
    /// <summary>
    /// Payments service implementing service pattern which contacts various repositories for processing/storng/getting
    /// </summary>
    /// <seealso cref="PaymentsAPI.Services.IPaymentsService" />
    public class PaymentsService : IPaymentsService
    {
        private readonly IBankRepository bankRepository;
        private readonly IPaymentRepository paymentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsService"/> class.
        /// </summary>
        /// <param name="bankRepository">The bank repository.</param>
        /// <param name="paymentRepository">The payment repository.</param>
        public PaymentsService(IBankRepository bankRepository, IPaymentRepository paymentRepository)
        {
            this.bankRepository = bankRepository;
            this.paymentRepository = paymentRepository;
        }


        /// <summary>
        /// Creates a payment by first processing payment through the acquiring bank and then storing the 
        /// output result for the payment in the payments database. 
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <returns></returns>
        public async Task<Payment> CreatePayment(Payment payment)
        {
            //get bank to process payment
            PaymentProcessResult bankProcessedResult = await bankRepository.ProcessPayment(payment);

            //we should store succesfull and failed payments in the database for auditing purposes
            Payment paymentResult = await paymentRepository.AddPaymentToDatabase(bankProcessedResult.Payment);

            //if successful bank process store all details for payment in database
            if (bankProcessedResult.PaymentStatus == PaymentStatus.Success)
            {
                //can manipulate result here if we want before sending back to the controller
                return paymentResult;
            }
            //if we could not process the payment we return null
            return null;
        }

        /// <summary>
        /// Gets the payment based on the Id of the payment passed in.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<PaymentDTO> GetPayment(long id)
        {
            Payment payment = await paymentRepository.GetPaymentFromDatabase(id);
            if (payment is not null)
            {
                PaymentDTO paymentDto = new PaymentDTO
                {
                    CustomerContact = payment.CustomerEmail,
                    PaymentStatusCode = payment.PaymentStatus,
                    CardNumber = string.Concat(
                    payment.CardNumber.Substring(0, 4),
                    "".PadLeft(12, '*')
                    ),
                    CardExpiryDate = payment.CardExpiryDate,
                    Amount = payment.Amount
                };
                return paymentDto;
            }
            return null;

        }

        /// <summary>
        /// Gets a list of payments..
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Payment>> GetPaymentsList()
        {
            IEnumerable<Payment> payments = await paymentRepository.GetListOfPaymentsFromDatabase();
            //can manipulate payments here if we want before sending back to the controller
            return payments;
        }
    }
}
