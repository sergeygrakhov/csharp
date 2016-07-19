using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Double _dResult;
            Char _charExit;
            Boolean _flagExit = false;
            _dResult = default(Double);
            _dResult = ReadValue();
            while (!_flagExit)
            {
                SelectOperation(ref _dResult);
                ShowResult(_dResult);
                ShowExitMessage();
                _charExit = Console.ReadKey().KeyChar;
                if (_charExit == 'x')
                {
                    _flagExit = true;
                }
            }
        }
        static void SelectOperation(ref Double _dResult)
        {
            ShowOperMessage();
            Char _charSelect = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (_charSelect)
            {
                case '+':
                    _dResult = Add(_dResult);
                    break;
                case '-':
                    _dResult = Sub(_dResult);
                    break;
                case '*':
                    _dResult = Mul(_dResult);
                    break;
                case '/':
                    _dResult = Div(_dResult);
                    break;
                case '%':
                    _dResult = Mod(_dResult);
                    break;
                case 's':
                    _dResult = Pow(_dResult);
                    break;
                default:
                    Console.WriteLine("Error: Not valid operation!!!\r\n" +
                                      "Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
        static void ShowExitMessage()
        {
            Console.WriteLine("To finish press \"x\" or press Enter to continue calculations");
        }
        static void ShowEnterMessage()
        {
            Console.WriteLine("Enter value: ");
        }
        static void ShowOperMessage()
        {
            Console.WriteLine("Choose operation (+ - * / % or s for Pow) ");
        }
        static void ShowResult(Double _dVal)
        {
            Console.WriteLine("Result: {0}", _dVal);
        }
        static Double ReadValue()
        {
            Double _dVal;
            ShowEnterMessage();
            while (Double.TryParse(Console.ReadLine(), out _dVal) == false)
            {
                Console.WriteLine("Not correct value...Please enter correct!..");
            }
            return _dVal;
        }
        static Double Add(Double _dOne)
        {
            Double _dTwo = ReadValue();
            return _dOne + _dTwo;
        }
        static Double Sub(Double _dOne)
        {
            Double _dTwo = ReadValue();
            return _dOne - _dTwo;
        }
        static Double Mul(Double _dOne)
        {
            Double _dTwo = ReadValue();
            return _dOne * _dTwo;
        }
        static Double Div(Double _dOne)
        {
            Double _dTwo = ReadValue();
            if (_dTwo == 0)
            {
                Console.WriteLine("Error: Division By Zero\r\nPrevious");
                return _dOne;
            }
            else
            {
                return _dOne / _dTwo;
            }
        }
        static Double Mod(Double _dOne)
        {
            Double _dTwo = ReadValue();
            return _dOne % _dTwo;
        }
        static Double Pow(Double _dOne)
        {
            Double _dTwo = ReadValue();
            return Math.Pow(_dOne, _dTwo);
        }
    }
}
