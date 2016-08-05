using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_7
{
    class Program
    {
        public static void Main(string[] args)
        {
            Employee[] _staff = Employee.StaffCreate();
            Employee.Start(_staff);
        }
    }
    abstract class Employee
    {
        private String _stringName;
        private Byte _byteExperience;
        public Decimal _decWorkedHoursThisMonth;
        private Decimal _decimalSalaryPerHour;
        private Decimal _decimalBonus;
        private Decimal _decimalSalary;
        private String _stringJob;
        abstract public void Bonus();
        public Employee(String _stringArg, Byte _byteArg, Decimal _decimalArg, String _strinArgJob)
        {
            this._stringName = _stringArg;
            this._byteExperience = _byteArg;
            this._decimalSalaryPerHour = _decimalArg;
            this._stringJob = _strinArgJob;
        }
        public void HowManyHoursWorked()
        {
            Boolean _flagCorrect = false;
            UInt16 _uintHours = default(UInt16);
            while (!_flagCorrect)
            {
                Console.Write("How many hours selected employee worked last month? :  ");
                while (UInt16.TryParse(Console.ReadLine(), out _uintHours) == false)
                {
                    Console.Write("Not correct symbols in selection...\r\nHow many hours selected employee worked last month? :  ");
                }
                if (_uintHours > 250)
                {
                    Console.WriteLine("Too many hours selected !!! (no more than 250 hours allowed )");
                }
                else
                {
                    _flagCorrect = true;
                }
            }
            this._decWorkedHoursThisMonth += _uintHours;
        }
        public static void CalculateSalary(Employee _employeeArg)
        {
            if (_employeeArg is Doctor)
            {
                Decimal _decimalPerPatientBonus = 50;
                Boolean _flagCorrect = false;
                Byte _byteQwantityCured = default(Byte);
                _employeeArg.Bonus();
                _employeeArg.HowManyHoursWorked();
                _employeeArg._decimalSalary = _employeeArg._decWorkedHoursThisMonth * _employeeArg._decimalSalaryPerHour;
                while (!_flagCorrect)
                {
                    Console.Write("How many patients selected doctor has cured? : ");
                    while (Byte.TryParse(Console.ReadLine(), out _byteQwantityCured) == false)
                    {
                        Console.Write("Not correct symbols in patients qwantity!\r\nHow many patients selected doctor has cured? : ");
                    }
                    if (_byteQwantityCured > 50)
                    {
                        Console.WriteLine("Too many patients !!! (no more than 50 human allowed )");
                    }
                    else
                    {
                        _flagCorrect = true;
                    }
                }
                _employeeArg._decimalBonus = _decimalPerPatientBonus * _byteQwantityCured;
                Console.WriteLine("Total payments for {0} are {1} dollars\r\n(Bonus for cure: {2}; Worked hours({3} dollars per hour): {4})",
                    _employeeArg._stringName, _employeeArg._decimalSalary + _employeeArg._decimalBonus, _employeeArg._decimalBonus, _employeeArg._decimalSalaryPerHour, _employeeArg._decimalSalary);
                Console.WriteLine("Any key to continue...");
                Console.ReadKey();
            }
            else if (_employeeArg is Psycholog)
            {
                Decimal _decimalPerPatientBonus = 1.2M;
                Boolean _flagCorrect = false;
                Byte _byteQwantityPatients = default(Byte);
                _employeeArg.Bonus();
                _employeeArg.HowManyHoursWorked();
                _employeeArg._decimalSalary = _employeeArg._decWorkedHoursThisMonth * _employeeArg._decimalSalaryPerHour;
                while (!_flagCorrect)
                {
                    Console.Write("How many patients selected psycholog has? : ");
                    while (Byte.TryParse(Console.ReadLine(), out _byteQwantityPatients) == false)
                    {
                        Console.Write("Not correct symbols in patients qwantity!\r\nHow many patients selected psycholog has? : ");
                    }
                    if (_byteQwantityPatients > 50)
                    {
                        Console.WriteLine("Too many patients !!! (no more than 50 human allowed )");
                    }
                    else
                    {
                        _flagCorrect = true;
                    }
                }
                if (!(_byteQwantityPatients == 0))
                {
                    _employeeArg._decimalBonus = 1;
                }
                Decimal _tempValue = _employeeArg._decimalSalary;
                for (int i = 0; i < _byteQwantityPatients; i++)
                {
                    _tempValue *= _decimalPerPatientBonus;
                }
                _employeeArg._decimalBonus = _tempValue;
                Console.WriteLine("Total payments for {0} are {1} dollars\r\n(Bonus for patients: {2}; Worked hours({3} dollars per hour): {4})",
                    _employeeArg._stringName, _employeeArg._decimalSalary + _employeeArg._decimalBonus, _employeeArg._decimalBonus, _employeeArg._decimalSalaryPerHour, _employeeArg._decimalSalary);
                Console.WriteLine("Any key to continue...");
                Console.ReadKey();
            }
            else if (_employeeArg is OrdinaryWorker)
            {
                Decimal _decimalPerOvertimeHour = 1.5M;
                Boolean _flagCorrect = false;
                Byte _byteQwantityOvertime = default(Byte);
                _employeeArg.Bonus();
                _employeeArg.HowManyHoursWorked();
                _employeeArg._decimalSalary = _employeeArg._decWorkedHoursThisMonth * _employeeArg._decimalSalaryPerHour;
                while (!_flagCorrect)
                {
                    Console.Write("How many hours overtime selected worker has? : ");
                    while (Byte.TryParse(Console.ReadLine(), out _byteQwantityOvertime) == false)
                    {
                        Console.Write("Not correct symbols in patients qwantity!\r\nHow many patients selected psycholog has? : ");
                    }
                    if (_byteQwantityOvertime > _employeeArg._decWorkedHoursThisMonth / 2)
                    {
                        Console.WriteLine("Too many overtime !!! (no more than {0} hours allowed )", _employeeArg._decWorkedHoursThisMonth / 2);
                    }
                    else
                    {
                        _flagCorrect = true;
                    }
                }
                _employeeArg._decimalBonus = _byteQwantityOvertime * _employeeArg._decimalSalaryPerHour * _decimalPerOvertimeHour;
                Console.WriteLine("Total payments for {0} are {1} dollars\r\n(Bonus for overtime: {2}; Worked hours({3} dollars per hour): {4})",
                    _employeeArg._stringName, _employeeArg._decimalSalary + _employeeArg._decimalBonus, _employeeArg._decimalBonus, _employeeArg._decimalSalaryPerHour, _employeeArg._decimalSalary);
                Console.WriteLine("Any key to continue...");
                Console.ReadKey();
            }
            else if (_employeeArg is Security)
            {
                Byte _bytePerNightHourRate = 2;
                Boolean _flagCorrect = false;
                Byte _byteQwantityNightime = default(Byte);
                _employeeArg.Bonus();
                _employeeArg.HowManyHoursWorked();
                _employeeArg._decimalSalary = _employeeArg._decWorkedHoursThisMonth * _employeeArg._decimalSalaryPerHour;
                while (!_flagCorrect)
                {
                    Console.Write("How many night hours overtime selected security has? : ");
                    while (Byte.TryParse(Console.ReadLine(), out _byteQwantityNightime) == false)
                    {
                        Console.Write("Not correct symbols in patients qwantity!\r\nHow many patients selected psycholog has? : ");
                    }
                    if (_byteQwantityNightime > _employeeArg._decWorkedHoursThisMonth / 2)
                    {
                        Console.WriteLine("Too many night hours !!! (no more than {0} hours allowed )", _employeeArg._decWorkedHoursThisMonth / 2);
                    }
                    else
                    {
                        _flagCorrect = true;
                    }
                }
                _employeeArg._decimalBonus = _byteQwantityNightime * _employeeArg._decimalSalaryPerHour * _bytePerNightHourRate;
                Console.WriteLine("Total payments for {0} are {1} dollars\r\n(Bonus for nigthtime: {2}; Worked hours({3} dollars per hour): {4})",
                    _employeeArg._stringName, _employeeArg._decimalSalary + _employeeArg._decimalBonus, _employeeArg._decimalBonus, _employeeArg._decimalSalaryPerHour, _employeeArg._decimalSalary);
                Console.WriteLine("Any key to continue...");
                Console.ReadKey();
            }
        }
        public static void Start(Employee[] _employeeArg)
        {
            Byte _byteId = default(Byte);
            Boolean _flagCorrect = false;
            Boolean _flagExit = false;
            String _charSelect = default(String);
            while (!_flagExit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Accountant_Program v 0.1\r\n\r\nEnter S to start or E to exit\r\n");
                _charSelect = Console.ReadLine();
                switch (_charSelect)
                {
                    case "S":
                        _flagCorrect = false;
                        while (!_flagCorrect)
                        {
                            Console.Clear();
                            Console.WriteLine("This is a list of ours Factory staff:\r\n");
                            Console.WriteLine(" ID  Name                        Position  Exp(years) Per hour salary");
                            for (int i = 0; i < _employeeArg.Length; i++)
                            {
                                Console.WriteLine("{0,3}: {1,15} {2,20} {3,5} {4,10}", i + 1, _employeeArg[i]._stringName, _employeeArg[i]._stringJob, _employeeArg[i]._byteExperience, _employeeArg[i]._decimalSalaryPerHour);
                            }
                            Console.Write("Please, enter id of employee to calculate its salary: ");
                            while (Byte.TryParse(Console.ReadLine(), out _byteId) == false)
                            {
                                Console.Write("Not correct symbols in ID!\r\nenter id: ");
                            }
                            if (_byteId > _employeeArg.Length)
                            {
                                Console.WriteLine("There is no employee with selected ID\r\nAny key to try again... ");
                                Console.ReadKey();
                            }
                            else
                            {
                                _flagCorrect = true;
                            }

                        }
                        _byteId -= 1;
                        Employee.CalculateSalary(_employeeArg[_byteId]);
                        break;
                    case "E":
                        _flagExit = true;
                        break;
                    default:
                        Console.WriteLine("Not correct selection (S to start or E to exit)\r\nEnter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        //создадим гипотетический персонал 2 врача 1 психолог 5 обычных 3 охранника и по одному стажеру для всех должностей
        public static Employee[] StaffCreate()
        {
            Employee[] _staffArg = new Employee[15];
            _staffArg[0] = new Doctor("Peter Ivanov".PadRight(15), 15, 40, "Doctor");
            _staffArg[1] = new Doctor("Nikolay Cvetkov".PadRight(15), 8, 30, "Doctor");
            _staffArg[2] = new Psycholog("John Silver".PadRight(15), 4, 60, "Psycholog");
            _staffArg[3] = new OrdinaryWorker("Karl Mamaev".PadRight(15), 7, 10, "Worker");
            _staffArg[4] = new OrdinaryWorker("Vladimir Venkin".PadRight(15), 7, 10, "Worker");
            _staffArg[5] = new OrdinaryWorker("Ivan Mishin".PadRight(15), 2, 10, "Worker");
            _staffArg[6] = new OrdinaryWorker("Bruce Nemchenko".PadRight(15), 12, 10, "Worker");
            _staffArg[7] = new OrdinaryWorker("Andrey Popov".PadRight(15), 3, 10, "Worker");
            _staffArg[8] = new Security("Alex Borodach".PadRight(15), 7, 8, "Security");
            _staffArg[9] = new Security("Evgeniy Petruk".PadRight(15), 3, 8, "Security");
            _staffArg[10] = new Security("Oleg Vasin".PadRight(15), 1, 8, "Security");
            _staffArg[11] = new TraineeDoctor("Igor Persikov".PadRight(15), 0, 5, "Trainee Doctor");
            _staffArg[12] = new TraineePsycholog("Artem Kulibin".PadRight(15), 0, 5, "Trainee Psycholog");
            _staffArg[13] = new TraineeWorker("Kostya Yakin".PadRight(15), 0, 5, "Trainee Worker");
            _staffArg[14] = new TraineeSecurity("Trofim Kochkin".PadRight(15), 0, 5, "Trainee Security");
            return _staffArg;
        }
    }
    class Doctor : Employee
    {
        public Doctor(String _stringArg, Byte _byteArg, Decimal _decimalArg, String _strinArgJob)
        : base(_stringArg, _byteArg, _decimalArg, _strinArgJob) { }
        public override void Bonus()
        {
            Byte _bonusHours = default(Byte);
            Console.Write("How many bonus hours add to selected doctor? : ");
            while (Byte.TryParse(Console.ReadLine(), out _bonusHours) == false)
            {
                Console.Write("Not correct value...Enter correct: ");
            }
            _bonusHours *= 3;
            this._decWorkedHoursThisMonth = _bonusHours;
        }

    }
    class Psycholog : Employee
    {
        public Psycholog(String _stringArg, Byte _byteArg, Decimal _decimalArg, String _strinArgJob)
        : base(_stringArg, _byteArg, _decimalArg, _strinArgJob) { }
        public override void Bonus()
        {
            Byte _bonusHours = default(Byte);
            Console.Write("How many bonus hours add to selected psycholog?");
            while (Byte.TryParse(Console.ReadLine(), out _bonusHours) == false)
            {
                Console.Write("Not correct value...Enter correct: ");
            }
            _bonusHours *= 2;
            this._decWorkedHoursThisMonth = _bonusHours;
        }
    }

    class OrdinaryWorker : Employee
    {
        public OrdinaryWorker(String _stringArg, Byte _byteArg, Decimal _decimalArg, String _strinArgJob)
        : base(_stringArg, _byteArg, _decimalArg, _strinArgJob) { }
        public override void Bonus()
        {
            Byte _bonusHours = default(Byte);
            Console.Write("How many bonus hours add to selected worker?");
            while (Byte.TryParse(Console.ReadLine(), out _bonusHours) == false)
            {
                Console.Write("Not correct value...Enter correct: ");
            }
            _bonusHours *= 4;
            this._decWorkedHoursThisMonth = _bonusHours;
        }
    }
    class Security : Employee
    {
        public Security(String _stringArg, Byte _byteArg, Decimal _decimalArg, String _strinArgJob)
        : base(_stringArg, _byteArg, _decimalArg, _strinArgJob) { }
        public override void Bonus()
        {
            Byte _bonusHours = default(Byte);
            Console.Write("How many bonus night hours add to selected security?");
            while (Byte.TryParse(Console.ReadLine(), out _bonusHours) == false)
            {
                Console.Write("Not correct value...Enter correct: ");
            }
            _bonusHours *= 3;
            this._decWorkedHoursThisMonth += _bonusHours;
            Console.Write("How many bonus day hours add to selected security?");
            while (Byte.TryParse(Console.ReadLine(), out _bonusHours) == false)
            {
                Console.Write("Not correct value...Enter correct: ");
            }
            _bonusHours *= 2;
            this._decWorkedHoursThisMonth += _bonusHours;
        }
    }
    sealed class TraineeDoctor : Doctor
    {
        public TraineeDoctor(String _stringArg, Byte _byteArg, Decimal _decimalArg, String _strinArgJob)
        : base(_stringArg, _byteArg, _decimalArg, _strinArgJob) { }
        public override void Bonus()
        {
            Decimal _bonusHours = default(Decimal);
            Console.Write("How many bonus hours add to selected Trainee Doctor? : ");
            while (Decimal.TryParse(Console.ReadLine(), out _bonusHours) == false)
            {
                Console.Write("Not correct value...Enter correct: ");
            }
            _bonusHours *= 1.5M;
            this._decWorkedHoursThisMonth = _bonusHours;
        }
    }
    sealed class TraineePsycholog : Psycholog
    {
        public TraineePsycholog(String _stringArg, Byte _byteArg, Decimal _decimalArg, String _strinArgJob)
        : base(_stringArg, _byteArg, _decimalArg, _strinArgJob) { }
        public override void Bonus()
        {
            Decimal _bonusHours = default(Decimal);
            Console.Write("How many bonus hours add to selected Trainee Psycholog? : ");
            while (Decimal.TryParse(Console.ReadLine(), out _bonusHours) == false)
            {
                Console.Write("Not correct value...Enter correct: ");
            }
            _bonusHours *= 1.5M;
            this._decWorkedHoursThisMonth = _bonusHours;
        }
    }
    sealed class TraineeWorker : OrdinaryWorker
    {
        public TraineeWorker(String _stringArg, Byte _byteArg, Decimal _decimalArg, String _strinArgJob)
        : base(_stringArg, _byteArg, _decimalArg, _strinArgJob) { }
        public override void Bonus()
        {
            Decimal _bonusHours = default(Decimal);
            Console.Write("How many bonus hours add to selected Trainee Worker? : ");
            while (Decimal.TryParse(Console.ReadLine(), out _bonusHours) == false)
            {
                Console.Write("Not correct value...Enter correct: ");
            }
            _bonusHours *= 1.5M;
            this._decWorkedHoursThisMonth = _bonusHours;
        }
    }
    sealed class TraineeSecurity : Security
    {
        public TraineeSecurity(String _stringArg, Byte _byteArg, Decimal _decimalArg, String _strinArgJob)
        : base(_stringArg, _byteArg, _decimalArg, _strinArgJob) { }
        public override void Bonus()
        {
            Decimal _bonusHours = default(Decimal);
            Console.Write("How many bonus hours add to selected Trainee Security? : ");
            while (Decimal.TryParse(Console.ReadLine(), out _bonusHours) == false)
            {
                Console.Write("Not correct value...Enter correct: ");
            }
            _bonusHours *= 1.5M;
            this._decWorkedHoursThisMonth = _bonusHours;
        }
    }
}