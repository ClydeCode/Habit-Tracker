Habit_Tracker habit_tracker = new Habit_Tracker();

while (true)
{
    habit_tracker.showMenu();

    habit_tracker.navigate(Helpers.getInt());

    Console.WriteLine("\nPress ENTER to Continue...");
    Console.ReadLine();
}