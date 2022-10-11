Habit_Tracker habit_tracker = new Habit_Tracker();

while (true)
{
    habit_tracker.ShowMenu();

    habit_tracker.Navigate(Helpers.GetInt());

    Console.WriteLine("\nPress ENTER to Continue...");
    Console.ReadLine();
}