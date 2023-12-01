namespace Todo.Models;

internal interface ITodo
{ 
    bool done { get; set; }
    string text { get; set; }
}

public class Todo : ITodo
{
    public bool done { get; set; } = false;
    public string text { get; set; } = "Default";
}
