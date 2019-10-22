using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Helpers;
using TodoList.Domain.Entities;
using TodoList.Persistence;

namespace TodoList.Application.TaskItems.Commands.StartTask
{
    public class StartTaskCommandHandler : IRequestHandler<StartTaskCommand, Response>
    {
        private readonly ApplicationDbContext _context;

        public StartTaskCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(StartTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _context.TaskItems
                .Where(t => t.Id == request.TaskId && t.Status == TaskItemStatus.Wating)
                .FirstOrDefaultAsync();

            if (taskItem is null)
                return ErrorResponse.Create(ErrorCode.StartTaskError, "No task to start");

            taskItem.StartTask();
            await _context.SaveChangesAsync();

            return SuccessResponse.Create(true);
        }
    }
}