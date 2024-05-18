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

            RuleFor(x => x).Custom((dto, context) =>
            {
                if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.UserName))
                {
                    context.AddFailure("Email", "Either Email or UserName must be provided.");
                    context.AddFailure("UserName", "Either Email or UserName must be provided.");
                }
            });
        }
    }
}