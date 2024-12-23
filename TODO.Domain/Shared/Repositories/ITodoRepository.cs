using TODO.Domain.TodoItems;

namespace TODO.Domain.Shared.Repositories
{
    public interface ITodoRepository
    {
        Task<int> Create(TodoItem todoItem);
        Task<TodoItem?> Get(int id);
        Task<List<TodoItem>> GetAll();
        Task<List<TodoItem>> GetPending();
        Task<bool> Update(TodoItem todoItem);
    }
}
