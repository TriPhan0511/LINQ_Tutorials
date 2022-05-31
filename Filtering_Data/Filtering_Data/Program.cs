using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace Filtering_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Filtering refers to the operation of restricting the result set to contain only those elements
                that satisfy a specified condition. It is also known as selection.

                Link: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/filtering-data
             */

            //// The following example uses the where clause to filter from an array those strings that have a specific length.
            //string[] words = { "the", "quick", "brown", "fox", "jumps" };

            ////// Query syntax
            ////var query = 
            ////    from word in words
            ////    where word.Length == 3
            ////    select word;

            //// Method syntax
            //var query =
            //    words.Where(word => word.Length == 3);

            //foreach (var item in query)
            //{
            //    Console.Write($"{item} ");
            //}
            //Console.WriteLine();

            //// Output: the fox

            // Another example: 
            // The following example shows that the standard query operators such as
            // Where() can be applied to the ArrayList type after calling OfType()
            // Link: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.oftype?view=net-6.0

            ArrayList fruits = new ArrayList(4);
            fruits.Add("Mango");
            fruits.Add("Orange");
            fruits.Add("Apple");
            fruits.Add(3.0);
            fruits.Add("Banana");

            var query =
                fruits.OfType<string>();

            foreach (var item in query)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            // Output: Mango Orange Apple Banana

            var query2 =
                fruits.OfType<string>().Where(fruit => fruit.ToLower().Contains("n"));

            foreach (var item in query2)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            // Output: Mango Orange Banana
        }
    }
}
