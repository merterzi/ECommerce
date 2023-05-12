using Entities.DTOs;
using FluentValidation;

namespace Entities.Validators.FluentValidation
{
    public class UserRegisterValidator : AbstractValidator<UserForRegistrationDto>
    {
        public UserRegisterValidator()
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
