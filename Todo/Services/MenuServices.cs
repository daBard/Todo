using System.Diagnostics;

namespace Todo.Services;

using Todo.Models;

interface IMenuServices
{
    public void DisplayMenu();
    public void DisplayTitle(string title) { }

    public void DisplayList() { }
    public void DisplayOptions() { }
}

internal class MenuServices : IMenuServices
{
    TodoListServices todoListServices = new TodoListServices();
   
    internal void DisplayOptions()
    {
        Console.WriteLine("### TODO MENU OPTIONS ###");
        Console.WriteLine($"{"1.",-3} Add item");
        Console.WriteLine($"{"2.",-3} Set item as done");
        Console.WriteLine($"{"3.",-3} Change item");
        Console.WriteLine($"{"4.",-3} Delete item");
        Console.WriteLine($"{"5.",-3} Clear done list");
        Console.WriteLine($"{"0.",-3} Exit Application");
        Console.WriteLine("");
        
       
        string option = Console.ReadKey(true).KeyChar.ToString();

        switch (option)
        {
            case "1":
                DisplayTitle("ADD NEW ITEM");
                Console.Write("New item to add: ");
                string newText = Console.ReadLine()!;
                todoListServices.AddTodoItem(newText);
                DisplayMenu();
                break;

            case "2":
                DisplayTitle("DONE ITEM");
                DisplayTodoList();
                Console.Write("Which item is done: ");
                string doneItem = Console.ReadLine()!;
                if(int.TryParse(doneItem, out _))
                {
                    todoListServices.DoneTodoItem(int.Parse(doneItem));
                }
                else
                {
                    Console.WriteLine("Not a valid item.");
                    Console.ReadKey();
                }
                break;

            case "3":
                DisplayTitle("UPDATE ITEM");
                DisplayTodoList();
                Console.Write("Which item do you want to update: ");
                string updateItem = Console.ReadLine()!;
                if (int.TryParse(updateItem, out _))
                {
                    todoListServices.UpdateTodoItem(int.Parse(updateItem));
                }
                else
                {
                    Console.WriteLine("Not a valid item.");
                    Console.ReadKey();
                }
                break;

            case "4":
                DisplayTitle("DELETE ITEM");
                DisplayTodoList();
                Console.Write("Which item do you want to delete: ");
                string deleteItem = Console.ReadLine()!;
                if (int.TryParse(deleteItem, out _))
                {
                    if(AreYouSure())
                        todoListServices.DeleteTodoItem(int.Parse(deleteItem));
                }
                else
                {
                    Console.WriteLine("Not a valid item.");
                    Console.ReadKey();
                }
                break;

            case "5":
                Console.WriteLine("Clear done list");
                if(AreYouSure())
                    todoListServices.ClearDoneList();
                break;
            case "0":
                Console.WriteLine("Exit app");
                if (AreYouSure())
                    Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Not a valid option.");
                Console.ReadKey();
                break;
        }
        DisplayMenu();
    }

    public void DisplayTodoList() 
    {
        List<Todo> todoList = todoListServices.GetTodoList();

        try
        {
            if (todoList.Any())
            {
                Console.WriteLine("----- TODO LIST -----");
                int i = 1;
                foreach (Todo item in todoList)
                {
                    if (!item.done)
                    {
                        Console.WriteLine($"{i,-3} {item.text}");
                    }
                    i++;
                }

                Console.WriteLine("");
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    internal void DisplayDoneList()
    {
        List<Todo> todoList = todoListServices.GetTodoList();

        try
        {
            if (todoList.Any())
            {
                Console.WriteLine("----- DONE LIST -----");
               
                foreach (Todo item in todoList)
                {
                    if (item.done)
                    {
                        Console.WriteLine($"{"X",-3} {item.text}");
                    }
                }

                Console.WriteLine("");


            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    internal void DisplayTitle(string _title = "TODO LIST APP")
    {
        Console.Clear();
        Console.WriteLine($"##### {_title}  #####");
    }

    static bool AreYouSure()
    {
        Console.Write("Are you sure? Y/N ");
        string ans = Console.ReadLine()!;
        if (ans.ToLower() == "y") 
        {
            return true;
        }
        else
        {
            return false;
        }   
    }

    public void DisplayMenu()
    {
        DisplayTitle();
        DisplayTodoList();
        DisplayDoneList();
        DisplayOptions();
    }
}
