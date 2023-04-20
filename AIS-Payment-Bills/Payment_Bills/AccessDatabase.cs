using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Payment_Bills
{
    class AccessDatabase
    {
        private OleDbConnection _connection;
        private string _connectionString;

        public AccessDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void OpenConnection()
        {
            _connection = new OleDbConnection(_connectionString);
            _connection.Open();
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            OleDbCommand command = new OleDbCommand(query, _connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
