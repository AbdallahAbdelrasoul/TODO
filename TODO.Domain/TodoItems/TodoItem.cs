using FluentValidation;
using TODO.Domain.Shared.Exceptions;
using TODO.Domain.Shared.Repositories;
using TODO.Domain.Shared.Validation;

namespace TODO.Domain.TodoItems
{
    public class TodoItem : IValidationModel<TodoItem>
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public AbstractValidator<TodoItem> Validator => new TodoItemValidator();

        private TodoItem()
        {
            Title = string.Empty;
            IsCompleted = false;
        }

        public static TodoItem Create(int? id, string title, string? description)
            => new()
            {
                Id = id ?? 0,
                Title = title,
                Description = description ?? string.Empty,
                IsCompleted = false,
                CreatedDate = DateTime.UtcNow
            };

        public async Task<int> Create(ITodoRepository repository, IValidationEngine validationEngine)
        {
            validationEngine.Validate(this);
            return await repository.Create(this);
        }

        public static async Task<TodoItem> Get(ITodoRepository repository, int id)
        {
            return await repository.Get(id) ?? throw new DataNotFoundException();
        }

        public static async Task<List<TodoItem>> GetAll(ITodoRepository repository)
        {
            return await repository.GetAll();
        }
        public static async Task<List<TodoItem>> GetPending(ITodoRepository repository)
        {
            return await repository.GetPending();
        }

        public void SetItCompleted()
        {
            IsCompleted = true;
        }

        public async Task<bool> Update(ITodoRepository repository, IValidationEngine validationEngine)
        {
            validationEngine.Validate(this);
            return await repository.Update(this);
        }
    }
}
