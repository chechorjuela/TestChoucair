using TestChoucair.Application.Dto;
using FluentValidation;

namespace TestChoucair.Application.Validator
{
    public class TaskCreateValidator : AbstractValidator<TaskRequestDto>
    {
        public TaskCreateValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.");
            
            RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.");

             RuleFor(x => x.Time)
            .NotEmpty().WithMessage("Time is required.");

        }
    }
}