
class Helpers
{
    internal static int GetInt()
    {
        int number = -1;

        Console.WriteLine("\n");

        while (number < 0)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int proper_input) && Convert.ToInt32(input) >= 0) 
            {
                number = proper_input; 
            }
            else Console.WriteLine("Wrong Input! Try again...");
        }
        return number;
    }

    internal static DateTime GetDate()
    {
        DateTime date = DateTime.Now;

        return date;
    }
}

