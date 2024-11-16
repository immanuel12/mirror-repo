using System.Data.SqlClient;

public class SqlInjectionExample
{
    public void ExecuteQuery(string userInput)
    {
        string connectionString = "your_connection_string_here";
        SqlConnection connection = new SqlConnection(connectionString);
        string query = "SELECT * FROM Users WHERE UserName = '" + userInput + "'";  // Vulnerable to SQL Injection
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();
        command.ExecuteReader();
    }
}