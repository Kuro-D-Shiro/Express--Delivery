﻿using System;
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

    }
    public class Customer : User
    {

    }
    public class Package
    {

    }
}
