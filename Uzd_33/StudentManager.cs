using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uzd_33
{
    class StudentManager
    {
        public static void RegisterNewStudent(List<Student> list)
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

            list.Add(student);

        }

        public static void PrintStudentProfile(List<Student> list)
        {
            var identifiedStudent = FindStudent(list);

            if (identifiedStudent != null)
            {
                identifiedStudent.PrintProfile();
            }
            else 
            { return; }
                
        }

        public static void PrintAllStudents(List<Student> list)
        {
            foreach (var student in list)
            {
                Console.WriteLine(student);
            }
        }

        public static void RemoveStudent(List<Student> list)
        {
            var identifiedStudent = FindStudent(list);

            if(identifiedStudent!=null)
            {
                list.Remove(identifiedStudent);
            }
            else
            { return; }
        }

        private static List<int> EnterGrades()
        {
            List<int> list = new List<int>();

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
                    { break; }
                    else if(input == "n")
                    { return list; }
                    else
                    { Console.WriteLine("Type 'y' or 'n'"); }
                }

            }
        }

        private static Student FindStudent(List<Student> list)
        {
            Student identifiedStudent = new Student();


            Console.WriteLine("Enter student ID: ");
            try
            {
                var input = Console.ReadLine();
                identifiedStudent = list.Find(student => (student.Id == input));
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
