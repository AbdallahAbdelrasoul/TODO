using Microsoft.AspNetCore.Mvc;
using TODO.Application.TodoItems;
using TODO.Application.TodoItems.DTOs;
using TODO.Domain.Shared.Exceptions;
using TODO.Presentation.ExceptionHandlers;

namespace TODO.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoItemsService _todoItemsService;
        private readonly ITodoItemsQueryService _todoItemsQueryService;
        public TodoController(ITodoItemsService todoItemsService, ITodoItemsQueryService todoItemsQueryService)
        {
            _todoItemsService = todoItemsService;
            _todoItemsQueryService = todoItemsQueryService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TodoItemDTO), 201)]
        [ProducesResponseType(typeof(HttpException), TODOHttpStatusCodes.DataNotValid)]
        public async Task<CreatedResult> Create([FromBody] TodoItemCreateDTO request)
        {
            var output = await _todoItemsService.Create(request);
            return Created("api/todo/" + output.Id, output);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TodoItemDTO>), 200)]
        public async Task<ActionResult<List<TodoItemDTO>>> GetAllTodoItems()
        {
            return Ok(await _todoItemsQueryService.GetAll());
        }


        [HttpGet("pending")]
        [ProducesResponseType(typeof(List<TodoItemDTO>), 200)]
        public async Task<ActionResult<List<TodoItemDTO>>> GetPendingTodoItems()
        {
            return Ok(await _todoItemsQueryService.GetPending());
        }


        [HttpGet("{id}/complete")]
        [ProducesResponseType(typeof(TodoItemDTO), 200)]
        [ProducesResponseType(typeof(HttpException), TODOHttpStatusCodes.DataNotFound)]
        [ProducesResponseType(typeof(HttpException), TODOHttpStatusCodes.DataNotValid)]
        public async Task<ActionResult<TodoItemDTO>> GetAllTodoItems([FromRoute] int id)
        {
            return Ok(await _todoItemsService.MarkAsCompleted(id));
        }



    }
}
