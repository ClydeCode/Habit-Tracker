
internal class Habit_Tracker
{
    private readonly Database database = new();

    internal Habit_Tracker()
    {
        database.CreateDatabase();
    }

    internal void ShowMenu()
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

    internal void Navigate(int number)
    {
        switch (number)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                Console.Clear();
                HandleRead();
                break;
            case 2:
                Console.Clear();
                HandleInsert();
                break;
            case 3:
                Console.Clear();
                HandleDelete();
                break;
            case 4:
                Console.Clear();
                HandleUpdate();
                break;
            default:
                Console.WriteLine("Wrong Input!");
                break;
        }
    }

    private void HandleRead()
    {
        foreach (string result in database.Read()) { Console.WriteLine(result); }
    }

    private void HandleInsert()
    {
        DateTime date = Helpers.GetDate();

        Console.WriteLine("Type [QUANTITY]:");
        int quantity = Helpers.GetInt();

        database.Insert(date, quantity);
    }

    private void HandleDelete()
    {
        Console.WriteLine("Type [ID]: ");
        int id = Helpers.GetInt();

        if (RecordExist(id)) database.Delete(id);
    }

    private void HandleUpdate()
    {
        Console.WriteLine("Type [ID]: ");
        int id = Helpers.GetInt();
        int quantity;

        if (RecordExist(id))
        {
            Console.WriteLine("Type [QUANTITY]: ");
            quantity = Helpers.GetInt();

            database.Update(id, quantity);
        }
    }

    private bool RecordExist(int id)
    {
        string result = database.ReadById(id);

        return result != null;
    }
}

