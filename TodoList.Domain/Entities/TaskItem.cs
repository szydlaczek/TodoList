using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Domain.Entities
{
    public class TaskItem
    {
        public TaskItem(Guid id, string topic, string description, string category, DateTime endDate, Priority priority)
        {
            Id = id;
            Topic = topic;
            Description = description;
            Category = category;
            EndDate = endDate;
            Priority = priority;
        }

        protected TaskItem()
        {

        }

        public Guid Id { get; protected set; }

        public string Topic { get; protected set; }

        public string Description { get; protected set; }

        public string Category { get; protected set; }

        public DateTime EndDate { get; protected set; }

        public Priority Priority { get; protected set; }
    }
}
