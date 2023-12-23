using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BruhMobilApp.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }
        public string Role { get; set; }
        private List<Package> Packages { get; set; }

        public User(int id, string name, string email, string passowrd, string number, string role) 
        {
            Id = id;
            Name = name;
            if (email.Contains("@")) Email = email;
            else throw new Exception($"Wrong email {email}, must contains @");
            Password = passowrd;
            if (number.All(char.IsDigit)) Number = number;
            else throw new Exception($"Wrong number {number}, must contains only digits");
            if (role == "deliverman" || role == "customer") Role = role;
            else throw new Exception($"Wrong role {role}, must be deliverman or customer");
        }

        public User(int id, string name, string email, string passowrd, string number, string role, List<Package> packages):
            this(id, name, email, passowrd, number, role)
        {
            Packages = packages;
        }
    }

    public class Deliverman : User
    {        
        public string Status { get; set; }

        public Deliverman(int id, string name, string email, string passowrd, string number, string role, string status):
            base(id, name, email, passowrd, number, role)
        {
            if (status == "busy" || status == "free") Status = status;
            else throw new Exception($"Wrong status {status} must be busy or free");
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
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }
        public string Comment { get; set; }
        public string Size {  get; set; }
        public DateTime Time { get; set; }

        public Package(int id, string startAddress, string endAddress, string comment, string size, DateTime time)
        {
            Id = id;
            if (startAddress.Length != 0) StartAddress = startAddress;
            else throw new Exception("Address cant be empty");
            if (endAddress.Length != 0) EndAddress = endAddress;
            else throw new Exception("Addres cant be empty");
            Comment = comment;
            if (size == "small" || size == "standard" || size == "big") Size = size;
            else throw new Exception($"Wrong size {size} must be small, standard or big");
            Time = time;
        }
    }
}
