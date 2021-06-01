using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uzd_33
{
    class StudentManager
    {
        private List<Student> _students { get; set; } = new List<Student>();

        public void RegisterNewStudent()
        {
            Student student = new Student();
            Random rando = new Random();

            Console.Write("Name: ");
            student.Name = Console.ReadLine().ToUpper().Trim();

            Console.Write("Last Name: ");
            student.LastName = Console.ReadLine().ToUpper().Trim();

            //DIY Id generating
            student.Id = student.Name.Substring(0, 1).ToLower() + 
                student.LastName.Substring(0,1).ToLower() + 
                rando.Next(100, 1000).ToString();

            student.Grades = EnterGrades();

            student.AvgGrade = Math.Round(student.CalculateAvgGrade(), 2);

            _students.Add(student);
        }

        public void PrintStudentProfile()
        {
            var identifiedStudent = FindStudent();

            if (identifiedStudent != null)
            {
                identifiedStudent.PrintProfile();
            }               
        }

        public void PrintAllStudents()
        {
            foreach (var student in _students)
            {
                Console.WriteLine(student);
            }
        }

        public void RemoveStudent()
        {
            var identifiedStudent = FindStudent();

            if(identifiedStudent!=null)
            {
                _students.Remove(identifiedStudent);
            }
        }

        private List<int> EnterGrades()
        {
            var list = new List<int>();

            while(true)
            {
                Console.Write("Enter grade: ");
                while (true)
                {
                    try
                    {
                        list.Add(int.Parse(Console.ReadLine()));
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter a valid number!");
                        continue;
                    }
                }

                while(true)
                {
                    Console.WriteLine("Would you like to enter another grade? (y/n)");
                    var input = Console.ReadLine().ToLower();
                    if(input == "y")
                    {
                        break; 
                    }
                    else if(input == "n")
                    { 
                        return list; 
                    }
                    else
                    { 
                        Console.WriteLine("Type 'y' or 'n'"); 
                    }
                }
            }
        }

        private Student FindStudent()
        {
            Student identifiedStudent = new Student();


            Console.WriteLine("Enter student ID: ");
            try
            {
                var input = Console.ReadLine();
                identifiedStudent = _students.Find(student => (student.Id == input));
                return identifiedStudent;
            }
            catch (Exception)
            {
                Console.WriteLine("No such ID in the database.");
                return null;
            }
        }
    }
}
