using System.Collections.Generic;

public interface ITodo
{
    public int AddTodo(TodoModel todoItem);
    public bool DeleteTodo(string id);
    public List<TodoModel> GetTodos();
}