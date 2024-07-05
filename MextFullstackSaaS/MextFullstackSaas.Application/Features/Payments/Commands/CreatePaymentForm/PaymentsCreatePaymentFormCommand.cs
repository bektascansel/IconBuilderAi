using MediatR;
using MextFullstackSaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentsCreatePaymentFormCommand:IRequest<ResponseDto<PaymentsCreatePaymentFormDto>>
    {
        public int Credits { get; set; }
    }
}
