using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Initializer_and_Collection_Initializer_Tutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat { Age = 10, Name = "Fluffy" };
            Cat sameCat = new Cat("Fluffy") { Age = 10 };

            List<Cat> cats = new List<Cat>
            {
                new Cat { Name = "Sylvester", Age = 8},
                new Cat {Name = "Whiskers", Age = 2},
                new Cat {Name = "Sasha", Age = 14}
            };

            List<Cat> moreCats = new List<Cat>
            {
                new Cat {Name = "FurryTail", Age = 5 },
                new Cat {Name = "Peaches", Age = 4},
                null
            };

            // Display results
            Console.WriteLine(cat.Name);

            foreach (var c in cats)
            {
                Console.WriteLine(c.Name);
            }
            
            foreach (var c in moreCats)
            {
                if (c != null)
                {
                    Console.WriteLine(c.Name);
                }
                else
                {
                    Console.WriteLine("List element has null value.");
                }
            }
            // -> Output:
            //Fluffy
            //Sylvester
            //Whiskers
            //Sasha
            //FurryTail
            //Peaches
            //List element has null value.
        }
    }
}
