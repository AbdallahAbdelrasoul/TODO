using TODO.Application.TodoItems.DTOs;
using TODO.Domain.Shared.Repositories;
using TODO.Domain.TodoItems;

namespace TODO.Application.TodoItems
{
    public class TodoItemsQueryService : ITodoItemsQueryService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoItemsQueryService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<TodoItemDTO>> GetAll()
        {
            var todoItems = await TodoItem.GetAll(_todoRepository);
            return todoItems.Select(x => TodoItemDTO.FromTodoItem(x)).ToList();
        }

        public async Task<List<TodoItemDTO>> GetPending()
        {
            var todoItems = await TodoItem.GetPending(_todoRepository);
            return todoItems.Select(x => TodoItemDTO.FromTodoItem(x)).ToList();
        }
    }
}
