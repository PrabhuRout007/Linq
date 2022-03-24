using System;
using System.Collections.Generic;
using System.Linq;


namespace QuantifierOperation
{
    class Program
    {
        static void Main(string[] args)
        {

            Student[] students = {
                new Student { Name = "Prabhu", Marks = 300,
                    Subject = new List<Subject>()
                    {
                        new Subject() { SubjectName = "Physics", SubjectMarks = 90 },
                        new Subject() { SubjectName = "Chemistry", SubjectMarks = 80 },
                        new Subject() { SubjectName = "Biology", SubjectMarks = 70 },
                        new Subject() { SubjectName = "Maths", SubjectMarks = 60 },
                    }

                },
                new Student { Name = "Shuvam", Marks = 340,
                    Subject = new List<Subject>()
                    {
                        new Subject() { SubjectName = "Physics", SubjectMarks = 100 },
                        new Subject() { SubjectName = "Chemistry", SubjectMarks = 60 },
                        new Subject() { SubjectName = "Biology", SubjectMarks = 90 },
                        new Subject() { SubjectName = "Maths", SubjectMarks = 80 },
                    }
                },
                new Student { Name = "Srikant", Marks = 340,
                    Subject = new List<Subject>()
                    {
                        new Subject() { SubjectName = "Physics", SubjectMarks = 70 },
                        new Subject() { SubjectName = "Chemistry", SubjectMarks = 90 },
                        new Subject() { SubjectName = "Biology", SubjectMarks = 100 },
                        new Subject() { SubjectName = "Maths", SubjectMarks = 80 },
                    }
                },
                new Student { Name = "Subham", Marks = 310,
                    Subject = new List<Subject>()
                    {
                        new Subject() { SubjectName = "Physics", SubjectMarks = 100 },
                        new Subject() { SubjectName = "Chemistry", SubjectMarks = 80 },
                        new Subject() { SubjectName = "Biology", SubjectMarks = 80 },
                        new Subject() { SubjectName = "Maths", SubjectMarks = 80 },
                    }
                },
                new Student { Name = "Messi", Marks = 200,
                    Subject = new List<Subject>()
                    {
                        new Subject() { SubjectName = "Physics", SubjectMarks = 40},
                        new Subject() { SubjectName = "Chemistry", SubjectMarks = 40 },
                        new Subject() { SubjectName = "Biology", SubjectMarks = 40 },
                        new Subject() { SubjectName = "Maths", SubjectMarks = 50 },
                    }
                },
            };


            // fetch all records whether a student got more than 50 marks in all subjects.
            #region All
            var morethan70 = students.Where(std => std.Subject.All(std => std.SubjectMarks > 70)).Select(std => std);


            foreach (var item in morethan70)
            {

                Console.WriteLine("Name: {0}", item.Name);

                foreach (var itemL in item.Subject)
                {
                    Console.WriteLine("SubjectName : {0}, SubjectMarks: {1} ", itemL.SubjectName, itemL.SubjectMarks);
                }
            }
            #endregion

            #region Any

            var ms = students.Where(std => std.Subject.Any(x => x.SubjectMarks < 50)).Select(std => std);
            foreach (var item in ms)
            {
                Console.WriteLine("Name: {0}", item.Name);
                foreach (var itemL in item.Subject)
                {
                    Console.WriteLine("SubjectName : {0}, SubjectMarks: {1} ", itemL.SubjectName, itemL.SubjectMarks);
                }
            }
        }
            #endregion

        class Student
        {
            public int Marks { get; set; }
            public string Name { get; set; }
            public List<Subject> Subject { get; set; }
        }

        class Subject
        {
            public int SubjectMarks { get; set; }

            public string SubjectName { get; set; }
        }
    }
}
