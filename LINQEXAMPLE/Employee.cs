using System;
using System.Collections.Generic;
using System.Text;

namespace LINQEXAMPLE
{
    class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Tech { get; set; }
        public int Salary { get; set; }

        public int Dept_Id { get; set; }

        public int C_Id { get; set; }
    }
    public class Category
    {
        public string designation { get; set; }
        public int C_Id { get; set; }
    }
}
