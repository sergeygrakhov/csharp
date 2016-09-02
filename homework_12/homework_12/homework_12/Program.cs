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
            //for (int i = 0; i < _students.Students.Count; i++)
            //{

            //}
            foreach (var item in _school.Students)
            {
                Console.WriteLine(item.Name + " ");
                foreach (var item2 in item.SubjectRatings.Subjects)
                {
                    Console.Write(item2.Name + " ");
                    Console.Write(item2.Rating);
                }
                //Console.WriteLine(item.SubjectRatings.Subjects[1].);
            }
            Console.ReadKey();
        }
    }
}
