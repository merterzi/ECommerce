using Entities.DTOs;
using FluentValidation;

namespace Entities.Validators.FluentValidation
{
    public class UserForAuthValidator : AbstractValidator<UserForAuthenticationDto>
    {
        public UserForAuthValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage("Username is required.");
            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is required.");
        }
    }
}
