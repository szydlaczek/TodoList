using MediatR;
using TodoList.Application.Helpers;

namespace TodoList.Application.TaskItems.Queries.GetTasks
{
    public class GetTasksQuery : IRequest<Response>
    {
        public string Temat { get; set; }
    }
}