using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain.Entities;

namespace TodoList.Persistence.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(p => p.Priority)
                .IsRequired();
            builder.Property(p => p.Topic)
                .IsRequired();
            builder.Property(p => p.EndDate)
                .IsRequired();
            builder.Property(p => p.Description)
                .IsRequired();
            builder.Property(p => p.Category)
                .IsRequired();
        }
    }
}