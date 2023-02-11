using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Data.SqlClient;

namespace PrototypeDbLibrary
{
    public class LocalSqlCommandAccounts : IDisposable
    {
        private SqlCommand _sqlCommand;
        
        public LocalSqlCommandAccounts(DbLocalConnection localConnection)
        {
            _sqlCommand = new SqlCommand();
            _sqlCommand.Connection = localConnection.Connection;
        }
        
        public Account GetAccountById(int id)
        {
            string commandText = $"select * from Accounts where ID = {id}";
            _sqlCommand.CommandText = commandText;

            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            
            while (sqlDataReader.Read())
            {
                Account account = new Account((int)sqlDataReader[0],
                    (string)sqlDataReader[1],
                    (string)sqlDataReader[2],
                    (Access)sqlDataReader[3]);
                return account;
            }
            return null;
        }
        public bool SearchAccountById(int id)
        {
            return GetAccountById(id) != null;
        }
        public void AddAccount(string FirstName, string LastName, Access access)
        {
            string commandText = $"insert into Accounts (FirstName, LastName, Access)" +
                $" values ('{FirstName}','{LastName}','{(int)access}')";
            ExecuteNonQueryCommand(commandText);
        }
        public void AddAccount(Account account)
        {
            AddAccount(account.FirstName, account.LastName, account.Access);
        }
        public void AddRangeOfAccounts(IEnumerable accounts)
        {
            foreach (Account account in accounts)
            {
                AddAccount(account);
            }
        }
        public void DeleteAccountById(int id)
        {
            string commandText = $"delete from Accounts where id = {id}";
            ExecuteNonQueryCommand(commandText);
        }
        public void ChangeAccessById(int id, Access access)
        {
            string commandText = $"update Accounts set Access = {(int)access} where id = {id}";
            ExecuteNonQueryCommand(commandText);
        }
        public void Dispose()
        {
            _sqlCommand.Dispose();
        }
        private void ExecuteNonQueryCommand(string commandText)
        {
            _sqlCommand.CommandText = commandText;
            _sqlCommand.ExecuteNonQuery();
        }
    }
}
