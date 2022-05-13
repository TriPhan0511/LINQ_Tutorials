using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_LINQ_Tuotorial
{
    internal class Orderby_Clause_Tutorial_2
    {
        // The following example performs a primary sort on the employee's last names,
        // and then a secondary sort on their first name.

        public static void Show()
        {
            // Create the data source.
            List<Employee>  employees = GetEmployees();

            // Creat the query.
            var sortedEmployees =
                from emp in employees
                orderby emp.Last, emp.First
                select emp;

            // Execute the query
            Console.WriteLine("sortedEmployees:");
            foreach (var emp in sortedEmployees)
            {
                Console.WriteLine($"\tLast: {emp.Last}, First: {emp.First}, ID: {emp.ID}");
            }

            // Now create groups and sort the groups
            // The first orderby sorts the names of all employees so that they will be in alphabetical order after
            // they are grouped. The second orderby sorts the groups key in alpha order.
            var sortedGroups =
                from emp in employees
                orderby emp.Last, emp .First
                group emp by emp.Last[0] into newGroup
                orderby newGroup.Key 
                select newGroup;

            Console.WriteLine(Environment.NewLine + "sortedGroups:");
            foreach (var group in sortedGroups)
            {
                Console.WriteLine($"\t{group.Key}");
                foreach (var employee in group)
                {
                    Console.WriteLine($"\tLast: {employee.Last}, First: {employee.First}, ID: {employee.ID}");
                }
            }

        // Output:
        //sortedEmployees:
        //    Last: Garcia, First: Cesar, ID: 115
        //    Last: Garcia, First: Debra, ID: 114
        //    Last: Mortensen, First: Sven, ID: 113
        //    Last: O'Donnel, First: Claire, ID: 112
        //    Last: Omelchenko, First: Svetlana, ID: 111

        //sortedGroups:
    //            G
    //            Last: Garcia, First: Cesar, ID: 115
    //            Last: Garcia, First: Debra, ID: 114
    //            M
    //            Last: Mortensen, First: Sven, ID: 113
    //            O
    //            Last: O'Donnel, First: Claire, ID: 112
    //            Last: Omelchenko, First: Svetlana, ID: 111
        }

        // Use a collection initializer to create the data source
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { First = "Svetlana", Last = "Omelchenko", ID = 111 },
                new Employee { First = "Claire", Last = "O'Donnel", ID = 112 },
                new Employee { First = "Sven", Last = "Mortensen", ID = 113 },
                new Employee { First = "Debra", Last = "Garcia", ID = 114 },
                new Employee { First = "Cesar", Last = "Garcia", ID = 115 },
            };
            return employees;
        }


        
    }
}
