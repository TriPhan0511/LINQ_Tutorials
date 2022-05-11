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

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { First = "Svetlana", Last = "Omelchenko", ID = 111 },
                new Employee { First = "Claire", Last = "O'Donnel", ID = 112 },
                new Employee { First = "Sven", Last = "Mortensen", ID = 113 },
                new Employee { First = "Cesar", Last = "Garcia", ID = 114 },
                new Employee { First = "Debra", Last = "Garcia", ID = 115 },
            };
            return employees;
        }


        public static void Show()
        {

        }
    }
}
