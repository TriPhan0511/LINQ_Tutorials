// Link: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/walkthrough-writing-queries-linq

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_LINQ_Tuotorial
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //// Create the query.
            //// The first line could also be written as "var studentQurery = "
            //IEnumerable<Student> studentQuery = 
            //    from student in students
            //    where student.Scores[0] > 90
            //    select student;

            //// Execute the query.
            //// var could be used here also.
            //foreach (Student student in studentQuery)
            //{
            //    Console.WriteLine($"{student.Last}, {student.First}");
            //}

            //// Output:
            ////Omelchenlko, Svetlana
            ////Garcia, Caesar
            ////Fakhouri, Fadi
            ////Feng, Hanying
            ////Garcia, Hugo
            ////Adams, Terry
            ////Zabokritski, Eugene
            ////Tucker, Michael
            ////--------------------------------------------------------------------------------
            ///

            //// Add another filter condition
            //// You can combine multiple Boolean conditions in the where clause in order to
            //// further refine a query.
            //var studentQuery = 
            //    from student in students
            //    where student.Scores[0] > 90 && student.Scores[3] < 80
            //    select student;

            //foreach (var student in studentQuery)
            //{
            //    Console.WriteLine($"{student.Last}, {student.First}");
            //}

            //// Output:
            ////Omelchenlko, Svetlana
            ////Garcia, Hugo
            ////Adams, Terry
            ////Zabokritski, Eugene
            ////--------------------------------------------------------------------------------

            // Modify the Query

            //// To order the results: use orderby clause
            //var studentQuery =
            //    from student in students
            //    where student.Scores[0] > 90
            //    //orderby student.Last ascending
            //    orderby student.Scores[0] descending
            //    select student;

            //foreach (var student in studentQuery)
            //{
            //    //Console.WriteLine($"{student.Last}, {student.First}");
            //    Console.WriteLine($"{student.Last}, {student.First}, {student.Scores[0]}");
            //}

            //// Output:
            ////Adams, Terry
            ////Fakhouri, Fadi
            ////Feng, Hanying
            ////Garcia, Caesar
            ////Garcia, Hugo
            ////Omelchenlko, Svetlana
            ////Tucker, Michael
            ////Zabokritski, Eugene
            //---------------------------------------------------------------------------------------

            //Orderby_Clause_Tutorial.OrderBySample1();
            //Orderby_Clause_Tutorial_2.Show();
            //---------------------------------------------------------------------------------------

            //Group_Clause_Tutorial.Show();
            //---------------------------------------------------------------------------------------

            //Let_Clause_Tutorial.Show();
            //---------------------------------------------------------------------------------------

            //Query_Syntax_and_Method_Syntax.Show();
            //---------------------------------------------------------------------------------------

            // To transform or project in the select clause
            // It is very common for a query to produce a sequence whose element differ from
            // the elements in the source sequences.

            //IEnumerable<string> studentQuery7 =
            //    from student in students
            //    where student.Last == "Garcia"
            //    select student.First;

            //Console.WriteLine("The Garcias in the class are:");
            //foreach (string firstName in studentQuery7)
            //{
            //    Console.WriteLine(firstName);
            //}

            //// Output:
            ////The Garcias in the class are :
            ////Caesar
            ////Debra
            ////Hugo
            ////---------------------------------------------------------------------------------------

            // Use an anonymous type
            // To produce a sequence of Students whose total score is greater than the class average,
            // together with their Student ID, you can use an anonymous type in the select statement.

            var studentQuery6 =
                from student in students
                let totalScore =
                    student.Scores[0] +
                    student.Scores[1] +
                    student.Scores[2] +
                    student.Scores[3]
                select totalScore;

            var averageScoreOfClass = studentQuery6.Average(); // 335.08

            var studentQuery8 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                where totalScore > averageScoreOfClass
                select new { id = student.ID, score = totalScore };

            foreach (var item in studentQuery8)
            {
                Console.WriteLine($"ID: {item.id}, Total Score: {item.score}");
            }

            // Output:
            //ID: 113, Total Score: 338
            //ID: 114, Total Score: 353
            //ID: 116, Total Score: 369
            //ID: 117, Total Score: 352
            //ID: 118, Total Score: 343
            //ID: 119, Total Score: 338
            //ID: 120, Total Score: 341
            //ID: 122, Total Score: 368
        }

        // Create a data source by using a collection initializer
        static List<Student> students = new List<Student>
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
    }
}
