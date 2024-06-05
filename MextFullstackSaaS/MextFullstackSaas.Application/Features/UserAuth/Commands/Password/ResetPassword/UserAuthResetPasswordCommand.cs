using MediatR;
using MextFullstackSaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Password.ResetPassword
{
    public class UserAuthResetPasswordCommand:IRequest<ResponseDto<bool>>
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }

}
