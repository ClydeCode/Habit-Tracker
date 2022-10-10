
class Helpers
{
    internal static int getInt()
    {
        int number = -1;

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

    internal static DateTime getDate()
    {
        DateTime date = DateTime.Now;

        return date;
    }
}

