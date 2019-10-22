using FluentValidation;

namespace TodoList.Application.TaskItems.Commands.CreateTaskItem
{
    public class CreateTaskItemCommandValidator :AbstractValidator<CreateTaskItemCommand>
    {
        public CreateTaskItemCommandValidator()
        {

        }
    }
}