using MediatR;
using MextFullstackSaas.Application.Common.Interfaces;
using MextFullstackSaas.Application.Common.Models;
using MextFullstackSaas.Application.Common.Models.Email;
using MextFullstackSaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommandHandler : IRequestHandler<UserAuthRegisterCommand, ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtService _jwtService;


        public UserAuthRegisterCommandHandler(IIdentityService identityService, IJwtService jwtService)
        {
            _identityService = identityService;
            _jwtService = jwtService;
        }

        public async Task<ResponseDto<JwtDto>> Handle(UserAuthRegisterCommand request, CancellationToken cancellationToken)
        {
            
            var response=await _identityService.RegisterAsync(request, cancellationToken);

            var jwtDto= await _jwtService.GenerateTokenAsync(response.Id,response.Email,cancellationToken);

            //send email verification

            await SendEmailVerificationAsync(response.Email, cancellationToken);

            return new ResponseDto<JwtDto>(jwtDto,"Welcome to our application!");
        }

        private async Task SendEmailVerificationAsync (string email, CancellationToken cancellationToken)
        {
            var emailDto = new EmailSendEmailVerificationDto();
        }
    }
}
