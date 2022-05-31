using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Data_In_A_Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                A sorting operation orders the elements of a sequence based on one or more attributes.
                The first sort criterion performs a primary sort on the elements.
                By specifying a second sort criterion, you can sort the elements within each primary sort group.
             */

            /*
                I. Primary Sort Examples
             */

            /*
                1.Primary Ascending Sort
             */

            //// The following example demonstrates how to use the orderby clause in a LINQ query
            //// to sort the strings in an array by string length, in ascending order.
            //string[] words = { "the", "quick", "brown", "fox", "jumps" };

            //// Query syntax
            //IEnumerable<string> query =
            //    from word in words
            //    orderby word.Length
            //    select word;

            ////// Method syntax
            ////IEnumerable<string> query =
            ////    words.OrderBy(x => x.Length);

            //foreach (var word in query)
            //{
            //    Console.Write($"{word} ");
            //}
            //Console.WriteLine();
            //// output: the fox quick brown jumps

            /*
                2.Primary Descending Sort
             */

            //string[] words = { "the", "quick", "brown", "fox", "jumps" };

            //IEnumerable<string> query =
            //    from word in words
            //    orderby word.Length descending
            //    select word;

            ////IEnumerable<string> query =
            ////    words.OrderByDescending(x => x.Length);

            //foreach (var item in query)
            //{
            //    Console.Write($"{item} ");
            //}
            //// Output: quick brown jumps the fox
            ///

            /*
                II. Secondary Sort Examples
             */

            /*
                1. Secondary Ascending Sort
             */

            //// The follwing example demonstrates how to use the orderby clause in a LINQ query
            //// to perform a primary and secondary sort of the strings in an array.
            //// The strings are sorted primarily by length and secondarily by the first letter of
            //// the string, both in ascending order.

            //string[] words = { "the", "quick", "brown", "fox", "jumps" };

            //var query =
            //    from word in words
            //    orderby word.Length, word.Substring(0, 1)
            //    select word;

            ////var query =
            ////    words.OrderBy(x => x.Length).ThenBy(x => x.Substring(0, 1));

            //foreach (var item in query)
            //{
            //    Console.Write($"{item} ");
            //}

            //// Output: fox the brown jumps quick

            /*
                2. Secondary Ascending Sort
             */

            string[] words = { "the", "quick", "brown", "fox", "jumps" };

            //var query =
            //    from word in words
            //    orderby word.Length, word.Substring(0, 1) descending
            //    select word;

            var query =
                words.OrderBy(x => x.Length).ThenByDescending(x => x.Substring(0, 1));

            foreach (var item in query)
            {
                Console.Write($"{item} ");
            }

            // Output: the fox quick jumps brown

        }
    }
}
