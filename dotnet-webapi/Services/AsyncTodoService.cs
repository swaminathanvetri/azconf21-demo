using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_webapi
{
    internal class AsyncTodoService : IAsyncTodoService
    {
        private IAsyncTodoRepository todoRepository;
        public AsyncTodoService(IAsyncTodoRepository _todoRepository)
        {
            todoRepository = _todoRepository;
        }
        public async Task AddTodo(TodoModel todoItem)
        {
            await todoRepository.AddTodo(todoItem);
        }

        public async Task<bool> DeleteTodo(string id)
        {
            return await todoRepository.DeleteTodo(id);
        }

        public async Task<List<TodoModel>> GetTodos()
        {
            return await todoRepository.GetTodos();
        }
    }
}