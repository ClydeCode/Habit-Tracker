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
						Date DATE,
						Quantity INTEGER
					)";

                command.ExecuteNonQuery();
            }
        }
    }

    internal void Insert(DateTime date, int quantity)
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

    internal List<string> Read()
    {
        List<string> list = new List<string>();

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
                    list.Add($"ID: {reader.GetString(0)}       DATE: {reader.GetString(1)}       QUANTITY: {reader.GetString(2)}");
                }
            }
        }
        return list;
    }

    internal string ReadById(int id)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $@"SELECT * FROM stepsPerDay WHERE Id={id}";

                SqliteDataReader reader = command.ExecuteReader();

                try
                {
                    reader.Read();

                    return reader.GetString(0);
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        return null;
    }

    internal void Update(int id, int quantity)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $@"UPDATE stepsPerDay SET Quantity={quantity} WHERE Id={id}";

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
