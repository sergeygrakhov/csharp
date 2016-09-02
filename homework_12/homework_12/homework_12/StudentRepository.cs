using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_12
{
    class StudentRepository
    {
        public List<Student> Students { get; set; }
        public String[] Subjects = new String[] { "Algebra", "Chemistry", "Biology", "Sport", "English" };

        public StudentRepository()
        {

            Students = new List<Student>
            {
                new Student() { Name = "Peter", Age = 10,Ratings = new Dictionary<String,Int32>
                    {
                        {"Algebra",6},
                        {"Chemistry",7},
                        {"Biology",2},
                        {"Sport",1},
                        {"English",12}
                    }
                },
                new Student() { Name = "John", Age = 20,Ratings = new Dictionary<String,Int32>
                    {
                        {"Algebra",5},
                        {"Chemistry",3},
                        {"Biology",8},
                        {"Sport",11},
                        {"English",9}
                    }
                },
                new Student() { Name = "Nik", Age = 105,Ratings = new Dictionary<String,Int32>
                    {
                        {"Algebra",12},
                        {"Chemistry",12},
                        {"Biology",12},
                        {"Sport",12},
                        {"English",12}
                    }
                },
                new Student() { Name = "Harold", Age = 20,Ratings = new Dictionary<String,Int32>
                    {
                        {"Algebra",11},
                        {"Chemistry",11},
                        {"Biology",11},
                        {"Sport",8},
                        {"English",7}
                    }
                },
                new Student() { Name = "Oleg", Age = 30,Ratings = new Dictionary<String,Int32>
                    {
                        {"Algebra",2},
                        {"Chemistry",2},
                        {"Biology",2},
                        {"Sport",2},
                        {"English",5}
                    }
                },
                new Student() { Name = "Dmitry", Age = 42,Ratings = new Dictionary<String,Int32>
                    {
                        {"Algebra",7},
                        {"Chemistry",7},
                        {"Biology",9},
                        {"Sport",9},
                        {"English",9}
                    }
                },
                new Student() { Name = "Ivan", Age = 13,Ratings = new Dictionary<String,Int32>
                    {
                        {"Algebra",5},
                        {"Chemistry",2},
                        {"Biology",5},
                        {"Sport",5},
                        {"English",12}
                    }
                },
            };
        }
        public void AddStudent()
        {
            Student _newStudent = new Student();
            Boolean _flagCorrect = false;
            Console.Write("Enter name of new Student: ");
            _newStudent.Name = Console.ReadLine();
            Console.Write("Enter age of new Student: ");
            Int32 _Age = default(Int32);
            while (!_flagCorrect)
            {
                while (Int32.TryParse(Console.ReadLine(), out _Age) == false)
                {
                    Console.Write("Not correct symbols in input...\r\n");
                }
                if ((_Age > 18) || (_Age < 7))
                {
                    Console.WriteLine("Not correct !!! (from 7 to 18)");
                }
                else
                {
                    _flagCorrect = true;
                }
            }
            _newStudent.Age = _Age;
            _newStudent.Ratings = new Dictionary<String, Int32>();
            Students.Add(_newStudent);
        }
        public void ShowAllStudents()
        {
            foreach (Student student in Students)
            {
                Console.WriteLine(student.Name);
            }
        }
        public void ShowMenu()
        {
            Console.WriteLine("Welcome to ClassManagementProgramm of some class in some school!");
            Console.WriteLine("1. Load data from file");
            Console.WriteLine("2. Show all students.");
            Console.WriteLine("3. Show Medium Ratings of all students.");
            Console.WriteLine("4. Show all Ratings by age.");
            Console.WriteLine("5. Save data to file.");
            Console.WriteLine("6. Add student to this class.");
            Console.WriteLine("7. Input rating for specified subject of specified student.");
            Console.WriteLine("8. Add subject to specified student.");
            Console.WriteLine("9. Exit.");
        }
    }
}