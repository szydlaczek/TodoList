using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Helpers;
using TodoList.Persistence;

namespace TodoList.Application.TaskItems.Commands.CreateTaskItem
{
    public class CreateTaskItemCommandHandler : IRequestHandler<CreateTaskItemCommand, Response>
    {
        private readonly ApplicationDbContext _context;

        public CreateTaskItemCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var taskItem = request.BuildTaskItem();
            _context.TaskItems.Add(taskItem);

            await _context.SaveChangesAsync();

            return SuccessResponse.Create(taskItem.Id);
        }
    }
}