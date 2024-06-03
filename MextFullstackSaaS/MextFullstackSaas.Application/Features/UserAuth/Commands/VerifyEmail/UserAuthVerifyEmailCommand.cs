using MediatR;
using MextFullstackSaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.VerifyEmail
{
    public class UserAuthVerifyEmailCommand:IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public UserAuthVerifyEmailCommand(string email, string token)
        {
           Email = Email;
           Token = Token;
        }

        public UserAuthVerifyEmailCommand() { }
    }
}
