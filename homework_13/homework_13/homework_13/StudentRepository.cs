using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_12
{
    class StudentRepository:IEnumerable,IEnumerator
    {
        public List<Student> Students { get; set; }
        Int32 position = -1;
        private static String _path = Directory.GetCurrentDirectory();
        private static String _serializationFile = Path.Combine(_path, "homework_12.bin");
        public Student this[Int32 index]
        {
            get
            {
                return Students[index];
            }
            set
            {
                Students[index] = value;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }
        object IEnumerator.Current
        {
            get
            {
                return Students[position];
            }
        }
        Boolean IEnumerator.MoveNext()
        {
            if(position < Students.Count - 1)
            {
                position++;
                return true;
            }
            ((IEnumerator)this).Reset();
            return false;
        }
        public void Reset()
        {
            position = -1;
        }
        public  List<Student> CreateSchoolClass()
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
            return Students;
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
            if (Students == null)
            {
                Students = new List<Student>();
            }
            Students.Add(_newStudent);
        }
        public void ShowAllStudents()
        {
            foreach (Student student in this)
            {
                Console.WriteLine(student.Name);
            }
        }
        public void ShowMenu()
        {
            Boolean _flagExit = false;
            String _charSelect = null;
            while (!_flagExit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to ClassManagementProgramm of some class in some school!");
                Console.WriteLine("1. Load data from file");
                Console.WriteLine("2. Show all students.");
                Console.WriteLine("3. Show Medium Ratings of all students.");
                Console.WriteLine("4. Show all Ratings by age.");
                Console.WriteLine("5. Save data to file.");
                Console.WriteLine("6. Add student to this class.");
                Console.WriteLine("7. Input rating for specified subject of specified student.");
                Console.WriteLine("8. Add subject to specified student.");
                Console.WriteLine("9. Create default class.");
                Console.WriteLine("10. Exit.");
                _charSelect = Console.ReadLine();
                switch (_charSelect)
                {
                    case "1":
                        if (File.Exists(_serializationFile))
                        {
                            DeserializeFromFile();
                        }
                        else
                        {
                            Console.WriteLine("File not exists...");
                            Console.WriteLine("Enter to continue");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        if (this.Students != null)
                        {
                            ShowAllStudents();
                            Console.WriteLine("Enter to continue");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("There is no students...Create default class, add or load from file");
                            Console.WriteLine("Enter to continue");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        if (this.Students != null)
                        {
                            foreach (Student student in this)
                            {
                                Console.Write("{0} : ", student.Name);
                                student.GetMediumRating();
                            }
                            Console.WriteLine("Enter to continue");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("There is no students...Create default class, add or load from file");
                            Console.WriteLine("Enter to continue");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter age for get medium rate");
                        Int32 _Age = default(Int32);
                        Boolean _flagCorrect = false;
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
                        if (this.Students != null)
                        {
                            foreach (Student student in this)
                            {
                                if (student.Age > _Age)
                                {
                                    Console.Write("{0} : ", student.Name);
                                    student.GetMediumRating();
                                }
                            }
                            Console.WriteLine("Enter to continue");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("There is no students...Create default class, add or load from file");
                            Console.WriteLine("Enter to continue");
                            Console.ReadLine();
                        }
                        break;
                    case "5":
                        SerializeToFile();
                        break;
                    case "6":
                        AddStudent();
                        Console.WriteLine("Enter to continue");
                        Console.ReadLine();
                        break;
                    case "7":
                        if (Students != null)
                        {
                            Int32 _index = 0;
                            Boolean _flagCorrectSelect = false;
                            while (!_flagCorrectSelect)
                            {
                                Console.WriteLine("Select student");
                                for (int i = 0; i < Students.Count; i++)
                                {
                                    Console.WriteLine("{0}: {1}", i + 1, Students[i].Name);
                                }
                                while (Int32.TryParse(Console.ReadLine(), out _index) == false)
                                {
                                    Console.WriteLine("Not correct!!!");
                                }
                                if (_index < 1 || _index > Students.Count)
                                {
                                    Console.WriteLine("Choose correct index");
                                }
                                else
                                {
                                    _flagCorrectSelect = true;
                                }
                            }
                            Int32 _counter = 0;
                            Boolean _flagCorrectSubject = false;
                            Int32 _selectedSubject = 0;
                            String[] _arrSub = new string[Students[_index - 1].Ratings.Keys.Count];
                            while (!_flagCorrectSubject)
                            {
                                if (Students[_index - 1].Ratings.Keys.Count > 0)
                                {
                                    Console.WriteLine("Enter id of subject to rate:");

                                    foreach (String item in Students[_index - 1].Ratings.Keys)
                                    {
                                        _arrSub[_counter] = item;
                                        Console.WriteLine("{0}: {1}", _counter + 1, item);
                                        _counter++;
                                    }
                                    while (Int32.TryParse(Console.ReadLine(), out _selectedSubject) == false)
                                    {
                                        Console.WriteLine("Not correct!!");
                                    }
                                    if (_selectedSubject < 1 || _selectedSubject > _arrSub.Length)
                                    {
                                        Console.WriteLine("Not in range!!");
                                    }
                                    else
                                    {
                                        _flagCorrectSubject = true;
                                    }
                                    Boolean _flagCorrectAdd = false;
                                    Int32 _iRate = 0;
                                    while (!_flagCorrectAdd)
                                    {
                                        Console.Write("Enter rate for entered subject:");
                                        while (Int32.TryParse(Console.ReadLine(), out _iRate) == false)
                                        {
                                            Console.Write("Not correct symbols in input...\r\n");
                                        }
                                        if ((_iRate > 12) || (_iRate < 1))
                                        {
                                            Console.WriteLine("Not correct !!! (from 1 to 12)");
                                        }
                                        else
                                        {
                                            _flagCorrectAdd = true;
                                        }
                                    }
                                    Students[_index - 1].Ratings[_arrSub[_selectedSubject - 1]] = _iRate;
                                    Console.WriteLine("Enter to continue");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    _flagCorrectSubject = true;
                                    Console.WriteLine("Selected student do not have subjects, add first!");
                                    Console.WriteLine("Enter to continue");
                                    Console.ReadLine();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no students...Create default class, add or load from file");
                            Console.WriteLine("Enter to continue");
                            Console.ReadLine();
                        }
                        break;
                    case "8":
                        if (Students != null)
                        {
                            Int32 _index = 0;
                            Boolean _flagCorrectSelect = false;
                            while (!_flagCorrectSelect)
                            {
                                Console.WriteLine("Select student");
                                for (int i = 0; i < Students.Count; i++)
                                {
                                    Console.WriteLine("{0}: {1}", i + 1, Students[i].Name);
                                }
                                while (Int32.TryParse(Console.ReadLine(), out _index) == false)
                                {
                                    Console.WriteLine("Not correct!!!");
                                }
                                if (_index < 1 || _index > Students.Count)
                                {
                                    Console.WriteLine("Choose correct index");
                                }
                                else
                                {
                                    _flagCorrectSelect = true;
                                }
                            }
                            Students[_index - 1].AddSubject();
                        }
                        else
                        {
                            Console.WriteLine("There is no students...Create default class, add or load from file");
                            Console.WriteLine("Enter to continue");
                            Console.ReadLine();
                        }
                        break;
                    case "9":
                        this.Students = CreateSchoolClass();
                        Console.WriteLine("Enter to continue");
                        Console.ReadLine();
                        break;
                    case "10":
                        Console.WriteLine("Save changes? Y - yes N - no");
                        String _charSelectSave = null;
                        _charSelectSave = Console.ReadLine();
                        switch (_charSelectSave)
                        {
                            case "Y":
                                SerializeToFile();
                                _flagExit = true;
                                break;
                            case "N":
                                _flagExit = true;
                                break;
                            default:
                                Console.WriteLine("Wrong input Y or N");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong selection!!!");
                        Console.WriteLine("Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void SerializeToFile()
        {
            using (Stream stream = File.Open(_serializationFile, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                if (this.Students != null)
                {
                    bformatter.Serialize(stream, this.Students);
                    Console.WriteLine("Saved to filesystem...");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("There is no students...Create default class, add or load from file");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                }
            }
        }
        public void DeserializeFromFile()
        {
            using (Stream stream = File.Open(_serializationFile, FileMode.Open))
            {
                if (stream.Length != 0)
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    this.Students = (List<Student>)bformatter.Deserialize(stream);
                    Console.WriteLine("Data sucsesfully loaded");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Data length 0");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                }
            }
        }
    }
}