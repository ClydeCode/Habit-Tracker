﻿
internal class Habit_Tracker
{
    private Database database = new Database();

    internal void showMenu()
    {
        Console.Clear();
        Console.WriteLine("\nMain Menu");
        Console.WriteLine("\nWhat would you like to do:");
        Console.WriteLine("\nType 0 To Close Application");
        Console.WriteLine("Type 1 To View All Records");
        Console.WriteLine("Type 2 To Insert Record");
        Console.WriteLine("Type 3 To Delete Record");
        Console.WriteLine("Type 4 To Update Record");
    }

    internal void navigate(int number)
    {
        switch (number)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                Console.Clear();
                Console.WriteLine(database.Read());
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Type: <Date>, <Quantity>");
                break;
            case 3:

                break;
            case 4:

                break;
            default:
                Console.WriteLine("Wrong Input!");
                break;
        }
    }
}
