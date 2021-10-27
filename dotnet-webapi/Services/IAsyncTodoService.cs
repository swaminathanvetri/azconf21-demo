using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAsyncTodoService
{
    public Task AddTodo(TodoModel todoItem);
    public Task<bool> DeleteTodo(string id);
    public Task<List<TodoModel>> GetTodos();
}