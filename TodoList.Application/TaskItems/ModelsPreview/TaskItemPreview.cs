using System;
using System.Linq.Expressions;
using TodoList.Domain.Entities;

namespace TodoList.Application.TaskItems.ModelsPreview
{
    public class TaskItemPreview
    {
        public Guid Id { get; protected set; }
        public string Topic { get; protected set; }
        public string Description { get; protected set; }
        public string Category { get; protected set; }
        public string EndDate { get; protected set; }
        public Priority Priority { get; protected set; }

        public static Expression<Func<TaskItem, TaskItemPreview>> Projection
        {
            get
            {
                return p => new TaskItemPreview
                {
                    Id = p.Id,
                    Topic = p.Topic,
                    Category = p.Category,
                    Description = p.Description,
                    EndDate = p.EndDate.ToString("yyyy-MM-dd"),
                    Priority = p.Priority
                };
            }
        }
    }
}