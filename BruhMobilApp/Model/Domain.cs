using System;
using System.Collections.Generic;
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
