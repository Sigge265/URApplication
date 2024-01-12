using System.Data.SqlClient;

namespace Project
{
    public class LoginManager
    {
        private string _connectionString;

        public LoginManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool ValidateLogin(UserCredentials credentials)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // Prepare a SQL command to search for the user in the database
                    string query = "SELECT COUNT(1) FROM Login WHERE Name = @username AND Password = @password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", credentials.Username);
                        command.Parameters.AddWithValue("@password", credentials.Password);

                        int userExists = (int)command.ExecuteScalar();

                        return userExists > 0;

                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Database error: " + ex.Message);
                }
            }
        }
    }
}
