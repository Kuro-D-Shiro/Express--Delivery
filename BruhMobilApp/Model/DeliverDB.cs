using BruhMobilApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;

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

        public void AddUser()
        {

        }
        public void RemoveUsers()
        {

        }
        public void UpdateUser()
        {

        }
        public void ReadUser(string userName)
        {
            var command = new MySqlCommand($"SELECT * FROM `User` WHERE `name` = @userName", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            command.Parameters.Add("@userName", MySqlDbType.VarChar).Value = userName;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {
                throw new Exception("Cant find a user in DataBase");
            }
            else
            {
                var row = table.Rows[0];
                var id = row.Field<int>("ID");
                var name = row.Field<string>("name");
                var password = row.Field<string>("password");
            }
        }

        public void AddPackege()
        {

        }
        public void RemovePachage()
        {

        }
        public void UpdatePackage()
        {

        }
    }
}
