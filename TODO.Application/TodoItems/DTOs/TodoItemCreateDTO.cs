using TODO.Domain.TodoItems;

namespace TODO.Application.TodoItems.DTOs
{
    public class TodoItemCreateDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }

        public TodoItem ToTodoItem() => TodoItem.Create(null, Title, Description);
    }
}
