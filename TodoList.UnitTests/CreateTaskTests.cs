using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Helpers;
using TodoList.Application.TaskItems.Commands.CreateTaskItem;
using TodoList.Domain.Entities;
using TodoList.Persistence;
using Xunit;

namespace TodoList.UnitTests
{
    public class CreateTaskTests
    {
        [Fact]
        public async Task Call_Handler_Should_Create_new_Task()
        {
            var options = DbContextOptionsHelper.GetOptions(Guid.NewGuid().ToString());
            using (var _context = new ApplicationDbContext(options))
            {
                var command = new CreateTaskItemCommand("TestTitle", "TestDescription", "TestCategor", DateTime.Now, Priority.Info, "TestName", "TestLastName", "TestEmail@email.com");
                var handler = new CreateTaskItemCommandHandler(_context);
                var result = await handler.Handle(command, CancellationToken.None);

                var actualTasksCount = _context.TaskItems.ToList().Count;
                Assert.IsType<SuccessResponse>(result);
                Assert.Equal(1, actualTasksCount);                
            }
        }
    }
}
