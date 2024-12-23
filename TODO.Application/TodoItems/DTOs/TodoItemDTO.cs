using TODO.Domain.TodoItems;

namespace TODO.Application.TodoItems.DTOs
{
    public class TodoItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }

        public static TodoItemDTO FromTodoItem(TodoItem todoItem)
            => new()
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                IsCompleted = todoItem.IsCompleted,
                CreatedDate = todoItem.CreatedDate
            };
    }
}
