using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Helpers;
using TodoList.Application.TaskItems.ModelsPreview;
using TodoList.Application.TaskItems.Queries.Helpers;
using TodoList.Persistence;

namespace TodoList.Application.TaskItems.Queries.GetTasks
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, Response>
    {
        private readonly ApplicationDbContext _context;

        public GetTasksQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _context.TaskItems.AsQueryable().Filter(request).ToListAsync();            

            var result = tasks.AsQueryable().Select(TaskItemPreview.Projection).ToList();

            return SuccessResponse.Create(result);
        }
    }
}
