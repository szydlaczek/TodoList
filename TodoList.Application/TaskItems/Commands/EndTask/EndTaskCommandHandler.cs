using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Helpers;
using TodoList.Domain.Entities;
using TodoList.Persistence;

namespace TodoList.Application.TaskItems.Commands.EndTask
{
    public class EndTaskCommandHandler : IRequestHandler<EndTaskCommand, Response>
    {
        private readonly ApplicationDbContext _context;
        public EndTaskCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response> Handle(EndTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _context.TaskItems
                .Where(t => t.Id == request.TaskId && t.Status == TaskItemStatus.Started)
                .FirstOrDefaultAsync();

            if (taskItem is null)
                return ErrorResponse.Create(ErrorCode.EndTaskError, "No task to end");

            taskItem.StopTask();
            await _context.SaveChangesAsync();

            return SuccessResponse.Create(true);
        }
    }
}
