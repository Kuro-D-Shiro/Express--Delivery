
using BruhMobilApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;


namespace BruhMobilApp
{
    public class DeliverDB
    {
        private MySqlConnection connection;

        public DeliverDB(string server = "db4free.net",
        string port = "3306",
        string username = "deliver_db",
        string password = "123456Qwerty",
        string database = "deliver_istu_db")
        {
            connection = new MySqlConnection($"server={server};port={port};username={username};password={password};database={database}");
        }

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
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

        public void AddUser(User user)
        {
            var SQLCommand = "INSERT INTO `User` (`name`, `password`, `email`, `number`, `role`, `status`)" +
                " VALUES (@name, @password, @email, @number, @role, 'free')";
            var command = new MySqlCommand(SQLCommand, connection);

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = user.Name;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.Password;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.Email;
            command.Parameters.Add("@number", MySqlDbType.VarChar).Value = user.Number;
            command.Parameters.Add("@role", MySqlDbType.VarChar).Value = user.Role;

            command.ExecuteNonQuery();

            command = new MySqlCommand("SELECT * FROM `User` WHERE `name` = @name", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = user.Name;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            var row = table.Rows[0];

            var id = row.ItemArray[0].ToString();
            user.Id = int.Parse(id);
        }

        public void AddUser(Deliverman deliverman)
        {
            AddUser((User)deliverman);
            var SQLCommand = "UPDATE `User` SET `status` = @status WHERE `User`.`ID` = @id";
            var command = new MySqlCommand(SQLCommand, connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = deliverman.Id.ToString();
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = deliverman.Status;
            command.ExecuteNonQuery();
        }

        public bool ChekUser(int id)
        {
            var command = new MySqlCommand("SELECT * FROM `User` WHERE ID` = @id", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count != 0;
        }

        public void DeleteUsers(int id)
        {
            var SQLCommand = "DELETE FROM User WHERE `User`.`ID` = @id";
            var command = new MySqlCommand(SQLCommand, connection);
            if (!ChekUser(id))
            {
                throw new Exception("Cant find a user in DataBase");
            }
            else
            {
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateUser(int id, string name = "", string email = "", string password = "", string number = "", string role = "", string status = "")
        {
            if (!ChekUser(id))
            {
                throw new Exception("Cant find a user in DataBase");
            }
            else
            {
                var user = ReadUser(id);
                name = name == "" ? user["name"] : name;
                email = email == "" ? user["email"] : email;
                password = password == "" ? user["password"] : password;
                number = number == "" ? user["number"] : number;
                role = role == "" ? user["role"] : role;
                status = status == "" ? user["status"] : status;

                var command = new MySqlCommand("UPDATE `User` SET `name` = @name, `password` = @password, `email` = @email, `number` = @number, `role` = @role', `status` = @status" +
                    " WHERE `name` = @name ;", connection);

                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                command.Parameters.Add("@number", MySqlDbType.VarChar).Value = number;
                command.Parameters.Add("@role", MySqlDbType.VarChar).Value = role;
                command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
                command.Parameters.Add("@userID", MySqlDbType.Int64).Value = Convert.ToInt64(id);

                command.ExecuteNonQuery();
            }
        }

        public Dictionary<string, string> ReadUser(int id)
        {
            var command = new MySqlCommand("SELECT * FROM `User` WHERE `id` = @id", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            var user = new Dictionary<string, string>();
            var row = table.Rows[0];

            user.Add("id", row.ItemArray[0].ToString());
            user.Add("name", row.ItemArray[1].ToString());
            user.Add("password", row.ItemArray[2].ToString());
            user.Add("email", row.ItemArray[3].ToString());
            user.Add("number", row.ItemArray[4].ToString());
            user.Add("role", row.ItemArray[5].ToString());
            user.Add("status", row.ItemArray[6].ToString());
            return user;
        }

        public void AddPackege()
        {

        }
        public void DeletePackage()
        {

        }
        public void UpdatePackage()
        {

        }
        public void ReadPackage(int id)
        {
            var command = new MySqlCommand("SELECT * FROM `Package` WHERE `id` = @id", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {
                throw new Exception("Cant find a package in DataBase");
            }
            else
            {
                var package = new Dictionary<string, string>();
                var row = table.Rows[0];

                package.Add("id", row.ItemArray[0].ToString());
                package.Add("startAddres", row.ItemArray[1].ToString());
                package.Add("endAddres", row.ItemArray[2].ToString());
                package.Add("size", row.ItemArray[3].ToString());
                package.Add("comment", row.ItemArray[4].ToString());
                package.Add("time", row.ItemArray[5].ToString());
                package.Add("cost", row.ItemArray[6].ToString());
                package.Add("status", row.ItemArray[7].ToString());
                foreach (var val in package.Values)
                    MessageBox.Show(val);
            }
        }
    }
}
*/