using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.Payments;
using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Enums;
using MextFullstackSaaS.Domain.ValueObjects;

namespace MextFullstackSaaS.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentsCreatePaymentFormCommandHandler : IRequestHandler<PaymentsCreatePaymentFormCommand, ResponseDto<PaymentsCreatePaymentFormDto>>
    {
        private readonly IPaymentService _paymentService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;
        private readonly IApplicationDbContext _applicationDbContext;

        public PaymentsCreatePaymentFormCommandHandler(IPaymentService paymentService, ICurrentUserService currentUserService, IIdentityService identityService, IApplicationDbContext applicationDbContext)
        {
            _paymentService = paymentService;
            _currentUserService = currentUserService;
            _identityService = identityService;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseDto<PaymentsCreatePaymentFormDto>> Handle(PaymentsCreatePaymentFormCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _identityService.GetProfileAsync(cancellationToken);

            var paymentDetail = userProfile.MapToPaymentDetail();

            var userRequest = new PaymentsCreateCheckoutFormRequest(paymentDetail, request.Credits);

            var checkoutFormResponse = _paymentService.CreateCheckoutForm(userRequest);

            var userPayment = MapUserPayment(paymentDetail, checkoutFormResponse);

            _applicationDbContext.UserPayments.Add(userPayment);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var response = new PaymentsCreatePaymentFormDto(checkoutFormResponse.PaymentPageUrl);

            return new ResponseDto<PaymentsCreatePaymentFormDto>(response);
        }

        private UserPayment MapUserPayment(UserPaymentDetail paymentDetail,
            PaymentsCreateCheckoutFormResponse checkoutFormResponse)
        {
            var userPaymentId = Guid.NewGuid();

            return new UserPayment()
            {
                Id = userPaymentId,
                UserId = _currentUserService.UserId,
                BasketId = checkoutFormResponse.BasketId,
                Price = checkoutFormResponse.Price,
                PaidPrice = checkoutFormResponse.PaidPrice,
                CurrencyCode = CurrencyCode.TRY,
                CreatedOn = DateTimeOffset.UtcNow,
                Token = checkoutFormResponse.Token,
                UserPaymentDetail = paymentDetail,
                Status = PaymentStatus.Initiated,
                CreatedByUserId = _currentUserService.UserId.ToString(),
                Histories = new List<UserPaymentHistory>()
                {
                    new UserPaymentHistory()
                    {
                        Id = Guid.NewGuid(),
                        Status = PaymentStatus.Initiated,
                        UserPaymentId = userPaymentId,
                        ConversationId = checkoutFormResponse.ConversationId,
                        CreatedOn = DateTimeOffset.UtcNow,
                        CreatedByUserId = _currentUserService.UserId.ToString(),
                    }
                }
            };
        }
    }
}