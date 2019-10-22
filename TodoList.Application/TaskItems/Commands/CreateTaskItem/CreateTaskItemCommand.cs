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
        public CreateTaskItemCommand(string name, string surname,
            string category, string email,
            string topic, string description,
            DateTime endDate, Priority priority)
        {
            Name = name;
            Surname = surname;
            Category = category;
            Email = email;
            Topic = topic;
            Description = description;
            EndDate = endDate;
            Priority = priority;
        }

        public string Name { get; protected set; }

        public string Surname { get; protected set; }

        public string Category { get; protected set; }

        public string Email { get; protected set; }

        public string Topic { get; protected set; }

        public string Description { get; protected set; }

        public DateTime EndDate { get; protected set; }

        public Priority Priority { get; protected set; }

        public TaskItem BuildTaskItem()
        {
            return new TaskItem(Guid.NewGuid(), Topic, Description, Category, EndDate, Priority);
        }
    }
}