using AutoFixture;
using FluentValidation.Results;
using Moq;
using TODO.Domain.Shared.Exceptions;
using TODO.Domain.Shared.Repositories;
using TODO.Domain.Shared.Validation;
using TODO.Domain.TodoItems;

namespace TODO.Domain.Tests
{
    public class TodoItemTests
    {
        private readonly Mock<ITodoRepository> _todoRepository;
        private readonly Mock<IValidationEngine> _validationEngine;
        private readonly Fixture _fixture;
        public TodoItemTests()
        {
            _todoRepository = new Mock<ITodoRepository>();
            _validationEngine = new Mock<IValidationEngine>();

            _validationEngine
                .Setup(x => x.Validate(It.IsAny<TodoItem>(), true))
                .Returns((List<ValidationFailure>?)null);

            _fixture = new Fixture();
        }

        [Fact]
        public async Task Create_ValidInput_Success()
        {
            _todoRepository.Setup(x => x.Create(It.IsAny<TodoItem>())).ReturnsAsync(2);
            var todoItem = ValidTodoItem(_fixture);
            var output = await todoItem.Create(_todoRepository.Object, _validationEngine.Object);

            Assert.Equal(2, output);
        }

        [Theory]
        [InlineData("", null)]
        [InlineData(" ", null)]
        [InlineData("12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", null)]
        [InlineData("title", "")]
        [InlineData("title", " ")]
        public void Validator_InvalidObject_ThrowsNotValidException(string title, string? description)
        {
            var validationEngine = new ValidationEngine();
            var totoItem = TodoItem.Create(_fixture.Create<int>(), title, description);

            Assert.Throws<DataNotValidException>(() => validationEngine.Validate(totoItem));
        }

        [Fact]
        public async Task Get_ValidInput_Success()
        {
            var todoItem = ValidTodoItem(_fixture);
            _todoRepository.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(todoItem);

            var output = await TodoItem.Get(_todoRepository.Object, _fixture.Create<int>());

            Assert.NotNull(output);
            Assert.Equal(todoItem, output);
        }

        [Fact]
        public async Task Get_InvalidInput_ThrowsNotFoundException()
        {
            _todoRepository.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync((TodoItem?)null);

            await Assert.ThrowsAsync<DataNotFoundException>(() => TodoItem.Get(_todoRepository.Object, _fixture.Create<int>()));
        }

        [Fact]
        public async Task GetAll_ValidInput_Success()
        {
            var todoItems = TodoItemsList(_fixture);
            _todoRepository.Setup(x => x.GetAll()).ReturnsAsync(todoItems);

            var output = await TodoItem.GetAll(_todoRepository.Object);

            Assert.NotNull(output);
            Assert.Equal(todoItems, output);
        }

        [Fact]
        public async Task GetPending_ValidInput_Success()
        {
            var todoItems = TodoItemsList(_fixture);
            _todoRepository.Setup(x => x.GetPending()).ReturnsAsync(todoItems);

            var output = await TodoItem.GetPending(_todoRepository.Object);

            Assert.NotNull(output);
            Assert.Equal(todoItems, output);
        }

        [Fact]
        public async Task Update_ValidInput_Success()
        {
            _todoRepository.Setup(x => x.Update(It.IsAny<TodoItem>())).ReturnsAsync(true);
            var student = ValidTodoItem(_fixture);
            var output = await student.Update(_todoRepository.Object, _validationEngine.Object);

            Assert.True(output);
        }

        private static TodoItem ValidTodoItem(Fixture fixture) =>
            TodoItem.Create(fixture.Create<int>(), fixture.Create<string>(), fixture.Create<string>());

        private static List<TodoItem> TodoItemsList(Fixture fixture) => Enumerable.Range(1, 10).Select(s => ValidTodoItem(fixture)).ToList();


    }
}