using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_LINQ_Tuotorial
{
    internal class Group_Clause_Tutorial
    {
        // A query with a group clause produces a sequence of groups,
        // and each group itself contains a Key and a sequence that consists of
        // all the member of that group.

        // The following example groups the students by using the first letter
        // of their last name as the key.

        public static void Show()
        {
            // Create the data source
            List<Student> students = GetStudents();

            //// Create the query
            //// Order by only the Key of group
            //// studentQuery is an IEnumerable<IGrouping<char, Student>>
            //// The query produces a sequence of groups that have a char type as a key,
            //// and a sequence of Student objects.
            //var studentQuery3 =
            //    from student in students
            //    group student by student.Last[0]; 

            //// Execute the query.
            //foreach (var studentGroup in studentQuery3)
            //{
            //    Console.WriteLine(studentGroup.Key);
            //    foreach (var student in studentGroup)
            //    {
            //        Console.WriteLine($"Last: {student.Last}, First: {student.First}, ID: {student.ID}");
            //    }
            //}

            // Output:
            //O
            //Last: Omelchenlko, First: Svetlana, ID: 111
            //Last: O'Donnell, First: Claire, ID: 112
            //M
            //Last: Mortensen, First: Sven, ID: 113
            //G
            //Last: Garcia, First: Caesar, ID: 114
            //Last: Garcia, First: Debra, ID: 115
            //Last: Garcia, First: Hugo, ID: 118
            //F
            //Last: Fakhouri, First: Fadi, ID: 116
            //Last: Feng, First: Hanying, ID: 117
            //T
            //Last: Tucker, First: Lance, ID: 119
            //Last: Tucker, First: Michael, ID: 122
            //A
            //Last: Adams, First: Terry, ID: 120
            //Z
            //Last: Zabokritski, First: Eugene, ID: 121
            //--------------------------------------------------------------------------------------------------------

            //// Order the groups by their key value
            //// When you run the previous query, you notice that the groups are not in alphabetical order.
            //// To change this, you must provide an orderby clause after the group clause.
            //// But to use an orderby clause, you first need an identifier that serves as a reference
            //// to the groups created by the group clause. You provide the identifer by using the into keyword.

            //var studentQuery4 =
            //    from student in students
            //    group student by student.Last[0] into studentGroup
            //    orderby studentGroup.Key
            //    select studentGroup;

            //foreach (var studentGroup in studentQuery4)
            //{
            //    Console.WriteLine(studentGroup.Key);
            //    foreach (var student in studentGroup)
            //    {
            //        Console.WriteLine($"Last: {student.Last}, First: {student.First}, ID: {student.ID}");
            //    }
            //}

            //// Output:
            ////A
            ////Last: Adams, First: Terry, ID: 120
            ////F
            ////Last: Fakhouri, First: Fadi, ID: 116
            ////Last: Feng, First: Hanying, ID: 117
            ////G
            ////Last: Garcia, First: Caesar, ID: 114
            ////Last: Garcia, First: Debra, ID: 115
            ////Last: Garcia, First: Hugo, ID: 118
            ////M
            ////Last: Mortensen, First: Sven, ID: 113
            ////O
            ////Last: Omelchenlko, First: Svetlana, ID: 111
            ////Last: O'Donnell, First: Claire, ID: 112
            ////T
            ////Last: Tucker, First: Lance, ID: 119
            ////Last: Tucker, First: Michael, ID: 122
            ////Z
            ////Last: Zabokritski, First: Eugene, ID: 121
            ////--------------------------------------------------------------------------------------------------------

            // To introduce an identifier by using let
            // You can use the let keyword to introduce an identifier for
            // any expression result in the query expression.
            // This identifier can be a convenience, as in the following example,
            // ot it can enhance performance by storing the resultsof an expression
            // so that it does not have to be calculated multiple times.

            // studentQuery5 is an IEnumerable<string>
            // This query returns those students whose
            // first test score was higher than their average score.
            var studentQuery5 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where totalScore / 4 < student.Scores[0]
                select $"{student.Last} {student.First}";

            foreach (var item in studentQuery5)
            {
                Console.WriteLine(item);
            }

            // Output:
            //Omelchenlko Svetlana
            //O'Donnell Claire
            //Mortensen Sven
            //Garcia Caesar
            //Fakhouri Fadi
            //Feng Hanying
            //Garcia Hugo
            //Adams Terry
            //Zabokritski Eugene
            //Tucker Michael
        }


        // Create a data source by using a collection initializer
        private static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student { First = "Svetlana", Last = "Omelchenlko", ID = 111, Scores = new List<int> { 97, 92, 81, 60 } },
                new Student { First = "Claire", Last = "O'Donnell", ID = 112, Scores = new List<int> { 75, 84, 91, 39 } },
                new Student { First = "Sven", Last = "Mortensen", ID = 113, Scores = new List<int> { 88, 94, 65, 91 } },
                new Student { First = "Caesar", Last = "Garcia", ID = 114, Scores = new List<int> { 97, 89, 85, 82 } },
                new Student { First = "Debra", Last = "Garcia", ID = 115, Scores = new List<int> { 35, 72, 91, 70 } },
                new Student { First = "Fadi", Last = "Fakhouri", ID = 116, Scores = new List<int> { 99, 86, 90, 94 } },
                new Student { First = "Hanying", Last = "Feng", ID = 117, Scores = new List<int> { 93, 92, 80, 87 } },
                new Student { First = "Hugo", Last = "Garcia", ID = 118, Scores = new List<int> { 92, 90, 83, 78 } },
                new Student { First = "Lance", Last = "Tucker", ID = 119, Scores = new List<int> { 68, 79, 99, 92 } },
                new Student { First = "Terry", Last = "Adams", ID = 120, Scores = new List<int> { 99, 82, 81, 79 } },
                new Student { First = "Eugene", Last = "Zabokritski", ID = 121, Scores = new List<int> { 96, 85, 91, 60 } },
                new Student { First = "Michael", Last = "Tucker", ID = 122, Scores = new List<int> { 94, 92, 91, 91 } },
            };
            return students;
        }
    }


}
