using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BruhMobilApp.Model
{
    // Класс представляет сущность "Пользователь"
    public class User
    {
        // Приватные поля для хранения данных о пользователе
        private string name;
        private string password;
        private int id;
        private string email;
        private string number;
        private string role;

        // Свойство для доступа к полю ID с проверкой на положительное значение
        public int Id
        {
            get => id;
            set
            {
                if (value >= 0) id = value;
                else throw new ArgumentOutOfRangeException("Поле «ID» должно быть больше чем или равно 0!");
            }
        }

        // Свойство для доступа к полю Name с проверкой на корректность ввода
        public string Name
        {
            get => name;
            set
            {
                if (value != null && value.Length > 1 && value.All(char.IsLetter)) name = value;
                else throw new Exception($"Поле «Имя» должно содержать больше чем одну букву!");
            }
        }

        // Свойство для доступа к полю Email с проверкой на наличие символа '@'
        public string Email
        {
            get => email;
            set
            {
                if (value.Contains("@"))
                    email = value;
                else
                    throw new Exception($"Неправильный ввод:«{value}», e-mail должен содержать символ '@'!");
            }
        }

        // Свойство для доступа к полю Password с проверкой на длину пароля
        public string Password
        {
            get => password;
            set
            {
                if (value != null && value.Length >= 4)
                {
                    password = value;
                }
                else
                    throw new Exception("Поле «Пароль» должно быть длиннее чем 4 символа!");
            }
        }

        // Свойство для доступа к полю Number с проверкой на формат номера
        public string Number
        {
            get => number;
            set
            {
                if (value.All(char.IsDigit) && value.Length == 11)
                    number = value;
                else
                    throw new Exception($"Неправильный формат номера «{value}», должен содержать только цифры!");
            }
        }

        // Свойство для доступа к полю Role с проверкой на допустимые значения роли
        public string Role
        {
            get => role;
            set
            {
                if (value.ToLower() == "deliverman" || value.ToLower() == "customer")
                    role = value.ToLower();
                else
                    throw new Exception($"Неправильная роль:«{value}», возможные варианты – «deliverman» или «customer»");
            }
        }

        // Свойство для доступа к списку посылок, связанных с пользователем
        public List<Package> Packages { get; set; }

        // Конструктор для создания объекта User с обязательными полями
        public User(string name, string email, string password, string number, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Number = number;
            Role = role;
        }

        // Конструктор для создания объекта User с возможностью задать список посылок
        public User(string name, string email, string password, string number, string role, List<Package> packages) :
            this(name, email, password, number, role)
        {
            Packages = packages;
        }

        // Переопределение метода Equals для сравнения объектов User
        public override bool Equals(object obj)
        {
            var other = obj as User;
            return ((other.Id == Id) && (other.Name == Name) && (other.Email == Email)
                && (other.Password == Password) && (other.Role == Role));
        }
    }

    // Класс представляет сущность "Доставщик", наследуется от класса User
    public class Deliverman : User
    {
        // Приватное поле для хранения статуса доставщика
        private string status;

        // Свойство для доступа к статусу с проверкой на допустимые значения
        public string Status
        {
            get => status;
            set
            {
                if (value.ToLower() == "busy" || value.ToLower() == "free") status = value.ToLower();
                else throw new Exception($"Неправильный статус «{value}», допустимые варианты — «busy» или «free»");
            }
        }

        // Конструктор для создания объекта Deliverman с обязательными полями
        public Deliverman(string name, string email, string password, string number, string role, string status) :
            base(name, email, password, number, role)
        {
            Status = status;
        }
    }

    // Класс представляет сущность "Клиент", наследуется от класса User
    public class Customer : User
    {
        // Приватное поле для хранения статуса клиента
        private string status;

        // Свойство для доступа к статусу с проверкой на допустимые значения
        public string Status
        {
            get => status;
            set
            {
                if (value.ToLower() == "busy" || value.ToLower() == "free") status = value.ToLower();
                else throw new Exception($"Неправильный статус «{value}», допустимые варианты — «busy» или «free»");
            }
        }

        // Конструктор для создания объекта Customer с обязательными полями
        public Customer(string name, string email, string password, string number, string role, string status) :
            base(name, email, password, number, role)
        {
            Status = status;
        }

        // Конструктор для создания объекта Customer с возможностью задать список посылок
        public Customer(string name, string email, string password, string number, string role, List<Package> packages) :
            base(name, email, password, number, role, packages)
        { }
    }

    // Класс представляет сущность "Посылка"
    public class Package
    {
        // Приватное поле для хранения ID посылки
        private int id;

        // Свойство для доступа к ID с проверкой на положительное значение
        public int Id
        {
            get => id;
            set
            {
                if (value >= 0) id = value;
                else throw new ArgumentOutOfRangeException("Поле «ID» должно быть больше чем или равно 0!");
            }
        }

        // Свойство для доступа к начальному адресу с проверкой на пустоту
        public string StartAddres
        {
            get => startAddres;
            set
            {
                if (value.Length != 0)
                    startAddres = value;
                else
                    throw new Exception("Адрес не может быть пустым!");
            }
        }

        // Свойство для доступа к конечному адресу с проверкой на пустоту
        public string EndAddres
        {
            get => endAddres;
            set
            {
                if (value.Length != 0)
                    endAddres = value;
                else
                    throw new Exception("Адрес не может быть пустым!");
            }
        }

        // Свойство для доступа к комментарию
        public string Comment { get; set; }

        // Свойство для доступа к размеру посылки с проверкой на допустимые значения
        public string Size
        {
            get => size;
            set
            {
                if (value.ToLower() == "small" || value.ToLower() == "standard" || value.ToLower() == "big" || value.ToLower() == "not")
                    size = value.ToLower();
                else
                    throw new Exception($"Неправильный размер:«{value}», допустимые варианты: «small», «standard» или «big»");
            }
        }

        // Свойство для доступа к времени доставки
        public DateTime Time { get; set; }

        // Приватное поле для хранения стоимости посылки
        private double cost;

        // Свойство для доступа к стоимости с проверкой на положительное значение
        public double Cost
        {
            get => cost;
            set
            {
                if (value > 0) cost = value;
                else throw new ArgumentException($"Неправильная стоимость «{value}», стоимость должна быть больше нуля!");
            }
        }

        // Свойство для доступа к статусу посылки с проверкой на допустимые значения
        public string Status
        {
            get => status;
            set
            {
                var allowedStatus = new string[] { "wait", "delivered", "trasport", "rejected" };
                if (allowedStatus.Contains(value.ToLower()))
                    status = value.ToLower();
                else
                    throw new Exception($"Ошибка ввода:«{value}», разрешённые варианты:" +
                        $" \"wait\", \"delivered\", \"trasport\", \"rejected\"");
            }
        }

        // Приватные поля для хранения данных о посылке
        private string startAddres;
        private string endAddres;
        private string size;
        private string status;

        // Конструктор для создания объекта Package с обязательными полями
        public Package(string startAddress, string endAddress, string comment, DateTime time, string size = "not")
        {
            StartAddres = startAddress;
            EndAddres = endAddress;
            Comment = comment;
            Size = size;
            Time = time;
            status = "wait";
        }

        // Метод для расчета стоимости доставки
        public double CalculateCost(int distanceInMeters)
        {
            var sizeFactor = new Dictionary<string, double>()
        {{"small", 1.0 }, {"standard", 1.25 }, {"big", 1.5 }};
            Cost = distanceInMeters * sizeFactor[Size];
            return Cost;
        }

        // Переопределение метода Equals для сравнения объектов Package
        public override bool Equals(object obj)
        {
            var other = obj as Package;
            return ((other.Id == Id) && (other.StartAddres == StartAddres) && (other.EndAddres == EndAddres) &&
                (other.Comment == Comment) && (other.Cost == Cost) && (other.Size == Size) && (other.Time == Time) && (other.Status == Status));
        }
    }
}
