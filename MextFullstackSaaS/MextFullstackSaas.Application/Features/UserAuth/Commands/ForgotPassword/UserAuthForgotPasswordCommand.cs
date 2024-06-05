using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;
using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Password.ForgotPassword
{
    public  class UserAuthForgotPasswordCommand: IRequest<ResponseDto<bool>>
    {
        public string Email { get; set; }
       

     
    }
}
