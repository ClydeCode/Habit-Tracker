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
                    @"CREATE TABLE IF NOT EXISTS stepsPerDay (
						Id INTEGER PRIMARY KEY AUTOINCREMENT,
						Date TEXT,
						Quantity INTEGER
					)";

                command.ExecuteNonQuery();
            }
        }
    }

    internal void Insert(string date, int quantity)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $@"INSERT INTO stepsPerDay 
                        (Date, Quantity)
                        VALUES
                        ('{date}', {quantity})";

                command.ExecuteNonQuery();
            }
        }
    }

    internal string Read()
    {
        string result = "";

        using (var connection = new SqliteConnection(connectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $@"SELECT * FROM stepsPerDay";

                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = ($"ID: {reader.GetString(0)}       DATE: {reader.GetString(1)}       QUANTITY: {reader.GetString(2)}");
                }
            }
        }
        return result;
    }

    internal void Update(int id, string date, int quantity)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $@"UPDATE stepsPerDay SET Date='{date}', Quantity={quantity} WHERE Id={id}";

                command.ExecuteNonQuery();
            }
        }
    }

    internal void Delete(int id)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $@"DELETE FROM stepsPerDay WHERE Id={id}";

                command.ExecuteNonQuery();
            }
        }
    }
}
