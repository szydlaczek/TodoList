using FluentValidation;

namespace TodoList.Application.TaskItems.Commands.CreateTaskItem
{
    public class CreateTaskItemCommandValidator :AbstractValidator<CreateTaskItemCommand>
    {
        public CreateTaskItemCommandValidator()
        {
            RuleFor(c => c.Category)
                .NotNull();

            RuleFor(e => e.Description).NotEmpty();

            RuleFor(a => a.Email)
                .NotEmpty();

            RuleFor(d => d.LastName)
                .NotEmpty();

            RuleFor(a => a.Title)
                .NotEmpty();
        }
    }
}