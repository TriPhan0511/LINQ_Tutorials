using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_LINQ_Tuotorial
{
    internal class Orderby_Clause_Tutorial
    {
        // In a query expression, the orderby clause causes the returned sequence or
        // subsequence (group) to be sorted in either ascending or descending order.
        // Multiple keys can be specified in order to perform one or more secondary sort operetions.
        // The sorting is performed by the default comparer for the type of the element.
        // The default sort order is ascending.

        // In the following example, the first query sorts the words in alphabetical order
        // starting from A, and second query sorts the same words in descending order.
        // (The ascending keyword is the default sort value and can be omitted.)
        public static void OrderBySample1()
        {
            // Data source
            string[] fruits = { "cherry", "apple", "blueberry" };

            // Query for ascending sort
            var sortAscendingQuery = 
                from f in fruits
                orderby f // "ascending" is default
                select f;

            // Query for descending sort
            var sortDescendingQuery =
                from f in fruits
                orderby f descending
                select f;

            // Execute the query
            Console.WriteLine("Ascending");
            foreach (var item in sortAscendingQuery)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();


            // Execute the query
            Console.WriteLine("Descending:");
            foreach (var item in sortDescendingQuery)
            {
                Console.Write($"{item} ");
            }

            // Output:
            //Ascending
            //apple blueberry cherry
            //Descending:
            //cherry blueberry apple
        }
    }
}
