using System;

namespace PaymentsAPI.Models
{
    public class PaymentDTO
    {
        /// <summary>
        /// Gets or sets the name of the customer. 
        /// Better to set as details of 
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        public string CustomerContact { get; set; }

        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>
        /// The payment identifier.
        /// </value>
        public int PaymentStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>
        /// The card number.
        /// </value>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        /// <value>
        /// The expiry date.
        /// </value>
        public DateTime CardExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public float Amount { get; set; }
    }
}
