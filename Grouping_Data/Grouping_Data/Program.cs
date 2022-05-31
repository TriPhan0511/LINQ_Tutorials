using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouping_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Grouping refers to the operation of putting data into groups so that the elements
                in each group share a common attribute.

                Link: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/grouping-data
             */

            // The following example uses the group by clause to group integers in a list
            // according to whether they are even or odd.

            List<int> numbers = new List<int> { 35, 44, 200, 84, 3987, 4, 199, 329, 446, 208 };

            //var query =
            //    from number in numbers
            //    group number by number % 2;

            //IEnumerable<IGrouping<int, int>> query =
            //    from number in numbers
            //    group number by number % 2;

            IEnumerable<IGrouping<int, int>> query =
                numbers.GroupBy(number => number % 2);

            foreach (var group in query)
            {
                Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");
                foreach (var i in group)
                {
                    Console.WriteLine(i);
                }
            }

            // Output:
            //Odd numbers:
            //35
            //3987
            //199
            //329

            //Even numbers:
            //44
            //200
            //84
            //4
            //446
            //208
        }
    }
}
