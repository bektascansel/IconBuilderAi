using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.ChangePassword
{
    public class UserAuthChangePasswordCommandHandler : IRequestHandler<UserAuthChangePasswordCommand, ResponseDto<bool>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public UserAuthChangePasswordCommandHandler(IIdentityService identityService, ICurrentUserService currentUserService)
        {
            _identityService = identityService;
            _currentUserService = currentUserService;
        }

        public async Task<ResponseDto<bool>> Handle(UserAuthChangePasswordCommand request, CancellationToken cancellationToken)
        {
            await _identityService.ChangePasswordAsync(_currentUserService.UserId,request.CurrentPassword,request.NewPassword,cancellationToken);
            
            return new ResponseDto<bool>(true, "Password changed successfully");
        }

    }
}
