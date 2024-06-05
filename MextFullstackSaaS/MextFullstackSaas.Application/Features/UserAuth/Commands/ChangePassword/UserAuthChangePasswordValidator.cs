using FluentValidation;
using MextFullstackSaaS.Application.Common.FluentValidation.BaseValidators;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Password.ForgotPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.ChangePassword
{
    public class UserAuthChangePasswordValidator : UserAuthValidatorBase<UserAuthChangePasswordCommand>
    {
        public UserAuthChangePasswordValidator(IIdentityService identityService) : base(identityService)
        {
            RuleFor(x => x.CurrentPassword)
              .NotEmpty().WithMessage("Password is required")
              .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("Confirm Password is required");


            RuleFor(x => x.NewPassword)
              .NotEmpty().WithMessage("Password is required")
              .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.ConfirmPassword)
               .NotEmpty().WithMessage("Confirm Password is required")
               .Equal(x => x.NewPassword).WithMessage("Passwords do not match");
        }
    }
}
