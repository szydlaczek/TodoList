using MediatR;
using Newtonsoft.Json;
using System;
using TodoList.Application.Helpers;
using TodoList.Domain.Entities;

namespace TodoList.Application.TaskItems.Commands.CreateTaskItem
{
    public class CreateTaskItemCommand : IRequest<Response>
    {
        [JsonConstructor]
        public CreateTaskItemCommand(string title,
            string description, string category,
            DateTime expirationDate, Priority priority,
            string name, string lastName, string email)
        {
            Title = title;
            Description = description;
            Category = category;
            ExpirationDate = expirationDate;
            Priority = priority;
            Status = TaskItemStatus.Wating;
            Name = name;
            LastName = lastName;
            Email = email;
        }

        public string Title { get; protected set; }

        public string Description { get; protected set; }

        public string Category { get; protected set; }

        public DateTime ExpirationDate { get; protected set; }

        public Priority Priority { get; protected set; }

        public TaskItemStatus Status { get; protected set; }

        public string Name { get; protected set; }

        public string LastName { get; protected set; }

        public string Email { get; protected set; }

        public TaskItem BuildTaskItem()
        {
            return new TaskItem(Guid.NewGuid(), Title, Description, Category, ExpirationDate, Priority, Name, LastName, Email);
        }
    }
}