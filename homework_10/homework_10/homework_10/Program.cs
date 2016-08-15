using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_10
{
    public delegate void MyEvent(String _argStr1, String _argStr2);
    class Program
    {
        public static void Main(string[] args)
        {
            Boolean _flagExit = false;
            while (!_flagExit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Calculator based on events!\r\nS - to start or E - to exit");
                String _exitOrContinue = Console.ReadLine();
                switch (_exitOrContinue)
                {
                    case "S":
                        String str1 = StringAction.ReadValue('1');
                        String str2 = StringAction.ReadValue('2');
                        StringAction stringAction = new StringAction();
                        StringAction.ChooseOperations(stringAction);
                        stringAction.Calculate(str1, str2);
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
    }
    class StringAction
    {
        public static String ReadValue(Char _charArg)
        {
            Double _doubleValue = default(Double);
            Console.Write("Input {0} value: ", _charArg);
            while (Double.TryParse(Console.ReadLine(), out _doubleValue) == false)
            {
                Console.WriteLine("Not correct input...Try again...");
            }
            return _doubleValue.ToString();
        }
        public event MyEvent myEvent;
        public void Calculate(String _argStr1, String _argStr2)
        {
            if (myEvent != null)
            {
                myEvent.Invoke(_argStr1, _argStr2);

            }
            Console.WriteLine("Enter to continue...");
            Console.ReadLine();
        }
        private void Add(String _argStr1, String _argStr2)
        {
            Console.WriteLine("{0} + {1} = {2}", _argStr1, _argStr2, Double.Parse(_argStr1) + Double.Parse(_argStr2));
        }
        private void Sub(String _argStr1, String _argStr2)
        {
            Console.WriteLine("{0} - {1} = {2}", _argStr1, _argStr2, Double.Parse(_argStr1) - Double.Parse(_argStr2));
        }
        private void Mul(String _argStr1, String _argStr2)
        {
            Console.WriteLine("{0} * {1} = {2}", _argStr1, _argStr2, Double.Parse(_argStr1) * Double.Parse(_argStr2));
        }
        private void Div(String _argStr1, String _argStr2)
        {
            Console.WriteLine("{0} / {1} = {2}", _argStr1, _argStr2, Double.Parse(_argStr1) / Double.Parse(_argStr2));
        }
        public static void ChooseOperations(StringAction _stringActionArg)
        {
            String _strOper = null;
            Boolean _flagCorrect = false;
            while (!_flagCorrect)
            {
                Console.WriteLine("Select operations:\r\n1: +\r\n2: -\r\n3: *\r\n4: /");
                _strOper = Console.ReadLine();
                if (_strOper.Length > 4)
                {
                    Console.WriteLine("To many numbers in selection...");
                }
                else
                {
                    _flagCorrect = true;
                    foreach (Char _char in _strOper)
                    {
                        switch (_char)
                        {
                            case '1':
                                _stringActionArg.myEvent += _stringActionArg.Add;
                                break;
                            case '2':
                                _stringActionArg.myEvent += _stringActionArg.Sub;
                                break;
                            case '3':
                                _stringActionArg.myEvent += _stringActionArg.Mul;
                                break;
                            case '4':
                                _stringActionArg.myEvent += _stringActionArg.Div;
                                break;
                            default:
                                Console.WriteLine("No operation with entered id");
                                break;
                        }
                    }
                }

            }
        }
    }
}
