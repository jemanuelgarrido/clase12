using Microsoft.Data.Sqlite;

void readTable(String id)
{
    using (var connection = new SqliteConnection("Data Source=hello.db"))
    {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        @"
        SELECT name
        FROM user
        WHERE id = $id
    ";
        command.Parameters.AddWithValue("$id", id);

        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var name = reader.GetString(0);

                Console.WriteLine($"Hello, {name}!");
            }
        }
    }
}

//crate table user
void createTable()
{
    using (var connection = new SqliteConnection("Data Source=hello.db"))
    {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText =
        @"
        CREATE TABLE user (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            name TEXT
        );
    ";
        command.ExecuteNonQuery();
    }
}

//update table user
void updateTable(String id, String name)
{
    using (var connection = new SqliteConnection("Data Source=hello.db"))
    {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText =
        @"
        UPDATE user
        SET name = $name
        WHERE id = $id
    ";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$name", name);
        command.ExecuteNonQuery();
    }
}



void deleteTable(String id)
{
    using (var connection = new SqliteConnection("Data Source=hello.db"))
    {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText =
        @"
        DELETE FROM user
        WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }
}



void insertTable(String name)
{
    using (var connection = new SqliteConnection("Data Source=hello.db"))
    {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText =
        @"
        INSERT INTO user (name)
        VALUES ($name)";
        command.Parameters.AddWithValue("$name", name);
        command.ExecuteNonQuery();
    }
}

//read all records
void readAllrecords()
{
    using (var connection = new SqliteConnection("Data Source=hello.db"))
    {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText =
        @"
        SELECT id, name
        FROM user
    ";
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                Console.WriteLine($"{id} - {name}");
            }
        }
    }
}
/*createTable();
insertTable("Ana");
insertTable("Carlos");
insertTable("Fernando");

readAllrecords();
deleteTable("3");
deleteTable("9");
Console.WriteLine("after delete");*/
Console.ReadLine();
