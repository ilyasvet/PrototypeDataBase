using System;
using PrototypeDbLibrary;

namespace PrototypeDataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DbLocalConnection connection = new DbLocalConnection("TelegramBotPrototypeDb"))
            {
                using (LocalSqlCommandAccounts commandAccounts = new LocalSqlCommandAccounts(connection))
                {
                    //Какие-то операторы...
                }
            }
        }
    }
}
