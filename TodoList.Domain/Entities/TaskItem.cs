using System;
using TodoList.Domain.Exceptions;

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
            Status = TaskItemStatus.Wating;
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

        public TaskItemStatus Status { get; protected set; }

        public void StartTask()
        {
            if (Status != TaskItemStatus.Wating)
                throw new TodoListException("Cannot start task");
            Status = TaskItemStatus.Started;
        }

        public void StopTask()
        {
            if (Status != TaskItemStatus.Started)
                throw new TodoListException("Cannot stop task");
            Status = TaskItemStatus.Ended;
        }
    }
}