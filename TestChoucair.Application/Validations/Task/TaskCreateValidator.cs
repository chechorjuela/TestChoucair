using TestChoucair.Application.Dto;
using FluentValidation;

namespace TestChoucair.Application.Validator
{
    public class TaskCreateValidator : AbstractValidator<TaskRequestDto>
    {
        public TaskCreateValidator()
        {
        }
    }
}