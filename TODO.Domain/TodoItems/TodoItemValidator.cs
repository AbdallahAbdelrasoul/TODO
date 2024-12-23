using FluentValidation;

namespace TODO.Domain.TodoItems
{
    internal class TodoItemValidator : AbstractValidator<TodoItem>
    {
        public TodoItemValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(256);

            When(x => x.Description is not null, () =>
            {
                RuleFor(x => x.Description).NotEmpty().MaximumLength(2560);
            });

            RuleFor(x => x.CreatedDate).NotEmpty();
        }
    }
}
