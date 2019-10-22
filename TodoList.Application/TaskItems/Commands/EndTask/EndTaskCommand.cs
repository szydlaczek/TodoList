using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Application.Helpers;

namespace TodoList.Application.TaskItems.Commands.EndTask
{
    public class EndTaskCommand : IRequest<Response>
    {
        public EndTaskCommand(Guid taskId)
        {
            TaskId = taskId;
        }

        public Guid TaskId { get; }
    }
}
