using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Tutorials
{
    internal class Program
    {

        static void Main(string[] vs)
        {
            // Three Parts of a Query Operation
            // All LINQ query operations consist of three distinct actions:
            // 1. Obtain the data source
            // 2. Create the query
            // 3. Execute the query

            // The Three Parts of a LINQ query
            // 1. Data source.
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            //// 3. Query execution.
            //foreach (var item in numQuery)
            //{
            //    Console.Write($"{item} ");
            //}

            // Forcing Immediate Execution
            // Queries that perform aggregation functions over a range of source elements 
            // must first iterate over those elements.
            // Examples of such queries are Count, Max, Average, and First.
            // These execute without an explcitit foreach statement because the query itself
            // must use foreach in order to return a result. Note also that these types of
            // queries return a single value, not an IEnumerable collection.

            //// The following query returns a count of the even numbers in the source array.
            //var evenNumQuery =
            //    from num in numbers
            //    where num % 2 == 0
            //    select num;

            //int evenNumCount = evenNumQuery.Count();

            // To force immediate execution of any query and cache its results,
            // you can call the ToList or ToArray methods.
            List<int> numQuery2 = 
                (from num in numbers
                 where num % 2 == 0
                 select num).ToList();

            // or like this:
            // numQuery3 is still an int[]
            var numQuery3 =
                (from num in numbers
                 where num % 2 == 0
                 select num).ToArray();

            // You can also force execution by putting the foreach loop immediately after
            // the query expression. However, by calling ToList or ToArray you also cache
            // all the data in a single collection object.
        }






        //------------------------------------------------------------------------------------
        //static void Main(string[] args)
        //{
        //    // The following example shows the complete query operation.
        //    // The complete operation includes creating a data source,
        //    // defining a query expression, and executing the query in
        //    // a freach statement.
            
        //    // Specify the data source
        //    int[] scores = new int[] { 97, 92, 60, 81};

        //    // Define the query expression
        //    IEnumerable<int> scoreQuery =
        //        from score in scores
        //        where score > 80
        //        select score;

        //    // Execute the query
        //    foreach (var item in scoreQuery)
        //    {
        //        Console.Write($"{item} ");
        //    }

        //    // -> Output: 97 92 81
        //}
    }
}
