using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Common.Models.Payments
{
    public class PaymentsCheckPaymentByTokenResponse
    {
        public bool IsSuccess { get; set; }
        public string ConversationId { get; set; }
        public string PaymentStatus { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorGroup { get; set; }
        public string ErrorMessage { get; set; }
    }
}