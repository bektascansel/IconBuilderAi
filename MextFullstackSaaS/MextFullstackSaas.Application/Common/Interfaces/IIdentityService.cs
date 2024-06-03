
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.Auth;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Login;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.VerifyEmail;
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
        Task<JwtDto> LoginAsync(UserAuthLoginCommand userAuthLoginCommand, CancellationToken cancellationToken);
        Task<bool> IsEmailExistsAsync(string email,CancellationToken cancellationToken);
        Task<bool> CheckPasswordSignInAsync (string email, string password, CancellationToken cancellationToken);
        Task<bool> VerifyEmailAsync(UserAuthVerifyEmailCommand command, CancellationToken cancellationToken);
        Task<bool> CheckIfEmailVerifiedAsync(string email, CancellationToken cancellationToken);

    }
}
