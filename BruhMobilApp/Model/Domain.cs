using System;
using System.Collections.Generic;
using System.Text;

namespace BruhMobilApp.Model
{
    public class User
    {
        public string Name { get; set; }
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
        public string Commit { get; set; }
    }
}
