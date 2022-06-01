using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouping_Data
{
    internal class GroupSample1
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
                IEnumerable<IGrouping<char, Student>> studentQuery1 =
                    from student in students
                    group student by student.Last[0];

            If you want to perform additional query operations on each group, you can specify a
            temporary identifier by using the into contextual keyword. When you use the into keyword,
            you must continue with the query, and eventually end it with either a select statement or
            another group clause, as shown in the following excerpt:
                IEnumerable<IGrouping<char, Student>> studentQuery2 =
                    from student in students
                    group student by student.Last[0] into g
                    orderby g.Key 
                    select g;

            *** Enumerating the results of a group query
            Because IGrouping<TKey,TElement> objects produced by a group query are essentially a list of lists,
            you must use a nested foreach loop to access the items in each group. The outer loop iterates over
            the group keys, and the inner loop iterates over each item in the group itself. A group may have a
            key but no elements. The following is the foreach loop that executes the query in the previous code examples:
                foreach (IGrouping<char, Student> group in studentQuery2)
                {
                    Console.WriteLine($"The students whose last name start with letter '{group.Key}' are:");
                    foreach (Student s in group)
                    {
                        Console.WriteLine($"\tFirst: {s.First}, Last: {s.Last}, ID: {s.ID}");
                    }
                }
         */

        /*
            Key types

            Group keys can be any type, such as a string, a built-in numeric type, or a user-defined named type or
            anonymous type.

            1. GROUPING BY STRING
                    IEnumerable<IGrouping<string, Student>> query =
                        from student in students
                        group student by student.Last;

                    foreach (IGrouping<string, Student> group in query)
                    {
                        Console.WriteLine($"Last name: {group.Key}: ");
                        foreach (Student s in group)
                        {
                            Console.WriteLine($"\tFirst: {s.First}, Last: {s.Last}, ID: {s.ID}");
                        }
                    }
            
            2. GROUPING BY CHAR
                IEnumerable<IGrouping<char, Student>> studentQuery1 =
                    from student in students
                    group student by student.Last[0];

                foreach (IGrouping<char, Student> group in studentQuery1)
                {
                    Console.WriteLine($"The students whose last name start with letter '{group.Key}' are:");
                    foreach (Student s in group)
                    {
                        Console.WriteLine($"\tFirst: {s.First}, Last: {s.Last}, ID: {s.ID}");
                    }
                }

            3. GROUPING BY BOOL
                //IEnumerable<IGrouping<bool, Student>> booleanGroupQuery =
                var booleanGroupQuery =
                    from student in students
                    group student by student.Scores.Average() > 80; // pass or fail

                //foreach (IGrouping<bool, Student> group in booleanGroupQuery)
                foreach (var group in booleanGroupQuery)
                {
                    Console.WriteLine(group.Key == true ? "High averages" : "Low averages");
                    foreach (Student s in group)
                    {
                        Console.Write($"Last: {s.Last}, First: {s.First}, ID: {s.ID}, Scores: ");
                        foreach (int score in s.Scores)
                        {
                            Console.Write($"{score} ");
                        }
                        Console.WriteLine($", Average score: {s.Scores.Average()}");
                    }
                    Console.WriteLine();
                }

            4. GROUPING BY NUMERIC RANGE
                IEnumerable<IGrouping<int, Student>> studentQuery =
                from student in students
                let avg = (int)student.Scores.Average()
                group student by (avg / 10) into g
                orderby g.Key
                select g;

                foreach (var group in studentQuery)
                {
                    int temp = group.Key * 10;
                    Console.WriteLine($"Students with an average between {temp} and {temp + 10}");
                    foreach (var s in group)
                    {
                        Console.Write($"\tLast: {s.Last}, First: {s.First}, ID: {s.ID}, Scores: ");
                        foreach (int score in s.Scores)
                        {
                            Console.Write($"{score} ");
                        }
                        Console.WriteLine($", Average score: {s.Scores.Average()}");
                    }
                }
         */
        //------------------------------------------------------------------------------------------------------------------------

        /*
            5. GROUPING BY CO0MPOSITE KEYS

            Use a composite key when you want to group elements according to more than one key.
            You create a composite key by using an anonymous type or a named type to hold the key element.
            
            In the following example, assume that a class "Person" has been declared with members named "Surname"
            and "City". The group clause causes a seperate group to be created for each set of persons with the
            same last name and the same city.

                var query =
                    from person in persons
                    group person by new { surname = person.SurName, city = person.City };
         */
        public static void Main(string[] strings)
        {
            // Get the data source
            var persons = GetPersons();

            // Create the query
            var query =
                from person in persons
                group person by new { surname = person.SurName, city = person.City };

            // Execute the query
            foreach (var group in query)
            {
                Console.WriteLine($"Peple whose last name are {group.Key.surname} and are living in {group.Key.city}:");
                foreach (var person in group)
                {
                    Console.WriteLine($"\tSurname: {person.SurName}, City: {person.City}, ID: {person.ID}");
                }
            }

            // Ouput:
            //Peple whose last name are Alex and are living in New York:
            //        Surname: Alex, City: New York, ID: 1
            //        Surname: Alex, City: New York, ID: 3
            //Peple whose last name are Alex and are living in Tokyo:
            //        Surname: Alex, City: Tokyo, ID: 2
            //Peple whose last name are Brad and are living in Tokyo:
            //        Surname: Brad, City: Tokyo, ID: 4
            //Peple whose last name are Mary and are living in Danang:
            //        Surname: Mary, City: Danang, ID: 5
        }

        //------------------------------------------------------------------------------------------------------------------------
        /* 
            4. GROUPING BY NUMERIC RANGE
        
            The following example uses an expression to create numeric groups keys that represent a percentile range.
            Note the use of let as a convenient location to store a method call result, so that you don't have to call
            the method two times in the group clause.

            The following example groups students into percentile ranges based on their grade average.
            The Average method returns a double, so to produce a whole number it is necessary to cast
            to int before dividing by 10.
         */
        //public static void Main(string[] strings)
        //{
        //    // Obtain the data source
        //    List<Student> students = GetStudents();

        //    // Write the query
        //    IEnumerable<IGrouping<int, Student>> studentQuery =
        //    from student in students
        //    let avg = (int)student.Scores.Average()
        //    group student by (avg / 10) into g
        //    orderby g.Key
        //    select g;

        //    // Execute the query
        //    foreach (var group in studentQuery)
        //    {
        //        int temp = group.Key * 10;
        //        Console.WriteLine($"Students with an average between {temp} and {temp + 10}");
        //        foreach (var s in group)
        //        {
        //            Console.Write($"\tLast: {s.Last}, First: {s.First}, ID: {s.ID}, Scores: ");
        //            foreach (int score in s.Scores)
        //            {
        //                Console.Write($"{score} ");
        //            }
        //            Console.WriteLine($", Average score: {s.Scores.Average()}");
        //        }
        //    }

        //    // Output:
        //    //Students with an average between 70 and 80
        //    //        Last: Omelchenko, First: Svetlana, ID: 111, Scores: 97 72 81 60 , Average score: 77.5
        //    //        Last: O'Donnell, First: Claire, ID: 112, Scores: 75 84 91 39 , Average score: 72.25
        //    //        Last: Garcia, First: Cesar, ID: 114, Scores: 72 81 65 84 , Average score: 75.5
        //    //Students with an average between 80 and 90
        //    //        Last: Garcia, First: Debra, ID: 115, Scores: 97 89 85 82 , Average score: 88.25
        //    //Students with an average between 90 and 100
        //    //        Last: Mortensen, First: Sven, ID: 113, Scores: 99 89 91 95 , Average score: 93.5
        //}

        //------------------------------------------------------------------------------------------------------------------------
        /* 3. GROUPING BY BOOL */
        //public static void Main(string[] strings)
        //{
        //    // Obtain the data soure
        //    List<Student> students = GetStudents();

        //    // The following example shows the use of a bool value for a key to divide the results
        //    // into two groups. Note that the value is produced by a sub-expression in the group clause.

        //    // Group by true or false
        //    //IEnumerable<IGrouping<bool, Student>> booleanGroupQuery =
        //    var booleanGroupQuery =
        //        from student in students
        //        group student by student.Scores.Average() > 80; // pass or fail

        //    //foreach (IGrouping<bool, Student> group in booleanGroupQuery)
        //    foreach (var group in booleanGroupQuery)
        //    {
        //        Console.WriteLine(group.Key == true ? "High averages" : "Low averages");
        //        foreach (Student s in group)
        //        {
        //            Console.Write($"\tLast: {s.Last}, First: {s.First}, ID: {s.ID}, Scores: ");
        //            foreach (int score in s.Scores)
        //            {
        //                Console.Write($"{score} ");
        //            }
        //            Console.WriteLine($", Average score: {s.Scores.Average()}");
        //        }
        //        Console.WriteLine();
        //    }

        //    // Output:
        //    //Low averages
        //    //        Last: Omelchenko, First: Svetlana, ID: 111, Scores: 97 72 81 60 , Average score: 77.5
        //    //        Last: O'Donnell, First: Claire, ID: 112, Scores: 75 84 91 39 , Average score: 72.25
        //    //        Last: Garcia, First: Cesar, ID: 114, Scores: 72 81 65 84 , Average score: 75.5

        //    //High averages
        //    //        Last: Mortensen, First: Sven, ID: 113, Scores: 99 89 91 95 , Average score: 93.5
        //    //        Last: Garcia, First: Debra, ID: 115, Scores: 97 89 85 82 , Average score: 88.25
        //}

        //------------------------------------------------------------------------------------------------------------------------
        /* 2. GROUPING BY CHAR */
        //public static void Main(string[] strings)
        //{
        //    // Obtain the data source
        //    List<Student> students = GetStudents();

        //    // The following example group the students by the first letter of their last names
        //    IEnumerable<IGrouping<char, Student>> studentQuery1 =
        //        from student in students
        //        group student by student.Last[0];

        //    foreach (IGrouping<char, Student> group in studentQuery1)
        //    {
        //        Console.WriteLine($"The students whose last name start with letter '{group.Key}' are:");
        //        foreach (Student s in group)
        //        {
        //            Console.WriteLine($"\tFirst: {s.First}, Last: {s.Last}, ID: {s.ID}");
        //        }
        //    }
        //    Console.WriteLine();


        //    // The following example group the student by the first letter of their last names
        //    // then order that first letter in ascending order.
        //    IEnumerable<IGrouping<char, Student>> studentQuery2 =
        //        from student in students
        //        group student by student.Last[0] into g
        //        orderby g.Key
        //        select g;

        //    //// Method syntax
        //    //IEnumerable<IGrouping<char, Student>> studentQuery2 =
        //    //    students.GroupBy(s => s.Last[0]).OrderBy(g => g.Key);

        //    foreach (IGrouping<char, Student> group in studentQuery2)
        //    {
        //        Console.WriteLine($"The students whose last name start with letter '{group.Key}' are:");
        //        foreach (Student s in group)
        //        {
        //            Console.WriteLine($"\tFirst: {s.First}, Last: {s.Last}, ID: {s.ID}");
        //        }
        //    }
        //    Console.WriteLine();

        //    // The following example order the students by their first name then
        //    // group them by the first letter of their last names and
        //    // finally, order by the first letter of last names
        //    IEnumerable<IGrouping<char, Student>> studentQuery22 =
        //        from student in students
        //        orderby student.First
        //        group student by student.Last[0] into g
        //        orderby g.Key
        //        select g;

        //    //// Method syntax:
        //    //IEnumerable<IGrouping<char, Student>> studentQuery22 =
        //    //    students.OrderBy(s => s.First).GroupBy(s => s.Last[0]).OrderBy(g => g.Key);

        //    foreach (IGrouping<char, Student> group in studentQuery22)
        //    {
        //        Console.WriteLine($"The students whose last name start with letter '{group.Key}' are:");
        //        foreach (Student s in group)
        //        {
        //            Console.WriteLine($"\tFirst: {s.First}, Last: {s.Last}, ID: {s.ID}");
        //        }
        //    }
        //    Console.WriteLine();

        //    // Output:
        //    //The students whose last name start with letter 'O' are:
        //    //        First: Svetlana, Last: Omelchenko, ID: 111
        //    //        First: Claire, Last: O'Donnell, ID: 112
        //    //The students whose last name start with letter 'M' are:
        //    //        First: Sven, Last: Mortensen, ID: 113
        //    //The students whose last name start with letter 'G' are:
        //    //        First: Cesar, Last: Garcia, ID: 114
        //    //        First: Debra, Last: Garcia, ID: 115

        //    //The students whose last name start with letter 'G' are:
        //    //        First: Cesar, Last: Garcia, ID: 114
        //    //        First: Debra, Last: Garcia, ID: 115
        //    //The students whose last name start with letter 'M' are:
        //    //        First: Sven, Last: Mortensen, ID: 113
        //    //The students whose last name start with letter 'O' are:
        //    //        First: Svetlana, Last: Omelchenko, ID: 111
        //    //        First: Claire, Last: O'Donnell, ID: 112

        //    //The students whose last name start with letter 'G' are:
        //    //        First: Cesar, Last: Garcia, ID: 114
        //    //        First: Debra, Last: Garcia, ID: 115
        //    //The students whose last name start with letter 'M' are:
        //    //        First: Sven, Last: Mortensen, ID: 113
        //    //The students whose last name start with letter 'O' are:
        //    //        First: Claire, Last: O'Donnell, ID: 112
        //    //        First: Svetlana, Last: Omelchenko, ID: 111
        //}

        // ----------------------------------------------------------------------------------
        /* 1. GROUPING BY STRING */
        //public static void Main(string[] strings)
        //{
        //    // Obtain the data source
        //    List<Student> students = GetStudents();

        //    // The following example group the students by their last names
        //    IEnumerable<IGrouping<string, Student>> studentQuery3 =
        //        from student in students
        //        group student by student.Last;

        //    ////// Method syntax (addition: order by last name)
        //    //IEnumerable<IGrouping<string, Student>> studentQuery3 =
        //    //    students.GroupBy(s => s.Last).OrderBy(g => g.Key);

        //    foreach (IGrouping<string, Student> group in studentQuery3)
        //    {
        //        Console.WriteLine($"Last name: {group.Key}: ");
        //        foreach (Student s in group)
        //        {
        //            Console.WriteLine($"\tFirst: {s.First}, Last: {s.Last}, ID: {s.ID}");
        //        }
        //    }
        //    // Output:
        //    //Last name: Omelchenko:
        //    //        First: Svetlana, Last: Omelchenko, ID: 111
        //    //Last name: O'Donnell:
        //    //        First: Claire, Last: O'Donnell, ID: 112
        //    //Last name: Mortensen:
        //    //        First: Sven, Last: Mortensen, ID: 113
        //    //Last name: Garcia:
        //    //        First: Cesar, Last: Garcia, ID: 114
        //    //        First: Debra, Last: Garcia, ID: 115
        //}




        public static List<Student> GetStudents()
        {
            // Use a collection nitializer to create the data source. Note that each element
            // in the list contains an inner sequence of scores.
            List<Student> students = new List<Student>
            {
                new Student { First = "Svetlana", Last = "Omelchenko", ID = 111, Scores = new List<int> { 97, 72, 81, 60 } },
                new Student { First = "Claire", Last = "O'Donnell", ID = 112, Scores = new List<int> { 75, 84, 91, 39} },
                new Student { First = "Sven", Last = "Mortensen", ID = 113, Scores = new List<int> { 99, 89, 91, 95 } },
                new Student { First = "Cesar", Last = "Garcia", ID = 114, Scores = new List<int> { 72, 81, 65, 84 } },
                new Student { First = "Debra", Last = "Garcia", ID = 115, Scores = new List<int> { 97, 89, 85, 82 } },
            };
            return students;
        }

        // The element type of the data source
        public class Student
        {
            public int ID { get; set; }
            public string First { get; set; }
            public string Last { get; set; }
            public List<int> Scores { get; set; }
        }


        // Use foR 5. GROUPING BY COMPOSITE KEY
        public class Person
        {
            public int ID { get; set; }
            public string SurName { get; set; }
            public string City { get; set; }
        }

        public static List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>()
            {
                new Person{SurName = "Alex", City = "New York", ID = 1},
                new Person{SurName = "Alex", City = "Tokyo", ID = 2},
                new Person{SurName = "Alex", City = "New York", ID = 3},
                new Person{SurName = "Brad", City = "Tokyo", ID = 4},
                new Person{SurName = "Mary", City = "Danang", ID = 5},
            };
            return persons;
        }
    }
}
