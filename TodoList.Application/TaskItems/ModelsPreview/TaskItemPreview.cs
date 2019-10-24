using System;
using System.Linq.Expressions;
using TodoList.Domain.Entities;

namespace TodoList.Application.TaskItems.ModelsPreview
{
    public class TaskItemPreview
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string EndDate { get;  set; }
        public Priority Priority { get; set; }
        public TaskItemStatus Status { get; set; }

        public static Expression<Func<TaskItem, TaskItemPreview>> Projection
        {
            get
            {
                return p => new TaskItemPreview
                {
                    Id = p.Id,
                    Topic = p.Title,
                    Category = p.Category,
                    Description = p.Description,
                    EndDate = p.ExpirationDate.ToString("yyyy-MM-dd"),
                    Priority = p.Priority,
                    Status = p.Status
                };
            }
        }
    }
}