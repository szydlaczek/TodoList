using System;
using TodoList.Domain.Exceptions;

namespace TodoList.Domain.Entities
{
    public class TaskItem
    {
        public TaskItem(Guid id, string topic, 
            string description, string category,
            DateTime expirationDate, Priority priority,
            string name, string lastName, string email)
        {
            Id = id;
            Title = topic;
            Description = description;
            Category = category;
            ExpirationDate = expirationDate;
            Priority = priority;
            Status = TaskItemStatus.Wating;
            Name = name;
            LastName = lastName;
            Email = email;
        }

        protected TaskItem()
        {
        }

        public Guid Id { get; protected set; }

        public string Title { get; protected set; }

        public string Description { get; protected set; }

        public string Category { get; protected set; }

        public DateTime ExpirationDate { get; protected set; }

        public DateTime? StartDate { get; protected set; }

        public DateTime? EndDate { get; protected set; }

        public Priority Priority { get; protected set; }

        public TaskItemStatus Status { get; protected set; }

        public string Name { get; protected set; }

        public string LastName { get; protected set; }

        public string Email { get; protected set; }

        public void StartTask()
        {
            if (Status != TaskItemStatus.Wating)
                throw new TodoListException("Cannot start task");
            Status = TaskItemStatus.Started;
            StartDate = DateTime.Now;
        }

        public void StopTask()
        {
            if (Status != TaskItemStatus.Started)
                throw new TodoListException("Cannot stop task");
            Status = TaskItemStatus.Ended;
            EndDate = DateTime.Now;
        }
    }
}