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
    }

    public class Deliverman : User
    {
        private List<Package> Packages { get; set; }
        public string Status { get; set; }

        public Deliverman() 
        {
            Packages = new List<Package>();
        }
    }
    public class Customer : User
    {
        private List<Package> Packages { get; set; }

        public Customer()
        {
            Packages = new List<Package>();
        }
    }
    public class Package
    {
        public int Id { get; set; }
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }
        public string Comment { get; set; }
        public string Size {  get; set; }
        public DateTime time { get; set; }
    }
}
