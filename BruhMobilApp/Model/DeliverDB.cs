
using BruhMobilApp.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BruhMobilApp
{
    public class DeliverDB
    {
        private MySqlConnection connection;

        // Конструктор класса, инициализирующий подключение к базе данных с заданными параметрами
        public DeliverDB(string server = "db4free.net",
                         string port = "3306",
                         string username = "deliver_db",
                         string password = "123456Qwerty",
                         string database = "deliver_istu_db")
        {
            connection = new MySqlConnection($"server={server};port={port};username={username};password={password};database={database}");
        }

        // Метод для открытия соединения с базой данных
        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Метод для закрытия соединения с базой данных
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Метод для добавления пользователя в базу данных
        public void AddUser(User user)
        {
            // SQL-команда для добавления записи в таблицу User
            var SQLCommand = "INSERT INTO `User` (`name`, `password`, `email`, `number`, `role`, `status`)" +
                             " VALUES (@name, @password, @email, @number, @role, 'free')";
            var command = new MySqlCommand(SQLCommand, connection);

            // Параметры для SQL-команды
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = user.Name;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.Password;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.Email;
            command.Parameters.Add("@number", MySqlDbType.VarChar).Value = user.Number;
            command.Parameters.Add("@role", MySqlDbType.VarChar).Value = user.Role;

            // Выполнение SQL-команды
            command.ExecuteNonQuery();

            // Получение добавленного пользователя
            command = new MySqlCommand("SELECT * FROM `User` WHERE `name` = @name", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = user.Name;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            var row = table.Rows[0];

            // Получение ID добавленного пользователя
            var id = row.ItemArray[0].ToString();
            user.Id = int.Parse(id);
        }

        // Метод для добавления доставщика в базу данных
        public void AddUser(Deliverman deliverman)
        {
            // Добавление пользователя как базового класса User
            AddUser((User)deliverman);

            // SQL-команда для обновления статуса пользователя
            var SQLCommand = "UPDATE `User` SET `status` = @status WHERE `User`.`ID` = @id";
            var command = new MySqlCommand(SQLCommand, connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = deliverman.Id.ToString();
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = deliverman.Status;

            // Выполнение SQL-команды
            command.ExecuteNonQuery();
        }

        // Метод для проверки существования пользователя по ID
        public bool CheckUser(int id)
        {
            var command = new MySqlCommand("SELECT * FROM `User` WHERE `id` = @id", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count != 0;
        }

        // Метод для проверки существования пользователя по имени
        public bool CheckUser(string name)
        {
            var command = new MySqlCommand("SELECT * FROM `User` WHERE `name` = @name", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count != 0;
        }

        // Метод для удаления пользователя по ID
        public void DeleteUser(int id)
        {
            if (!CheckUser(id))
            {
                throw new Exception("Не удалось найти пользователя в базе данных");
            }
            else
            {
                var command = new MySqlCommand("DELETE FROM `User` WHERE `id` = @id", connection);
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
                command.ExecuteNonQuery();
            }
        }

        // Метод для обновления информации о пользователе
        public void UpdateUser(int id, string name = "", string email = "", string password = "", string number = "", string role = "", string status = "")
        {
            if (!CheckUser(id))
            {
                throw new Exception("Не удалось найти пользователя в базе данных");
            }
            else
            {
                // Чтение информации о пользователе
                var user = ReadUser(id);

                // Установка новых значений или оставление текущих
                name = name == "" ? user["name"] : name;
                email = email == "" ? user["email"] : email;
                password = password == "" ? user["password"] : password;
                number = number == "" ? user["number"] : number;
                role = role == "" ? user["role"] : role;
                status = status == "" ? user["status"] : status;

                // SQL-команда для обновления данных пользователя
                var command = new MySqlCommand("UPDATE `User` SET `name` = @name, `password` = @password, `email` = @email, `number` = @number, `role` = @role, `status` = @status WHERE `id` = @id", connection);

                // Параметры для SQL-команды
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                command.Parameters.Add("@number", MySqlDbType.VarChar).Value = number;
                command.Parameters.Add("@role", MySqlDbType.VarChar).Value = role;
                command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;

                // Выполнение SQL-команды
                command.ExecuteNonQuery();
            }
        }

        // Метод для чтения информации о пользователе по ID
        public Dictionary<string, string> ReadUser(int id)
        {
            var command = new MySqlCommand("SELECT * FROM `User` WHERE `id` = @id", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            // Создание словаря для хранения данных о пользователе
            var user = new Dictionary<string, string>();
            if (CheckUser(id))
            {
                var row = table.Rows[0];
                user.Add("id", row.ItemArray[0].ToString());
                user.Add("name", row.ItemArray[1].ToString());
                user.Add("password", row.ItemArray[2].ToString());
                user.Add("email", row.ItemArray[3].ToString());
                user.Add("number", row.ItemArray[4].ToString());
                user.Add("role", row.ItemArray[5].ToString());
                user.Add("status", row.ItemArray[6].ToString());
            }
            else
            {
                throw new Exception("Не удалось найти пользователя в базе данных");
            }
            return user;
        }

        // Метод для чтения информации о пользователе по имени
        public Dictionary<string, string> ReadUser(string name)
        {
            var command = new MySqlCommand("SELECT * FROM `User` WHERE `name` = @name", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            // Создание словаря для хранения данных о пользователе
            if (!CheckUser(name))
            {
                throw new Exception("Не удалось найти пользователя в базе данных");
            }
            else
            {
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
        }

        // Метод для получения объекта пользователя по ID
        public User GetUser(int id)
        {
            // Получение данных о пользователе из базы данных
            var UserData = ReadUser(id);

            // Создание объекта пользователя
            var user = new User(UserData["name"], UserData["email"], UserData["password"], UserData["number"], UserData["role"]);
            user.Id = id;
            user.Packages = GetUserPackages(id);

            return user;
        }

        // Метод для получения объекта пользователя по имени
        public User GetUser(string name)
        {
            // Получение данных о пользователе из базы данных
            var userData = ReadUser(name);

            // Создание объекта пользователя
            var user = new User(userData["name"], userData["email"], userData["password"], userData["number"], userData["role"]);
            user.Id = int.Parse(userData["id"]);
            user.Packages = GetUserPackages(user.Id);

            return user;
        }

        // Метод для получения списка посылок пользователя по его ID
        public List<Package> GetUserPackages(int id)
        {
            // Инициализация списка посылок
            var packages = new List<Package>();

            // SQL-команда для выборки посылок пользователя
            var command = new MySqlCommand("SELECT * FROM `UserPackage` WHERE `UserID` = @id", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            // Параметры для SQL-команды
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            // Проверка наличия посылок
            if (table.Rows.Count == 0)
            {
                return new List<Package>();
            }

            // Цикл по каждой строке результата SQL-команды
            foreach (var objrow in table.Rows)
            {
                // Получение данных о посылке из базы данных
                var packageData = new Dictionary<string, string>();
                var row = (DataRow)objrow;
                var package = GetPackage(int.Parse(row.ItemArray[0].ToString()));
                packages.Add(package);
            }

            return packages;
        }

        // Метод для проверки существования посылки по её ID
        public bool CheckPackage(int id)
        {
            var command = new MySqlCommand("SELECT * FROM `Package` WHERE `id` = @id", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            // Параметры для SQL-команды
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count != 0;
        }

        // Метод для добавления посылки в базу данных
        public void AddPackege(Package package)
        {
            // SQL-команда для добавления записи в таблицу Package
            var SQLCommand = "INSERT INTO `Package` (`startAdress`, `endAdress`, `size`, `comment`, `time`, `cost`, `status`) VALUES (@startAdres, @endAdres, @size, @comment, @time, @cost, @status)";
            var command = new MySqlCommand(SQLCommand, connection);

            // Параметры для SQL-команды
            command.Parameters.Add("@startAdres", MySqlDbType.VarChar).Value = package.StartAddres;
            command.Parameters.Add("@endAdres", MySqlDbType.VarChar).Value = package.EndAddres;
            command.Parameters.Add("@size", MySqlDbType.VarChar).Value = package.Size;
            command.Parameters.Add("@comment", MySqlDbType.VarChar).Value = package.Comment;
            command.Parameters.Add("@time", MySqlDbType.VarChar).Value = package.Time.ToString();
            command.Parameters.Add("@cost", MySqlDbType.VarChar).Value = package.Cost;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = package.Status;

            // Выполнение SQL-команды
            command.ExecuteNonQuery();

            // Получение добавленной посылки
            command = new MySqlCommand("SELECT * FROM `Package` WHERE `time` = @time", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            // Параметры для SQL-команды
            command.Parameters.Add("@time", MySqlDbType.VarChar).Value = package.Time.ToString();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            var row = table.Rows[0];

            // Получение ID добавленной посылки
            var id = row.ItemArray[0].ToString();
            package.Id = int.Parse(id);
        }

        public void DeletePackage(int id)
        {
            if (!CheckPackage(id))
            {
                throw new Exception("Не удалось найти посылку в базе данных");
            }
            else
            {
                // SQL-команда для удаления записи о посылке
                var command = new MySqlCommand("DELETE FROM `Package` WHERE `id` = @id", connection);
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
                command.ExecuteNonQuery();
            }
        }

        // Метод для обновления информации о посылке по её ID
        public void UpdatePackage(int id, string startAddress = "", string endAddress = "", string comment = "", string size = "", string time = "", string cost = "", string status = "")
        {
            if (!CheckPackage(id))
            {
                throw new Exception("Не удалось найти посылку в базе данных");
            }
            else
            {
                // Чтение информации о посылке
                var package = ReadPackage(id);

                // Установка новых значений или оставление текущих
                startAddress = startAddress == "" ? package["startAddres"] : startAddress;
                endAddress = endAddress == "" ? package["endAdres"] : endAddress;
                comment = comment == "" ? package["comment"] : comment;
                size = size == "" ? package["size"] : size;
                time = time == "" ? package["time"] : time;
                cost = cost == "" ? package["cost"] : cost;
                status = status == "" ? package["status"] : status;

                // SQL-команда для обновления данных о посылке
                var command = new MySqlCommand("UPDATE `Package` SET `startAdress` = @startAdres, `endAdress` = @endAdres, `size` = @size, `comment` = @comment, `time` = @time, `cost` = @cost, `status` = @status WHERE `Package`.`id` = @id", connection);

                // Параметры для SQL-команды
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
                command.Parameters.Add("@startAdres", MySqlDbType.VarChar).Value = startAddress;
                command.Parameters.Add("@endAdres", MySqlDbType.VarChar).Value = endAddress;
                command.Parameters.Add("@size", MySqlDbType.VarChar).Value = size;
                command.Parameters.Add("@comment", MySqlDbType.VarChar).Value = comment;
                command.Parameters.Add("@time", MySqlDbType.VarChar).Value = time;
                command.Parameters.Add("@cost", MySqlDbType.VarChar).Value = cost;
                command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;

                // Выполнение SQL-команды
                command.ExecuteNonQuery();
            }
        }

        // Метод для чтения информации о посылке по её ID
        public Dictionary<string, string> ReadPackage(int id)
        {
            // SQL-команда для выборки данных о посылке
            var command = new MySqlCommand("SELECT * FROM `Package` WHERE `id` = @id", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            // Параметры для SQL-команды
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.ToString();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            // Проверка наличия данных о посылке
            if (table.Rows.Count == 0)
            {
                throw new Exception("Не удалось найти посылку в базе данных");
            }
            else
            {
                // Создание словаря для хранения данных о посылке
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
                return package;
            }
        }

        // Метод для получения объекта посылки по её ID
        public Package GetPackage(int id)
        {
            // Получение данных о посылке из базы данных
            var packageData = ReadPackage(id);

            // Разбор строки времени и создание объекта посылки
            var t = packageData["time"].Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            var package = new Package(packageData["startAddres"], packageData["endAddres"], packageData["comment"], new DateTime(t[2], t[1], t[0], t[3], t[4], t[5]), packageData["size"]);
            package.Id = id;
            package.Cost = double.Parse(packageData["cost"]);
            package.Status = packageData["status"];
            return package;
        }

        // Метод для добавления посылки к пользователю
        public void AddPackageToUser(int userId, Package package)
        {
            // Добавление посылки в базу данных
            AddPackege(package);

            // Проверка существования пользователя
            if (!CheckUser(userId))
            {
                throw new Exception("Не удалось найти пользователя в базе данных");
            }

            // SQL-команда для связи пользователя с посылкой
            var SQLCommand = "INSERT INTO `UserPackage` (`userID`, `packageID`) VALUES (@userID, @packageID)";
            var command = new MySqlCommand(SQLCommand, connection);

            // Параметры для SQL-команды
            command.Parameters.Add("@userID", MySqlDbType.VarChar).Value = userId.ToString();
            command.Parameters.Add("@packageID", MySqlDbType.VarChar).Value = package.Id.ToString();

            // Выполнение SQL-команды
            command.ExecuteNonQuery();
        }

        // Метод для получения списка посылок с заданным статусом
        public List<Package> GetStatusPackage(string status = "wait")
        {
            // Инициализация списка посылок
            var packages = new List<Package>();

            // SQL-команда для выборки посылок с заданным статусом
            var command = new MySqlCommand("SELECT * FROM `Package` WHERE `status` = @status", connection);
            var adapter = new MySqlDataAdapter();
            var table = new DataTable();

            // Параметры для SQL-команды
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            // Проверка наличия посылок
            if (table.Rows.Count == 0)
            {
                return new List<Package>();
            }

            // Цикл по каждой строке результата SQL-команды
            foreach (var objrow in table.Rows)
            {
                // Получение данных о посылке из базы данных
                var packageData = new Dictionary<string, string>();
                var row = (DataRow)objrow;
                var id = row.ItemArray[0].ToString();
                var package = GetPackage(int.Parse(row.ItemArray[0].ToString()));
                packages.Add(package);
            }

            return packages;
        }
    }
}


