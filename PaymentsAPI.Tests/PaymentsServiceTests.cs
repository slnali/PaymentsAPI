using Microsoft.EntityFrameworkCore;
using PaymentsAPI.Models;
using PaymentsAPI.Repositories;
using PaymentsAPI.Services;
using System;
using Xunit;

namespace PaymentsAPI.Tests
{
    /// <summary>
    /// Test Payments service class.
    /// </summary>
    public class PaymentsServiceTests
    {
        PaymentsService paymentsService;
        readonly IBankRepository mockBankRepository;
        readonly IPaymentRepository paymentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsServiceTests"/> class.
        /// </summary>
        public PaymentsServiceTests()
        {
            DbContextOptions<PaymentContext> options = new DbContextOptionsBuilder<PaymentContext>()
                .UseInMemoryDatabase(databaseName: "PaymentsTest")
                .Options;
            PaymentContext context = new PaymentContext(options);

            context.Payments.Add(new Payment
            {
                Amount = 449.99F,
                BankProcessedId = "abc",
                CustomerEmail = "johndoe@aemail.com",
                CustomerName = "John Doe",
                PaymentStatus = 1,
                CardExpiryDate = new DateTime(2019, 12, 1),
                CardNumber = "123456789101112",
                Currency = "GBP",
                CVV = "333"
            });
            context.SaveChanges();
            mockBankRepository = new MockBankRepository();
            paymentRepository = new PaymentRepository(context);
            paymentsService = new PaymentsService(mockBankRepository, paymentRepository);
        }

        /// <summary>
        /// Gets the payment test succeeds when payment exists.
        /// </summary>
        [Fact]
        public async void GetPaymentTestSucceedsWhenPaymentExists()
        {
            PaymentDTO paymentDto = await paymentsService.GetPayment(1);
            Assert.Equal("johndoe@aemail.com", paymentDto.CustomerContact);
            Assert.Equal("449.99", paymentDto.Amount.ToString());
            Assert.Equal("1234************", paymentDto.CardNumber);
            Assert.Equal("1", paymentDto.PaymentStatusCode.ToString());
            Assert.Equal("01/12/2019 00:00:00", paymentDto.CardExpiryDate.ToString());
        }

        [Fact]
        public async void GetPaymentTestFailssWhenPaymentDoesNotExist()
        {
            PaymentDTO payment = await paymentsService.GetPayment(10);
            Assert.Null(payment);
        }

        /// <summary>
        /// Creates the payment test should return payment when bank succeeds to process payment.
        /// </summary>
        [Fact]
        public async void CreatePaymentTestShouldReturnPaymentWhenBankSucceedsToProcessPayment()
        {

            Payment paymentResult = await paymentsService.CreatePayment(new Payment
            {
                Amount = 49.99F,
                CustomerEmail = "alexwinchester@email.com",
                CustomerName = "Alex Winchester",
                CardExpiryDate = new DateTime(2019, 12, 1),
                CardNumber = "123456789101112",
                Currency = "GBP",
                CVV = "333"
            });
            Assert.Equal("alexwinchester@email.com", paymentResult.CustomerEmail);
            Assert.Equal("49.99", paymentResult.Amount.ToString());
            Assert.Equal("123456789101112", paymentResult.CardNumber);
            Assert.Equal("1", paymentResult.PaymentStatus.ToString());
            Assert.Equal("01/12/2019 00:00:00", paymentResult.CardExpiryDate.ToString());
        }

        /// <summary>
        /// Creates the payment test should return null when bank fails to process payment.
        /// </summary>
        [Fact]
        public async void CreatePaymentTestShouldReturnNullWhenBankFailsToProcessPayment()
        {
            //update mockBankRepository to return failed payments
            MockBankRepository mockBankRepositoryFailProcess = new MockBankRepository(processPaymentSuccess: false);
            paymentsService = new PaymentsService(mockBankRepositoryFailProcess, paymentRepository);
            Payment paymentResult = await paymentsService.CreatePayment(new Payment
            {
                Amount = 449.99F,
                CustomerEmail = "johndoe@aemail.com",
                CustomerName = "John Doe",
                CardExpiryDate = new DateTime(2019, 12, 1),
                CardNumber = "123456789101112",
                Currency = "GBP",
                CVV = "333"
            });
            Assert.Null(paymentResult);
        }
    }
}
