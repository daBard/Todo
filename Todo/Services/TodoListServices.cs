namespace Todo.Services;

using Todo.Models;

//interface ITodoListServices
//{
//    List<Todo> todoList {  get; set; }
//    void AddTodoItem(Todo todo) { }
//    void DoneTodoItem(int option) { }
//    void DeleteTodoItem(int option) { }

//    List<Todo> GetTodoList() { }
//}

public class TodoListServices
{
    internal List<Todo> todoList = [];

    public void AddTodoItem(string todoText) 
    {
        
        Todo newTodo = new()
        {
            text = todoText
        };
        todoList.Add(newTodo);
    }
    public void DoneTodoItem(int option) 
    {
        option = option - 1;
        if(option < todoList.Count() && !todoList[option].done)
        {
            todoList[option].done = true;
        }
        else
        {
            Console.WriteLine("Not a valid item.");
            Console.ReadKey();
        }
    }
    public void DeleteTodoItem(int option) 
    {
        option = option - 1;
        if (option < todoList.Count() && !todoList[option].done)
        {
            todoList.RemoveAt(option);
        }
        else
        {
            Console.WriteLine("Not a valid item.");
            Console.ReadKey();
        }
    }

    public void ClearDoneList()
    {
        todoList.RemoveAll(todo => todo.done);
    }

    public List<Todo> GetTodoList() { return todoList; }
}
