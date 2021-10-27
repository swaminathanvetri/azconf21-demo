using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        //private ITodo todoService;
        private IAsyncTodoService todoService;

        public TodoController(IAsyncTodoService _todoService)
        {
            todoService = _todoService;
        }
        [HttpPost]
        public async Task<ActionResult> AddTodo(TodoModel todo)
        {
            await todoService.AddTodo(todo);
            return Created($"/todo/{todo.Id}",todo);
        }
        [HttpGet]
        public async Task<List<TodoModel>> Get()
        {
            return await todoService.GetTodos();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            var response = await todoService.DeleteTodo(id);
            return NoContent();
        }
    }
}