using MediatR;
using MextFullstackSaaS.Application.Features.Payments.Commands.CompletePayment;
using MextFullstackSaaS.Application.Features.Payments.Commands.CreatePaymentForm;
using Microsoft.AspNetCore.Mvc;

namespace MextFullstackSaaS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ISender _mediator;

        public PaymentsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentFormAsync(PaymentsCreatePaymentFormCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        /*
        [HttpPost("payment-result")]
        public async Task<IActionResult> PaymentResultAsync([FromForm] string token, CancellationToken cancellationToken)
        {
            return Redirect($"http://localhost:5067/payment-success?token={token}");
        }
        */
        /*
        [HttpPost("complete-result")]
        public async Task<IActionResult> PaymentResultAsync([FromForm] string token, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new PaymentsCompletePaymentCommand(token), cancellationToken);

            if (!response.Data)
                return Redirect($"http://localhost:5067/payment-failed");

            return Redirect($"http://localhost:5067/payment-success");
        }
        */


        [HttpPost("complete-payment")]
        public async Task<IActionResult> PaymentResultAsync([FromForm] string token, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new PaymentsCompletePaymentCommand(token), cancellationToken);

            if (!response.Data)
                return Redirect($"http://localhost:5067/payment-failed");

            return Redirect($"http://localhost:5067/payment-success?message={response.Message}");
        }


    }
}