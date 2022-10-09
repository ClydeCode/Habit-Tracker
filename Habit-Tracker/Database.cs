using Microsoft.Data.Sqlite;

class Database
{
    private string connectionString = @"Data Source=habit-Tracker.db";

    internal void CreateDatabase()
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS yourHabit (
						Id INTEGER PRIMARY KEY AUTOINCREMENT
						Date TEXT
						Quantity INTEGER
					)";

                command.ExecuteNonQuery();
            }
        }
    }
}
