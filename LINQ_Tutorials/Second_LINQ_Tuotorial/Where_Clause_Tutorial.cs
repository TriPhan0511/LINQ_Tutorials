using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_LINQ_Tuotorial
{
    internal class Where_Clause_Tutorial
    {
        // In the following example, the where clause filters out all numbers
        // except those that are less than five.
        // The expression num < 5 is the predicate that is applied to each element
        public static void WhereSample1()
        {
            // Simple data source. Arrays support IEnumerable<T>
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Simple query with one predicate in where clause.
            var queryLowNums =
                from num in numbers
                where num < 5
                select num;

            // Execute the query.
            foreach (var num in queryLowNums)
            {
                Console.Write($"{num} ");
            }

            // Output: 4 1 3 2 0
        }

        // Within a single where clause, you can specify as many predicates as necessary
        // by using the && an || operators.
        // In the following example, the query specifies two predicates in order to select
        // only the even numbers that are less than five
        public static void WhereSample2()
        {
            // Data source.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Create the query with two predicates in where clause
            var queryLowNums2 =
                from num in numbers
                where num < 5 && num % 2 ==0
                select num;

            // Execute the query
            foreach (var num in queryLowNums2)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            // Create the query with two where clause.
            var queryLowNums3 = 
                from num in numbers
                where num < 5
                where num % 2 == 0
                select num;

            // Execute the query
            foreach (var num in queryLowNums3)
            {
                Console.Write($"{num} ");
            }

            // Output: 
            //4 2 0
            //4 2 0
        }

        // A where clause may contain one or more methods that return Boolean values.
        // In the following example, the where clause uses a method to determine whether
        // the current value of the range variable is even or odd.
        public static void WhereSample3()
        {
            // Data source
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Create the query with a method call in the where clause.
            // Note: This won't work in LINQ to SQL unless you have a
            // stored procedure that is mapped to a method by this name.
            var queryEvenNums =
                from num in numbers
                where IsEven(num)
                select num;

            // Execute the query
            foreach (var num in queryEvenNums)
            {
                Console.Write($"{num} ");
            }

            // Output: 4 8 6 2 0

        }

        // Method may be instance method or static method
        static bool IsEven(int i)
        {
            return i % 2 == 0;
        }
    }
}
