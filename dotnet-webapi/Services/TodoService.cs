using System.Collections.Generic;

namespace dotnet_webapi
{
    internal class TodoService : ITodo
    {
        private ITodoRepository todoRepository;
        public TodoService(ITodoRepository _todoRepository)
        {
            todoRepository = _todoRepository;
        }
        public int AddTodo(TodoModel todoItem)
        {
            return todoRepository.AddTodo(todoItem);
        }

        public bool DeleteTodo(string id)
        {
            return todoRepository.DeleteTodo(id);
        }

        public List<TodoModel> GetTodos()
        {
            return todoRepository.GetTodos();
        }
    }
}