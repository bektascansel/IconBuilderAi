using MextFullstackSaaS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Common.Models.Payments
{
    public class PaymentsCreateCheckoutFormRequest
    {
     
        public UserPaymentDetail PaymentDetail { get; set; }
        public int Credits { get; set; }

        public PaymentsCreateCheckoutFormRequest()
        {
        }
        public PaymentsCreateCheckoutFormRequest(UserPaymentDetail paymentDetail,int credits)
        {
            PaymentDetail = paymentDetail;
            Credits = credits;
        }
    }
}
