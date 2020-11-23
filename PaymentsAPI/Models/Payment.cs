using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentsAPI.Models
{
    //POC: Card details class and user details should have nested classes here - improved
    /// <summary>
    /// Payment Model used to store data in database
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>
        /// The payment identifier.
        /// </value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the bank processed identifier.
        /// </summary>
        /// <value>
        /// The payment identifier.
        /// </value>
        public string BankProcessedId { get; set; }

        /// <summary>
        /// Gets or sets the payment status code.
        /// </summary>
        /// <value>
        /// The payment identifier.
        /// </value>
        public int PaymentStatus { get; set; }


        /// <summary>
        /// Gets or sets the name of the customer. 
        /// Better to set as details of 
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the email of the customer.
        /// Better to set as details of
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>
        /// The card number.
        /// </value>
        [Required]
        [StringLength(16, MinimumLength = 15)]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the expiry date of the card.
        /// </summary>
        /// <value>
        /// The expiry date.
        /// </value>
        [Required]
        public DateTime CardExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [Required]
        public float Amount { get; set; }

        /// <summary>
        /// Three letter ISO currency code
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the CVV.
        /// </summary>
        /// <value>
        /// The CVV.
        /// </value>
        [Required]
        [StringLength(4, MinimumLength = 3)]
        public string CVV { get; set; }
    }
}
