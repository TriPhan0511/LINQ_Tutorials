using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouping_Data
{
    internal class GroupSample
    {
        /*
            group clause

            Link: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/group-clause

            The group clause returns a sequence of IGrouping<TKey,TElement> objects that
            contains zero or more items that match the key value for the group.

            For example, you can group a sequence of strings according to the first letter in
            each string. In this case, the first letter is the key and has a type char, and
            is stored in the Key propertyof each IGrouping<TKey,TElement> object. The compiler
            infers the type of the key.

            You can end a query expression with a group clause, as shown in the following example:
                IEnumerable<IGrouping<char, string>> query =
                    from word in words
                    group word by word[0];

            If you want to perform additional query operations on each group, you can specify a
            temporary identifier by using the into contextual keyword. When you use the into keyword,
            you must continue with the query, and eventually end it with either a select statement or
            another group clause, as shown in the following excerpt:
                IEnumerable<IGrouping<char, string>> query =
                    from word in words
                    group word by word[0] into g
                    orderby g.Key
                    select g;

            *** Enumerating the results of a group query
            Because IGrouping<TKey,TElement> objects produced by a group query are essentially a list of lists,
            you must use a nested foreach loop to access the items in each group. The outer loop iterates over
            the group keys, and the inner loop iterates over each item in the group itself. A group may have a
            key but no elements. The following is the foreach loop that executes the query in the previous code examples:
                foreach (IGrouping<char, string> group in query)
                {
                    Console.WriteLine($"Words start with '{group.Key}':");
                    foreach (string word in group)
                    {
                        Console.WriteLine($"\t{word}");
                    }
                }
         */

        ////-----------------------------------------------------------------------------------------------------------------
        //public static void Main(string[] strings)
        //{
        //    string[] words = { "hello", "Hi", "aloha", "good morning", "good night", "have a nice day" };

        //    // Query syntax
        //    IEnumerable<IGrouping<char, string>> query =
        //        from word in words
        //        group word by word[0] into g
        //        orderby g.Key
        //        select g;

        //    //// Method syntax
        //    //IEnumerable<IGrouping<char, string>> query =
        //    //    words.GroupBy(word => word[0]).OrderBy(g => g.Key);

        //    foreach (IGrouping<char, string> group in query)
        //    {
        //        Console.WriteLine($"Words start with '{group.Key}':");
        //        foreach (string word in group)
        //        {
        //            Console.WriteLine($"\t{word}");
        //        }
        //    }

        //    // Output:
        //    //Words start with 'H':
        //    //        Hi
        //    //Words start with 'a':
        //    //        aloha
        //    //Words start with 'g':
        //    //        good morning
        //    //        good night
        //    //Words start with 'h':
        //    //        hello
        //    //        have a nice day
        //}

        ////-----------------------------------------------------------------------------------------------------------------
        //public static void Main(string[] strings)
        //{
        //    // The following example demonstrates how to group a sequence of strings
        //    // according to the first letter in each string
        //    string[] words = { "hello", "Hi", "aloha", "good morning", "good night", "have a nice day" };

        //    // Query syntax
        //    IEnumerable<IGrouping<char, string>> query =
        //            from word in words
        //            group word by word[0];

        //    //// Method syntax
        //    //IEnumerable<IGrouping<char, string>> query =
        //    //    words.GroupBy(word => word[0]);

        //    foreach (IGrouping<char, string> group in query)
        //    {
        //        Console.WriteLine($"The words start with letter '{group.Key}':");
        //        foreach (string word in group)
        //        {
        //            Console.WriteLine($"\t{word}");
        //        }
        //    }

        //    // Output:
        //    //The words start with letter 'h':
        //    //        hello
        //    //        have a nice day
        //    //The words start with letter 'H':
        //    //        Hi
        //    //The words start with letter 'a':
        //    //        aloha
        //    //The words start with letter 'g':
        //    //        good morning
        //    //        good night
        //}

        ////-----------------------------------------------------------------------------------------------------
        //// First example
        //public static void Main(string[] strings)
        //{
        //    string[] words = { "hello, ", "world", "my", "name", "is", "Alex" };
        //    //var query =
        //    IEnumerable<IGrouping<int, string>> query =
        //        from word in words
        //        group word by word.Length;

        //    //foreach (var group in query)
        //    foreach (IGrouping<int, string> group in query)
        //    {
        //        Console.WriteLine(group.Key);
        //        foreach (var item in group)
        //        {
        //            Console.WriteLine(item);
        //        }
        //    }
        //}
    }
}
