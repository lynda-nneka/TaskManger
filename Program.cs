using System;
using TaskManager;

class Program
{
    static void Main(string[] args)
    {
        var taskManager = new TaskManagerClass();
        taskManager.Run();

        Console.ReadKey();
    }
}