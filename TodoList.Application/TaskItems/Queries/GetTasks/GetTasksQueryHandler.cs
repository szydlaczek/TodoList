using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Helpers;
using TodoList.Application.TaskItems.ModelsPreview;
using TodoList.Persistence;
using TodoList.Application.TaskItems.Queries.Helpers;

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
            return new Response(result);
        }
    }
}
