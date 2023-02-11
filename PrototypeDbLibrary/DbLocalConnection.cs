using System;
using System.Data.SqlClient;

namespace PrototypeDbLibrary
{
    public class DbLocalConnection : IDisposable
    {
        private SqlConnection _connection;
        private string _connectionString;

        public SqlConnection Connection
        {
            get { return _connection; }
        }
        public DbLocalConnection(string dataBaseName, string serverName = "localhost\\SQLEXPRESS")
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                InitialCatalog = dataBaseName,
                DataSource = serverName,
                ConnectTimeout = 30,
                IntegratedSecurity = true,
            };
            _connectionString = builder.ConnectionString;

            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public void ShowConnectionData()
        {
            Console.WriteLine($"Database name : {_connection.Database}");
            Console.WriteLine($"Connection state : {_connection.State}");
            Console.WriteLine($"Workstation Id : {_connection.WorkstationId}");
            Console.WriteLine($"Timeout : {_connection.ConnectionTimeout}");
        }
        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
