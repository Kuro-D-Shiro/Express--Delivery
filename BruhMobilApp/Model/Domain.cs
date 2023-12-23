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
        public string Email {
            get=>Email;
            set
            {
                if (value.Contains("@"))
                    Email = value;
                else
                    throw new Exception($"Wrong email {value}, must contains @");
            }
        }
        public string Password {
            get => Password;
            set
            {
                if (value.All(char.IsDigit))
                    Number = value;
                else
                    throw new Exception($"Wrong number {value}, must contains only digits");
            }
        }
        public string Number { get; set; }
        public string Role {
            get => Role;
            set
            {
                if (value == "deliverman" || value == "customer")
                    Role = value;
                else 
                    throw new Exception($"Wrong role {value}, must be deliverman or customer");
            }
        }
        private List<Package> Packages { get; set; }

        public User(int id, string name, string email, string passowrd, string number, string role) 
        {
            Id = id;
            Name = name;
            Email = email;
            Password = passowrd;
            Number = number;
            Role = role;
        }

        public User(int id, string name, string email, string passowrd, string number, string role, List<Package> packages):
            this(id, name, email, passowrd, number, role)
        {
            Packages = packages;
        }
    }

    public class Deliverman : User
    {        
        public string Status {
            get => Status;
            set
            {
                if (value == "busy" || value == "free") Status = value;
                else throw new Exception($"Wrong status {value} must be busy or free");
            }
        }

        public Deliverman(int id, string name, string email, string passowrd, string number, string role, string status):
            base(id, name, email, passowrd, number, role)
        {
            Status = status;
        }
    }
    public class Customer : User
    {
        /* Просто дублирует конструкторы чтоб класс не пустой был*/
        public Customer(int id, string name, string email, string passowrd, string number, string role) :
            base(id, name, email, passowrd, number, role)
        { }
      
        
        public Customer(int id, string name, string email, string passowrd, string number, string role, List<Package> packages) :
            base(id, name, email, passowrd, number, role, packages)
        { }
    }
    public class Package
    {
        public int Id { get; set; }
        public string StartAddress {
            get => StartAddress;
            set
            {
                if (value.Length != 0)
                    StartAddress = value;
                else
                    throw new Exception("Address cant be empty");
            }
        }
        public string EndAddress {
            get => EndAddress; 
            set
            {
                if (value.Length != 0)
                    EndAddress = value;
                else
                    throw new Exception("Addres cant be empty");
            }
        }
        public string Comment { get; set; }
        public string Size {
            get=>Size;
            set
            {
                if (value == "small" || value == "standard" || value == "big")
                    Size = value;
                else
                    throw new Exception($"Wrong size {value} must be small, standard or big");
            }

        }
        public DateTime Time { get; set; }
        public double Cost { get; set; }
        public string Status {  get; set; }

        public Package(int id, string startAddress, string endAddress, string comment, string size, DateTime time)
        {
            Id = id;
            StartAddress = startAddress;
            EndAddress = endAddress;
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
