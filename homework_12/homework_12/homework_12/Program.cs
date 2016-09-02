using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_12
{
    class Program
    {
        static void Main(string[] args)
        {

            StudentRepository _school = new StudentRepository();

            _school.AddStudent();
            _school.Students[7].AddSubject();
            foreach (Student student in _school.Students)
            {
                student.GetMediumRating();
            }
            //_school.GetMedium();
            _school.ShowAllStudents();


            Console.ReadKey();
        }
    }
}