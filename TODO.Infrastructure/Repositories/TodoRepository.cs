using Microsoft.EntityFrameworkCore;
using TODO.DataAccess;
using TODO.Domain.Shared.Repositories;
using TODO.Domain.TodoItems;

namespace TODO.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(TodoItem todoItem)
        {
            await _dbContext.TodoItems.AddAsync(todoItem);
            await _dbContext.SaveChangesAsync();
            return todoItem.Id;
        }
        public async Task<TodoItem?> Get(int id)
        {
            return await _dbContext.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TodoItem>> GetAll()
        {
            return await _dbContext.TodoItems.ToListAsync();
        }

        public async Task<List<TodoItem>> GetPending()
        {
            return await _dbContext.TodoItems
                .Where(x => !x.IsCompleted)
                .ToListAsync();
        }

        public async Task<bool> Update(TodoItem todoItem)
        {
            if (_dbContext.ChangeTracker
                .Context.Entry(todoItem)
                .Properties.Any(property => property.IsModified))
            {
                return await _dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
