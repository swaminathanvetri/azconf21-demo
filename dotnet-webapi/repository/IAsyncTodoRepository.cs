using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_webapi
{
    public interface IAsyncTodoRepository
    {
        public Task AddTodo(TodoModel item);
        public Task<bool> DeleteTodo(string id);
        public Task<List<TodoModel>> GetTodos();
    }
}