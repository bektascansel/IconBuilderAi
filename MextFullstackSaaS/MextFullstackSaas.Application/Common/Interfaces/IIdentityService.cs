using MextFullstackSaas.Application.Common.Models;
using MextFullstackSaas.Application.Common.Models.Auth;
using MextFullstackSaas.Application.Features.UserAuth.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand userAuthRegisterCommand,CancellationToken cancellationToken);
        Task<JwtDto> SignInAsync(UserAuthRegisterCommand userAuthRegisterCommand, CancellationToken cancellationToken);
        Task<bool> IsEmailExistsAsync(string email,CancellationToken cancellationToken);
    }
}
