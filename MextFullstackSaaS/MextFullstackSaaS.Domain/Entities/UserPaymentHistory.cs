using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Domain.Entities
{
    public class UserPaymentHistory: EntityBase<Guid>
    {
        public PaymentStatus Status { get; set; }
        public string? Note { get; set; }
        public Guid UserPaymentId { get; set; }
        public UserPayment UserPayment { get; set; }


    }
}
