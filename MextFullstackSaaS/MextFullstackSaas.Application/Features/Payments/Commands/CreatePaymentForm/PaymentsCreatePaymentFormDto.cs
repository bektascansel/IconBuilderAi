namespace MextFullstackSaaS.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentsCreatePaymentFormDto
    {
        public string PaymentPageUrl { get; set; }

        public PaymentsCreatePaymentFormDto(string paymentPageUrl)
        {
            PaymentPageUrl = paymentPageUrl;
        }

        public PaymentsCreatePaymentFormDto()
        {

        }
    }
}