using Microsoft.AspNetCore.Mvc;
using PaymentsAPI.Models;
using PaymentsAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsAPI.Controllers
{
    #region PaymentsController
    /// <summary>
    /// Implemens Payment controller gateway for receiving api requests from Merchants
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService paymentsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="paymentsService">The payments service.</param>
        public PaymentsController(PaymentContext context, IPaymentsService paymentsService)
        {
            this.paymentsService = paymentsService;
        }
        #endregion

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetListOfPaymentDetails()
        {
            IEnumerable<Payment> payments = await paymentsService.GetPaymentsList();
            return Ok(payments);
        }

        /// <summary>
        /// Gets the payment details as a async operation. 
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDTO>> GetPaymentDetails(long id)
        {
            PaymentDTO payment = await paymentsService.GetPayment(id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        #region snippet_Create
        /// <summary>
        /// Posts the payment as a async operation.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            Payment paymentResult = await paymentsService.CreatePayment(payment);

            if (paymentResult is null)
            {
                return BadRequest();
            }

            //Not good in practice just to show differences between created payment response and get payment response
            return CreatedAtAction(nameof(GetPaymentDetails), new { id = paymentResult.Id }, paymentResult);
        }
        #endregion
    }
}