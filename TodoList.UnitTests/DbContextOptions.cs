using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TodoList.Persistence;

namespace TodoList.UnitTests
{
    public static class DbContextOptionsHelper
    {
        public static DbContextOptions<ApplicationDbContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: databaseName)
                 .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                 .Options;
        }
    }
}
