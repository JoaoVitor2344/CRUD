using Microsoft.Data.SqlClient;

namespace ConsoleApp1.Database
{
    internal class Connection : IDisposable
    {
        private const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private readonly SqlConnection _connection = new(ConnectionString);

        public void OpenConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            CloseConnection();
            _connection.Dispose();
        }

        public void ExecuteNonQuery(string query)
        {
            using SqlCommand command = _connection.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
        }
    }
}