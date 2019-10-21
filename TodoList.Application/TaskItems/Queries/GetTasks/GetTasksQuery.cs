using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Application.Helpers;

namespace TodoList.Application.TaskItems.Queries.GetTasks
{
    public class GetTasksQuery : IRequest<Response>
    {
        public string Temat { get; set; }
    }
}
