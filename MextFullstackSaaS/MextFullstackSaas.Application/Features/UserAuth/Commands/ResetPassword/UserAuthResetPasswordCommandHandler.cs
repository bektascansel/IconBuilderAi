using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Password.ResetPassword
{
    public class UserAuthResetPasswordCommandHandler : IRequestHandler<UserAuthResetPasswordCommand, ResponseDto<bool>>
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;
    

        public UserAuthResetPasswordCommandHandler(IIdentityService identityService, IEmailService emailService)
        {
            _identityService = identityService;
            _emailService = emailService;
         
        }


        public async Task<ResponseDto<bool>> Handle(UserAuthResetPasswordCommand request, CancellationToken cancellationToken)
        {
            await  _identityService.ResetPasswordAsync(request, cancellationToken);
            await _emailService.SendPasswordChangedNotificationAsync(request.Email,cancellationToken);

          
            return new ResponseDto<bool>(true, "Password reseted successfully");
            
            
        }
    }
}
