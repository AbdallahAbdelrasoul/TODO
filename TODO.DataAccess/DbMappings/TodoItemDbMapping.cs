using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TODO.Domain.TodoItems;

namespace TODO.DataAccess.DbMappings
{
    public class TodoItemDbMapping : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TodoItem").HasKey(k => k.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.Description)
                .HasMaxLength(2560);

            builder.Property(x => x.IsCompleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Ignore(x => x.Validator);
        }
    }
}
