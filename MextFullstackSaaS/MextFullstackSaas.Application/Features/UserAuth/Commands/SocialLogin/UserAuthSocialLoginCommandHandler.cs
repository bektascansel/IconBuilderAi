using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.SocialLogin
{
    public class UserAuthSocialCommandHandler : IRequestHandler<UserAuthSocialLoginCommand, ResponseDto<JwtDto>>
    {
        public Task<ResponseDto<JwtDto>> Handle(UserAuthSocialLoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
