using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_LINQ_Tuotorial
{
    internal class Let_Clause_Tutorial
    {
        // In a query expression, it is sometimesuseful to store the result of a sub-expression
        // in order to use ut in subsequent clause. You can do this with the let keyword, which
        // creates a new range variable and initializes it with the result of the expression you supply.
        // Once initialized with a value, the range value cannot be used to store another value.
        // However, if the range variable holds a queryable type, it can be queried.

        // In the following example "let" is used in two ways:
        // 1. To create an enumerable type that can itself be queried.
        // 2. To enable the query to call ToLower method only one time on the range variable word.
        //      Without using let, you would have to call ToLower in each predicate in the where clause.
        public static void Show()
        {
            string[] strings =
        {
            "A penny saved is a penny earned.",
            "The early bird catches the worm.",
            "The pen is mightier than the sword."
        };

            // Split the sentence into an array of words
            // and select those whose first letter is a vowel.
            var earlyBirdQuery =
                from sentence in strings
                let words = sentence.Split(' ')
                from word in words
                let firstLetter = word.ToLower()[0]
                where firstLetter == 'a' ||
                    firstLetter == 'e' ||
                    firstLetter == 'o' ||
                    firstLetter == 'u' ||
                    firstLetter == 'i'
                select word;

            foreach (var word in earlyBirdQuery)
            {
                Console.WriteLine($"'{word}' starts with a vowel");
            }
        }

        
    }
}
