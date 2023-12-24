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
        public int Id { get; set; }
        public string Name { get; set; }
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
        public string Password { get; set; }
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
                if (value == "deliverman" || value == "customer")
                    role = value;
                else
                    throw new Exception($"Wrong role {value}, must be deliverman or customer");
            }
        }
        private List<Package> Packages { get; set; }
        private string email;
        private string number;
        private string role;

        public User(string name, string email, string passowrd, string number, string role)
        {
            Name = name;
            Email = email;
            Password = passowrd;
            Number = number;
            Role = role;
        }

        public User(string name, string email, string passowrd, string number, string role, List<Package> packages) :
            this(name, email, passowrd, number, role)
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
                if (value == "busy" || value == "free") status = value;
                else throw new Exception($"Wrong status {value} must be busy or free");
            }
        }
        private string status;

        public Deliverman(string name, string email, string passowrd, string number, string role, string status) :
            base(name, email, passowrd, number, role)
        {
            Status = status;
        }
    }
    public class Customer : User
    {
        /* Просто дублирует конструкторы чтоб класс не пустой был*/
        public Customer(string name, string email, string passowrd, string number, string role) :
            base(name, email, passowrd, number, role)
        { }


        public Customer(string name, string email, string passowrd, string number, string role, List<Package> packages) :
            base(name, email, passowrd, number, role, packages)
        { }
    }
    public class Package
    {
        public int Id { get; set; }
        public string StartAddres
        {
            get => startAddres;
            set
            {
                if (value.Length != 0)
                    startAddres = value;
                else
                    throw new Exception("Address cant be empty");
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
                    throw new Exception("Addres cant be empty");
            }
        }
        public string Comment { get; set; }
        public string Size
        {
            get => size;
            set
            {
                if (value == "small" || value == "standard" || value == "big")
                    size = value;
                else
                    throw new Exception($"Wrong size {value} must be small, standard or big");
            }

        }
        public DateTime Time { get; set; }
        public double Cost { get; set; }
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
        }

        public double CalculateCost(int distanceInMeters)
        {
            var k = 1e-2;
            var sizeFactor = new Dictionary<string, double>()
            {{"small", 0.5 }, {"standard", 1.0 }, {"big", 2.0 }};

            Cost = distanceInMeters * sizeFactor[Size];
            return Cost;
        }
    }
}
