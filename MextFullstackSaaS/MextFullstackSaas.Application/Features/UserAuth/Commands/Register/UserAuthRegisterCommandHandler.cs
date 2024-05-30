using MediatR;

using MextFullstackSaas.Application.Common.Models;
using MextFullstackSaas.Application.Common.Models.Email;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommandHandler : IRequestHandler<UserAuthRegisterCommand, ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;


        public UserAuthRegisterCommandHandler(IIdentityService identityService, IJwtService jwtService, IEmailService emailService)
        {
            _identityService = identityService;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        public async Task<ResponseDto<JwtDto>> Handle(UserAuthRegisterCommand request, CancellationToken cancellationToken)
        {
            
            var response=await _identityService.RegisterAsync(request, cancellationToken);

            var jwtDtoTask = _jwtService.GenerateTokenAsync(response.Id,response.Email,cancellationToken);
            var sendEmailTask= SendEmailVerificationAsync(response.EmailToken, response.FirstName, response.Email, cancellationToken);

            //var jwtDtoTaskResponse = await jwtDtoTask;

            //await sendEmailTask;

            await Task.WhenAll(jwtDtoTask, sendEmailTask);
            //send email verification


            return new ResponseDto<JwtDto>(await jwtDtoTask, "Welcome to our application!");
        }

        private Task SendEmailVerificationAsync (string emailToken, string firstName,string email, CancellationToken cancellationToken)
        {
            var emailDto = new EmailSendEmailVerificationDto(emailToken, firstName, email);

           return  _emailService.SendEmailVerificationAsync(emailDto, cancellationToken);
        }
    }
}
