using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.Email;
using MextFullstackSaaS.Application.Common.Models.Emails;
using MextFullstackSaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Password.ForgotPassword
{
    public class UserAuthForgotPasswordCommandHandler : IRequestHandler<UserAuthForgotPasswordCommand, ResponseDto<bool>>
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;

        public UserAuthForgotPasswordCommandHandler(IIdentityService identityService,  IEmailService emailService)
        {
            _identityService = identityService;
            _emailService = emailService;
        }
        public async Task<ResponseDto<bool>> Handle(UserAuthForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.ForgotPasswordAsync(request.Email, cancellationToken);

            //var sendEmailTask = SendEmailForgotPasswordAsync(response.Email, response.FirstName, response.EmailToken, cancellationToken);

            var sendEmailTask = SendEmailForgotPasswordAsync(response.Email, response.FirstName, response.EmailToken, cancellationToken);

            await Task.WhenAll( sendEmailTask);
            return new ResponseDto<bool>(true,"Email Sended");
        }

        private Task SendEmailForgotPasswordAsync(string email, string firstName, string emailToken, CancellationToken cancellationToken)
        {
            var emailDto = new EmailSendResetPasswordDto(email, firstName, emailToken);

            return _emailService.SendEmailResetPasswordAsync(emailDto, cancellationToken);
        }



    }
}
