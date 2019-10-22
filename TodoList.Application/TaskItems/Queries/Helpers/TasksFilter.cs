using System;
using System.Linq;
using TodoList.Application.TaskItems.Queries.GetTasks;
using TodoList.Domain.Entities;

namespace TodoList.Application.TaskItems.Queries.Helpers
{
    public static class TasksFilter
    {
        public static IQueryable<TaskItem> Filter(this IQueryable<TaskItem> data, GetTasksQuery query)
        {
            data = data.Where(s => s.Status != TaskItemStatus.Ended);

            if (query.Temat != null)
            {
                return data
                    .Where(d => d.Title.Contains(query.Temat, StringComparison.OrdinalIgnoreCase));
            }
            return data;
        }
    }
}