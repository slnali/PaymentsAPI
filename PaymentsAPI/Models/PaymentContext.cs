using Microsoft.EntityFrameworkCore;

namespace PaymentsAPI.Models
{
    /// <summary>
    /// Class for managing Payments DB Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class PaymentContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public PaymentContext(DbContextOptions<PaymentContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the payments table. 
        /// </summary>
        /// <value>
        /// The payments.
        /// </value>
        public DbSet<Payment> Payments { get; set; }
    }
}
