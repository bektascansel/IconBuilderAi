using FluentValidation;
using MextFullstackSaaS.Application.Common.FluentValidation.BaseValidators;
using MextFullstackSaaS.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Password.ResetPassword
{
    public class UserAuthResetPasswordCommandValidator : UserAuthValidatorBase<UserAuthResetPasswordCommand>
    {
        public UserAuthResetPasswordCommandValidator(IIdentityService identityService) : base(identityService)
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid")
                .MustAsync(CheckIfUserExists).WithMessage("User with this email does not exist")
                .MustAsync(CheckIfEmailVerifiedAsync).WithMessage("Email is not verified. Please verify your email");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required")
                .Equal(x => x.Password).WithMessage("Passwords do not match");
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
