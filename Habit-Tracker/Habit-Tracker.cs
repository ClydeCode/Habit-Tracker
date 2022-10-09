
internal class Habit_Tracker
{
    private Database database = new Database();

    internal Habit_Tracker()
    {
        database.CreateDatabase();
    }

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
                handleRead();
                break;
            case 2:
                Console.Clear();
                handleInsert();
                break;
            case 3:
                Console.Clear();
                handleDelete();
                break;
            default:
                Console.WriteLine("Wrong Input!");
                break;
        }
    }

    private void handleRead()
    {
        foreach (string result in database.Read()) { Console.WriteLine(result); }
    }

    private void handleInsert()
    {
        DateTime date = Helpers.getDate();

        Console.WriteLine("Type [QUANTITY]:");
        int quantity = Helpers.getInt();

        database.Insert(date, quantity);
    }

    private void handleDelete()
    {
        Console.WriteLine("Type [ID]: ");
        int id = Helpers.getInt();

        database.Delete(id);
    }
}

