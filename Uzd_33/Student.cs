using System;
using System.Collections.Generic;
using System.Text;

namespace Uzd_33
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<int> Grades { get; set; }
        public double AvgGrade { get; set; }

<<<<<<< HEAD
        public int Age { get; set; }
=======
        public string Adress2 {get; set;}
>>>>>>> d2d3130 (Adress 2 added)

        public double CalculateAvgGrade()
        {
            double sum = 0;

            foreach (var grade in Grades)
            {
                sum += grade;
            }

            return sum/Grades.Count;
        }

        public void PrintProfile()
        {
            Console.WriteLine($"----- {Name} {LastName} -----");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine("List of grades: ");

            foreach(var grade in Grades)
            { Console.Write(grade + ", "); }

            Console.WriteLine($"\nAverage grade: {AvgGrade}");
        }

        public override string ToString()
        {
            return $"{Id}: {Name.ToUpper()} {LastName.ToUpper()}";
        }
    }


}
