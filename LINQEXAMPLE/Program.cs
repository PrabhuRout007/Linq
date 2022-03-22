using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQEXAMPLE
{
    class Program
    {
        static void Main(string[] args)
        {

            var empolyee = new List<Employee>()
            {
              new Employee() {Id=101, Name="Prabhu", Tech="C#", Salary= 30000, Dept_Id =1, C_Id = 101 },
              new Employee() {Id=102, Name="Shuvam", Tech ="C#", Salary= 30000 , Dept_Id =1,C_Id =102},
              new Employee() {Id=103, Name="Shubham", Tech="Excel", Salary= 40000 },
              new Employee() {Id=104, Name="Srikant", Tech ="Javascript", Salary= 50000, Dept_Id =2, C_Id = 101 },
              new Employee() {Id=105, Name="Akruti", Tech="Java", Salary =60000, Dept_Id =3 },
              new Employee() {Id=106, Name="Aman", Tech ="Python", Salary= 70000, Dept_Id =3, C_Id = 101 },
              new Employee() {Id=107, Name="Suman", Tech="C#", Salary= 30000, Dept_Id =1 },
              new Employee() {Id=108, Name="Neha", Tech ="C#", Salary= 30000 , Dept_Id =1,C_Id =102},
              new Employee() {Id=109, Name="Amit", Tech="Excel", Salary= 40000 },
              new Employee() {Id=110, Name="Athar", Tech ="Javascript", Salary= 50000, Dept_Id =2, C_Id = 101  },
              new Employee() {Id=111, Name="Ijaj", Tech="Java", Salary =60000, Dept_Id =3 },
              new Employee() {Id=112, Name="Anurag", Tech ="Python", Salary= 70000, Dept_Id =3,C_Id =102 },
              new Employee() {Id=113, Name="Minal", Tech="Java", Salary =60000, Dept_Id =3,C_Id =103 },
              new Employee() {Id=114, Name="Shruti", Tech ="Python", Salary= 70000, Dept_Id =3, C_Id = 101  },
              new Employee() {Id=115, Name="Sakshi", Tech="C#", Salary= 30000, Dept_Id =1,C_Id =102 },
              new Employee() {Id=116, Name="Priyanka", Tech ="C#", Salary= 30000 , Dept_Id =1},
              new Employee() {Id=117, Name="Priyam", Tech="Excel", Salary= 40000,C_Id =103 },
              new Employee() {Id=118, Name="Surya", Tech ="Javascript", Salary= 50000, Dept_Id =2 },
              new Employee() {Id=119, Name="Dityang", Tech="Java", Salary =60000, Dept_Id =3 },
              new Employee() {Id=120, Name="Mohit", Tech ="Python", Salary= 70000, Dept_Id =3,C_Id =103 },
              new Employee() {Id=118, Name="Suresh", Tech ="Javascript", Salary= 50000,  },
              new Employee() {Id=119, Name="Ramesh", Tech="Java", Salary =60000, },
              new Employee() {Id=120, Name="Mahesh", Tech ="Python", Salary= 70000,}
            };

            var department = new List<Department>()
            {
             new Department() { Dept_Id =1, Department_Name ="development" },
             new Department() { Dept_Id =2, Department_Name ="front-end" },
             new Department() { Dept_Id =3, Department_Name ="back-end" }
            };

            var category = new List<Category>()
            {
              new Category() { C_Id =101, designation="Team Lead"},
              new Category() { C_Id =102, designation="Manager" },
              new Category() { C_Id =103, designation="CEO"},
   
            };

            /*var orderBy = (from emp in empolyee
                           orderby emp.Salary descending
                           select emp).ToList();

            foreach (var emp in orderBy)
            {
                Console.WriteLine("ID {0} Name {1}  Tech {2}   Salary {3}   Dept_Id {4} ", emp.Id, emp.Name, emp.Tech, emp.Salary, emp.Dept_Id) ;
            }*/

            /*var emps = (from dept in department
                        from emp in empolyee
                        where dept.Dept_Id == emp.Dept_Id
                        select emp).ToList();

            foreach (var emp in emps)
            {
                Console.WriteLine("ID: {0}, Name: {1}, Tech {2}, Dept_Id: {3}", emp.Id, emp.Name, emp.Tech, emp.Dept_Id);

            }*/

            /* var emps = (from dept in department
                        join emp in empolyee
                        on dept.Dept_Id equals emp.Dept_Id
                        where dept.Department_Name == "development"
                        select emp).ToList();

            foreach(var emp in emps)
            {

                Console.WriteLine("ID: {0}, Name: {1}, Tech: {2}, Salary: {3} ", emp.Id, emp.Name, emp.Tech, emp.Salary);

            }*/

            var ms = category.GroupJoin(empolyee, cat => cat.C_Id, emp => emp.C_Id, (cat, emp) => new { cat, emp });

            foreach (var item in ms)
            {
                Console.WriteLine("Category: {0}", item.cat.designation);

                foreach(var itemL in item.emp)
                {

                    Console.WriteLine("Id: {0}, Name: {1}, Tech: {2} ", itemL.Id, itemL.Name,
                        itemL.Tech);
                }
            }

            // Using Query Syntax
            Console.WriteLine("---------------------------------------------------");

            var query = from c in category
                        join e in empolyee on c.C_Id equals e.C_Id into e_group
                        select new { c, e_group };

            foreach (var item in query)
            {
                Console.WriteLine("Designation: {0} ", item.c.designation);

                foreach (var itemL in item.e_group)
                {
                    Console.WriteLine("Id: {0}, Name :{1}, Tech: {2}", itemL.Id, itemL.Name, itemL.Tech);
                }
            }

            // Left Join
            Console.WriteLine("------------------------LEFT JOIN-------------------------------------------");

            var queryS =  from emp in empolyee
                          join dept in department on emp.Dept_Id equals dept.Dept_Id into Employee_Id
                          from employee_id in Employee_Id.DefaultIfEmpty()
                          select new { emp, employee_id };

            foreach (var item in queryS)
            {
                Console.WriteLine(item.employee_id.Department_Name);
             
            }



        }
    }
}
