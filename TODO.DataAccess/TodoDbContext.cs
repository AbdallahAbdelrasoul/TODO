using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TODO.Domain.TodoItems;

namespace TODO.DataAccess
{
    [ExcludeFromCodeCoverage]

    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
