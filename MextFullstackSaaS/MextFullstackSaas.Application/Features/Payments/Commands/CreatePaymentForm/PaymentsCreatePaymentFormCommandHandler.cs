using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentsCreatePaymentFormCommandHandler : IRequestHandler<PaymentsCreatePaymentFormCommand, object>
    {
        private readonly IPaymentService _paymentService;

        public PaymentsCreatePaymentFormCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public Task<object> Handle(PaymentsCreatePaymentFormCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
