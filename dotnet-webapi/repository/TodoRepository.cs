using System.Collections.Generic;
using System.Linq;

namespace dotnet_webapi
{
    public class TodoRepository : ITodoRepository
    {
        public int AddTodo(TodoModel item)
        {
            using (var context = new TodoContext())
            {
                context.Todos.Add(item);
                return context.SaveChanges();
            }
        }

        public bool DeleteTodo(string id)
        {
            using (var context = new TodoContext())
            {
                var itemToDelete = context.Todos.Find("Id", id);
                context.Todos.Remove(itemToDelete);
                context.SaveChanges();
            }
            return true;
        }

        public List<TodoModel> GetTodos()
        {
            using (var context = new TodoContext())
            {
                return context.Todos.ToList();
            }
        }
    }
}