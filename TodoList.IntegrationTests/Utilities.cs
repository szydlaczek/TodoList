using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Domain.Entities;
using TodoList.Persistence;

namespace TodoList.IntegrationTests
{
    public static class Utilities
    {
        public static void InitializeTaskItems(ApplicationDbContext context)
        {
            var list = new List<TaskItem>
            {
                new TaskItem(Guid.Parse("73617adc-cd44-4b5f-b23f-698457d1bf41"), "Add unit test", "Some description", "Category1" ,DateTime.Now, Priority.Info, "somename", "someLastName", "some@email.com"),
                new TaskItem(Guid.Parse("73617adc-cd44-4b5f-b23f-698457d1bf42"), "Add functional", "Some description", "Category1", DateTime.Now, Priority.Info, "somename", "someLastName", "some@email.com"),
                new TaskItem(Guid.Parse("73617adc-cd44-4b5f-b23f-698457d1bf43"), "Add integration test", "Some description", "Category1", DateTime.Now, Priority.Info, "somename", "someLastName", "some@email.com")
            };
            context.TaskItems.AddRange(list);
            context.SaveChanges();
        }
    }
}
