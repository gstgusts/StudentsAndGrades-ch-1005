using System;
using System.Collections.Generic;

namespace Uzd_33
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int input;

            while (true)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Menu: \n1-Register Student \n2-Print Student profile \n3-Print Student list  \n4-Remove Student \n5-Exit");
                Console.WriteLine("---------------------------------------------------");

                while (true)
                {

                    try
                    {
                        input = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter a valid number!");
                        continue;
                    }
                }

                MenuEnum menu = (MenuEnum)input;
                switch (menu)
                {
                    case MenuEnum.Register:
                        StudentManager.RegisterNewStudent(students);
                        break;
                    case MenuEnum.PrintProfile:
                        StudentManager.PrintStudentProfile(students);
                        break;
                    case MenuEnum.PrintList:
                        StudentManager.PrintAllStudents(students);
                        break;
                    case MenuEnum.Remove:
                        StudentManager.RemoveStudent(students);
                        break;
                    case MenuEnum.Exit:
                        Console.WriteLine("Shutting down...");
                        return;
                    default:
                        Console.WriteLine("Unknown command :(");
                        continue;
                }

            }
        }

    }
}

