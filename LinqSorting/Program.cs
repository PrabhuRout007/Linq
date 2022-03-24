using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var datasource = new List<Employee>
            {
             new Employee {
              ID =101,
              FirstName = "Aman",
              LastName = "kumar",
              Email ="amansing@gmail.com"
             },
              new Employee {
              ID =102,
              FirstName = "Aman",
              LastName = "mishra",
              Email ="amanmishra@gmail.com"
             },
               new Employee {
              ID =102,
              FirstName = "Aman",
              LastName = "mishra",
              Email ="amanamishra@gmail.com"
             },
               new Employee {
              ID =103,
              FirstName = "Aman",
              LastName = "Singh",
              Email ="amansing@gmail.com"
             },
              new Employee {
              ID =104,
              FirstName = "Akash",
              LastName = "Deep",
              Email ="Aakashdeep@gmail.com"
             },
               new Employee {
              ID =101,
              FirstName = "Bhart",
              LastName = "kumar",
              Email ="bhrat@gmail.com"
             },
                new Employee {
              ID =105,
              FirstName = "Bipin",
              LastName = "kishore",
              Email ="bipin@gmail.com"
             },

            };

            // Query Syntax

            var qs = from emp in datasource
                     orderby emp.FirstName, emp.LastName
                     select emp;

            foreach (var item in qs)
            {
                Console.WriteLine("Id: {0}, FisrtName: {1}, LastName {2}, Email: {3}", item.ID, item.FirstName, item.LastName, item.Email);
            
            }

            Console.WriteLine("-----------------Method Syntax-------------------");

            //Method Syntax

            var ms = datasource.OrderBy(emp => emp.FirstName).ThenBy(emp => emp.LastName).ThenBy(emp => emp.Email);

            foreach (var item in ms)
            {
                Console.WriteLine("Id: {0}, FisrtName: {1}, LastName {2}, Email: {3}", item.ID, item.FirstName, item.LastName, item.Email);

            }
        }
    }
}
