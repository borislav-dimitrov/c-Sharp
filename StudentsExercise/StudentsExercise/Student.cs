using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsExercise
{
    // make the class public so we can use it from all files
    public class Student
    {
        public string _name;
        public string _surName;
        public int _age;
        public string _speciality;
        public int _grade;
        public float _averageGpu;

        // new object constructor
        public Student(string name, string surName, int age, string speciality, int grade,float averageGpu)
        {
            _name = name;
            _surName = surName;
            _age = age;
            _speciality = speciality;
            _grade = grade;
            _averageGpu = averageGpu;
        }

        // public method to print all the info for a student
        public void PrintStudentInfo()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Info for student {_name} {_surName}");
            Console.WriteLine(_name);
            Console.WriteLine(_surName);
            Console.WriteLine(_age);
            Console.WriteLine(_speciality);
            Console.WriteLine(_grade);
            Console.WriteLine(_averageGpu);
        }
    }
}
