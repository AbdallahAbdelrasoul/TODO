using TODO.Application.TodoItems.DTOs;
using TODO.Domain.Shared.Repositories;
using TODO.Domain.Shared.Validation;
using TODO.Domain.TodoItems;

namespace TODO.Application.TodoItems
{
    public class TodoItemsService : ITodoItemsService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IValidationEngine _validationEngine;
        public TodoItemsService(ITodoRepository todoRepository, IValidationEngine validationEngine)
        {
            _todoRepository = todoRepository;
            _validationEngine = validationEngine;
        }

        public async Task<TodoItemDTO> Create(TodoItemCreateDTO input)
        {
            var todoItem = input.ToTodoItem();

            await todoItem.Create(_todoRepository, _validationEngine);

            return TodoItemDTO.FromTodoItem(todoItem);
        }

        public async Task<TodoItemDTO> MarkAsCompleted(int id)
        {
            var todoItem = await TodoItem.Get(_todoRepository, id);
            todoItem.SetItCompleted();

            await todoItem.Update(_todoRepository, _validationEngine);
            return TodoItemDTO.FromTodoItem(todoItem);
        }
    }
}
