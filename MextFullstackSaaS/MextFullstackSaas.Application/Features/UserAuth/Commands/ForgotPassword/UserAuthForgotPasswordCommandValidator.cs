using FluentValidation;
using MextFullstackSaaS.Application.Common.FluentValidation.BaseValidators;
using MextFullstackSaaS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Password.ForgotPassword
{
    public class UserAuthForgotPasswordCommandValidator : UserAuthValidatorBase<UserAuthForgotPasswordCommand>
    {
        public UserAuthForgotPasswordCommandValidator(IIdentityService identityService) : base(identityService)
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

            RuleFor(x => x.Email)
                .MustAsync(CheckIfUserExists)
                .WithMessage("User with this email already exists");

            RuleFor(x => x.Email)
                .MustAsync(CheckIfEmailVerifiedAsync)
                .WithMessage("Email is not verified.Please verify your email");

        }

        private async Task<bool> CheckIfUserExists(string email, CancellationToken cancellationToken)
        {
            return await _identityService.IsEmailExistsAsync(email, cancellationToken);
        }

        private Task<bool> CheckIfEmailVerifiedAsync(string email, CancellationToken cancellationToken)
        {
            return _identityService.CheckIfEmailVerifiedAsync(email, cancellationToken);
        }
    }
}
