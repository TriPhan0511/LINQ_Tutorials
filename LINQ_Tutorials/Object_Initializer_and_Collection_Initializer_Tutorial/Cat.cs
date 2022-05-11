using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Initializer_and_Collection_Initializer_Tutorial
{
    internal class Cat
    {
        // Auto-implemented properties.
        public int Age { get; set; }
        public string Name { get; set; }

        // Default constructor
        public Cat() { }

        // Parameterized constructor
        public Cat(string name)
        {
            Name = name;
        }
    }
}
