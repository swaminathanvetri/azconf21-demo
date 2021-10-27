using System.Collections.Generic;

namespace dotnet_webapi
{
    public interface ITodoRepository
    {
        public int AddTodo(TodoModel item);
        public bool DeleteTodo(string id);
        public List<TodoModel> GetTodos();
    }
}