using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Application.TaskItems.ModelsPreview;

namespace TodoList.IntegrationTests
{
    public class GetTasksResponse
    {
        public List<TaskItemPreview> Data { get; set; }
    }
}
