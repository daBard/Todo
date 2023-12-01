namespace Todo.Services;

using Todo.Models;
using System.Linq;

interface ITodoListServices
{
    List<Todo> todoList { get; }
    void AddTodoItem(Todo todo);
    void DoneTodoItem(int option);
    void UpdateTodoItem(int option);
    void DeleteTodoItem(int option);
    void ClearDoneList();
    List<Todo> GetTodoList();
    void SortList();
}

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
            SortTodoList();
        }
        else
        {
            Console.WriteLine("Not a valid item.");
            Console.ReadKey();
        }
    }

    public void UpdateTodoItem(int option)
    {
        option = option - 1;
        if (option < todoList.Count() && !todoList[option].done)
        {
            Console.WriteLine($"Previous value: {todoList[option].text}");
            Console.Write("New value: ");
            todoList[option].text = Console.ReadLine()!;
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

    public List<Todo> GetTodoList() {
        return todoList;
    }

    internal void SortTodoList()
    {
        todoList = todoList.OrderBy(e => e.done).ToList();
    }
}
