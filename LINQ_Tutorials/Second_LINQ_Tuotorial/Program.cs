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

            Orderby_Clause_Tutorial.OrderBySample1();
        }


















        //static void Main(string[] args)
        //{
        //    //// Get all students whose score on the first test was greater than 90.
        //    //// Create a query expression
        //    //// The first line could also be written as "var studentQuery = "
        //    //IEnumerable<Student> studentQuery =
        //    //    from student in students
        //    //    where student.Scores[0] > 90
        //    //    select student;

        //    //// Execute the query expression
        //    //foreach (var student in studentQuery)
        //    //{
        //    //    DisplayStudent(student);
        //    //}

        //    //var studentQuery2 =
        //    //    from student in students
        //    //    where student.Scores[0] > 90
        //    //    select new { student.First, student.Scores };

        //    //foreach (var student in studentQuery2)
        //    //{
        //    //    Console.WriteLine($"First name: {student.First}\nScore:");
        //    //    foreach (var score in student.Scores)
        //    //    {
        //    //        Console.Write($"{score} ");
        //    //    }
        //    //    Console.WriteLine();
        //    //}

        //    //var studentQuery3 =
        //    //   from student in students
        //    //   where student.Scores[0] > 90
        //    //   select new { name = $"{student.First} {student.Last}", firstTestScore = student.Scores[0] };

        //    //foreach (var student in studentQuery3)
        //    //{
        //    //    Console.WriteLine($"Name: {student.name}, First Test Score: {student.firstTestScore}");
        //    //}
        //}

        private static void DisplayStudent(Student student)
        {
            Console.WriteLine($"First: {student.First}, Last: {student.Last}, ID: {student.ID}");
            Console.Write("Scores: ");
            foreach (var score in student.Scores)
            {
                Console.Write($"{score} ");
            }
            Console.WriteLine();
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

        // Display content of a list of students
        private static void DisplayStudents(List<Student> students)
        {
            foreach (var stu in students)
            {
                Console.WriteLine($"First: {stu.First}, Last: {stu.Last}, ID: {stu.ID}");
                Console.Write("Scores: ");
                foreach (var score in stu.Scores)
                {
                    Console.Write($"{score} ");
                }
                Console.WriteLine();
            }
        }

    }
}
