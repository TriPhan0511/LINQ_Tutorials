// link: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_LINQ_Tuotorial
{
    internal class Query_Syntax_and_Method_Syntax
    {
        public static void Show()
        {
            int[] numbers = { 5, 10, 8, 3, 6, 12 };

            // Query syntax
            IEnumerable<int> numQuery1 =
                from num in numbers
                where num % 2 == 0
                orderby num
                select num;

            // Method syntax
            IEnumerable<int> numQuery2 = numbers.Where(num => num % 2 == 0).OrderBy(num => num);

            foreach (int i in numQuery1)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
            foreach (int i in numQuery2)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
