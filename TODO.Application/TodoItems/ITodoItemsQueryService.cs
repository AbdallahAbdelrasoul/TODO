using TODO.Application.TodoItems.DTOs;

namespace TODO.Application.TodoItems
{
    public interface ITodoItemsQueryService
    {
        Task<List<TodoItemDTO>> GetAll();
        Task<List<TodoItemDTO>> GetPending();
    }
}
