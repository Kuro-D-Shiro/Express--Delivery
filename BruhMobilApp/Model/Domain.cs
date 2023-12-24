using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BruhMobilApp.Model
{
    public class User
    {
        private string name;
        private string password;
        private int id;

        public int Id 
        {
            get => id;
            set
            {
                if (value >= 0) id = value;
                else throw new ArgumentOutOfRangeException("The «ID» must be greater than or equal to 0");
            } 
        }
        public string Name
        {
            get => name;
            set
            {
                if (value != null && value.Length > 1 && value.All(char.IsLetter)) name = value;
                else throw new Exception($"The «Name» must be stored with more than one letter");
            }
        }
        public string Email
        {
            get => email;
            set
            {
                if (value.Contains("@"))
                    email = value;
                else
                    throw new Exception($"Wrong email {value}, must contains @");
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (value == null && value.Length > 4)
                {
                    password = value;
                }
                else
                    throw new Exception("The «Password» must be longer than 4 chars");
            }
        }
        public string Number
        {
            get => number;
            set
            {
                if (value.All(char.IsDigit))
                    number = value;
                else
                    throw new Exception($"Wrong number {value}, must contains only digits");
            }
        }
        public string Role
        {
            get => role;
            set
            {
                if (value.ToLower() == "deliverman" || value.ToLower() == "customer")
                    role = value.ToLower();
                else
                    throw new Exception($"Wrong role {value}, must be deliverman or customer");
            }
        }
        private List<Package> Packages { get; set; }
        private string email;
        private string number;
        private string role;

        public User(string name, string email, string password, string number, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Number = number;
            Role = role;
        }

        public User(string name, string email, string password, string number, string role, List<Package> packages) :
            this(name, email, password, number, role)
        {
            Packages = packages;
        }
    }

    public class Deliverman : User
    {
        public string Status
        {
            get => status;
            set
            {
                if (value.ToLower() == "busy" || value.ToLower() == "free") status = value.ToLower();
                else throw new Exception($"Wrong status {value} must be busy or free");
            }
        }
        private string status;

        public Deliverman(string name, string email, string password, string number, string role, string status) :
            base(name, email, password, number, role)
        {
            Status = status;
        }
    }
    public class Customer : User
    {
        /* Просто дублирует конструкторы чтоб класс не пустой был*/
        public Customer(string name, string email, string password, string number, string role) :
            base(name, email, password, number, role)
        { }


        public Customer(string name, string email, string password, string number, string role, List<Package> packages) :
            base(name, email, password, number, role, packages)
        { }
    }
    public class Package
    {
        int id;
        public int Id
        {
            get => id;
            set
            {
                if (value >= 0) id = value;
                else throw new ArgumentOutOfRangeException("The «ID» must be greater than or equal to 0");
            }
        }
        public string StartAddres
        {
            get => startAddres;
            set
            {
                if (value.Length != 0)
                    startAddres = value;
                else
                    throw new Exception("Address can't be empty");
            }
        }
        public string EndAddres
        {
            get => endAddres;
            set
            {
                if (value.Length != 0)
                    endAddres = value;
                else
                    throw new Exception("Address can't be empty");
            }
        }
        public string Comment { get; set; }
        public string Size
        {
            get => size;
            set
            {
                if (value.ToLower() == "small" || value.ToLower() == "standard" || value.ToLower() == "big")
                    size = value.ToLower();
                else
                    throw new Exception($"Wrong size {value} must be small, standard or big");
            }

        }
        public DateTime Time { get; set; }
        private double cost;
        public double Cost 
        {
            get => cost;
            set 
            {
                if (value > 0) cost = value;
                else throw new ArgumentException($"Wrong cost {value}, it must be greater than 0");
            }
        }
        public string Status
        {
            get => status;
            set
            {
                var allowedStatus = new string[] { "wait", "delivered", "trasport", "rejected" };
                if (allowedStatus.Contains(value))
                    status = value;
                else
                    throw new Exception($"{value} is not allowed, mast be" +
                        $" \"wait\", \"delivered\", \"trasport\", \"rejected\"");
            }
        }

        private string startAddres;
        private string endAddres;
        private string size;
        private string status;

        public Package(string startAddress, string endAddress, string comment, string size, DateTime time)
        {
            StartAddres = startAddress;
            EndAddres = endAddress;
            Comment = comment;
            Size = size;
            Time = time;
            status = "wait";
        }

        public double CalculateCost(int distanceInMeters)
        {
            //var k = 1e-2;
            var sizeFactor = new Dictionary<string, double>()
            {{"small", 1.0 }, {"standard", 1.25 }, {"big", 1.5 }};

            Cost = distanceInMeters * sizeFactor[Size];
            return Cost;
        }
    }
}
