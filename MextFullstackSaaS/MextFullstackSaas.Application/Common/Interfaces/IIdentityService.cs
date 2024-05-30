﻿
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.Auth;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand userAuthRegisterCommand,CancellationToken cancellationToken);
        Task<JwtDto> SignInAsync(UserAuthRegisterCommand userAuthRegisterCommand, CancellationToken cancellationToken);
        Task<bool> IsEmailExistsAsync(string email,CancellationToken cancellationToken);
    }
}
