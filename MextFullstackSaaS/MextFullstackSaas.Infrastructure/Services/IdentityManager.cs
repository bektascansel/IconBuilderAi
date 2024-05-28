using MextFullstackSaas.Application.Common.Interfaces;
using MextFullstackSaas.Application.Common.Models;
using MextFullstackSaas.Application.Common.Models.Auth;
using MextFullstackSaas.Application.Features.UserAuth.Commands.Register;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Infrastructure.Services
{
    public class IdentityManager : IIdentityService
    {

        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;

        public IdentityManager(UserManager<User> userManager , IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            var user= await _userManager.FindByEmailAsync(email);

            if (user is not null)
                return true;

            return false;
        }

        public async Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand userAuthRegisterCommand, CancellationToken cancellationToken)
        { 

            var user = UserAuthRegisterCommand.ToUser(userAuthRegisterCommand);
            var result=await _userManager.CreateAsync(user, userAuthRegisterCommand.Password);

            if(!result.Succeeded)
            {
                throw new Exception("User registration failed");
            }


            return new UserAuthRegisterResponseDto(user.Id, user.Email);
        }

        public Task<JwtDto> SignInAsync(UserAuthRegisterCommand userAuthRegisterCommand, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
