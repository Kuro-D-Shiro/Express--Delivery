using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace BruhMobilApp
{
    public class DeliverDB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=123456Йцукен;database=DeliverDB");

        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection() {  return connection; }

    }
}
