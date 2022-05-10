using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Tutorials
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The following example shows the complete query operation.
            // The complete operation includes creating a data source,
            // defining a query expression, and executing the query in
            // a freach statement.
            
            // Specify the data source
            int[] scores = new int[] { 97, 92, 60, 81};

            // Define the query expression
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute the query
            foreach (var item in scoreQuery)
            {
                Console.Write($"{item} ");
            }

            // -> Output: 97 92 81
        }
    }
}
