using FluentValidation;

namespace TodayList.Application.Assignments.Commands.CreateAssignment
{
    public class CreateAssignmentCommandValidator : AbstractValidator<CreateAssignmentCommand>
    {
        public CreateAssignmentCommandValidator()
        {
            RuleFor(v => v.Title).NotEmpty().MaximumLength(200);
        }
    }
}