using TODO.Application.TodoItems.DTOs;

namespace TODO.Application.TodoItems
{
    public interface ITodoItemsService
    {
        Task<TodoItemDTO> Create(TodoItemCreateDTO input);
        Task<TodoItemDTO> MarkAsCompleted(int id);
    }
}
