using PaymentsAPI.Models;
using PaymentsAPI.Utilities;

namespace PaymentsAPI.Repositories
{
    /// <summary>
    /// Object to encapsulate output of bank processing
    /// </summary>
    public class PaymentProcessResult
    {
        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>
        /// The payment status.
        /// </value>
        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>
        /// The payment identifier.
        /// </value>
        public string PaymentIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the payment.
        /// </summary>
        /// <value>
        /// The payment.
        /// </value>
        public Payment Payment { get; set; }
    }
}
