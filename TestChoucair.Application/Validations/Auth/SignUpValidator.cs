using TestChoucair.Application.Dto;
using FluentValidation;

namespace TestChoucair.Application.Validator
{
    public class SingUpValidator : AbstractValidator<SignUpRequestDto>
    {
        public SingUpValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be at least 6 characters long");
        }
    }
}