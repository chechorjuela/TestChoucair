using TestChoucair.Application.Dto;
using FluentValidation;

namespace TestChoucair.Application.Validator
{
    public class SignInValidator : AbstractValidator<SignInRequestDto>
    {
        public SignInValidator()
        {
            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
            
            RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("UserName is required.");


        }
    }
}