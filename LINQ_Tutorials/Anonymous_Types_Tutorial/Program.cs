using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_Types_Tutorial
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    // Use the collection initializer and object initializer
        //    // to create a list of Product objects
        //    List<Product> products = new List<Product>
        //    {
        //        new Product { Name = "Product A", Color = "Red",Price = 99.99m},
        //        new Product { Name = "Product B", Color = "Yellow", Price = 199.99m},
        //        new Product { Name = "Product C", Color = "Purple", Price = 299.99m}
        //    };

        //    // Note: If you do not specify names in the anonymous type,
        //    // the compiler give the anonymous type members the same name as
        //    // the property being used to initialize them.
        //    // In the following example, the names of the properties of the anonymous type
        //    // are Color and Price.
        //    var productQuery =
        //        from prod in products
        //        select new { prod.Color, prod.Price };

        //    // Execute the qeury
        //    foreach (var item in productQuery)
        //    {
        //        Console.WriteLine($"Color= {item.Color}, Price= {item.Price}");
        //    }

        //    // -> Output:
        //    //Color = Red, Price = 99.99
        //    //Color = Yellow, Price = 199.99
        //    //Color = Purple, Price = 299.99
        //}
        //------------------------------------------------------------------------------------

        static void Main(string[] args)
        {
            //// Declare an anonymous type
            //var v = new { Amount = 108, Message = "Hello" };
            //Console.WriteLine(v.Amount);
            //Console.WriteLine(v.Message);
            //----------------------------------------------------

            // Create an array of anonymous typed elements by combining 
            // an implicitly typed local variable and an inplicitly typed array,
            // as shown in the following example:
            var anonArray = new[] { new { name = "Apple", diam = 4 }, new { name = "Grape", diam = 1} };
            foreach (var item in anonArray)
            {
                //Console.WriteLine(item);
                Console.WriteLine($"Name: {item.name}, Diam: {item.diam}");
            }

            // -> Output: 
            //Name: Apple, Diam: 4
            //Name: Grape, Diam: 1
        }


    }
}
