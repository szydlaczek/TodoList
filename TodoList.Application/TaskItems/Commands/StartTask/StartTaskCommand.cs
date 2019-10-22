using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Application.Helpers;

namespace TodoList.Application.TaskItems.Commands.StartTask
{
    public class StartTaskCommand : IRequest<Response>
    {
        public StartTaskCommand(Guid taskId)
        {
            TaskId = taskId;
        }
        public Guid TaskId { get; set; }
    }
}
