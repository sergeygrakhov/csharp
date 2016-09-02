using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework_11
{
    class Program
    {
        delegate void StringOrNumber(Value _valueArg);
        public static void Main(string[] args)
        {
            Value myValue = Value.CreateValue();
            StringOrNumber Operation = _valueArg =>
            {
                Decimal _temp; 
                if (Decimal.TryParse(_valueArg.MyValue, out _temp))
                {
                    _temp *= _temp;
                    _valueArg.MyValue = _temp.ToString();
                    myValue.ChooseDestination();
                }
                else
                {
                    myValue.ChooseDestination();
                }
            };
            Operation(myValue);
            Console.WriteLine("Enter to exit ...");
            Console.ReadKey();
        }
    }
    class Value
    {
        public String MyValue { get; set; }
        private Value() { }
        public static Value CreateValue()
        {
            Value _temp = new Value();
            Console.Write("Enter value:");
            _temp.MyValue = Console.ReadLine();
            return _temp;
        }
        public static void WriteStringToFile(String _stringArg)
        {
            String _path = Directory.GetCurrentDirectory() + "/homework_11.txt";
            using (StreamWriter sw = File.CreateText(_path))
            {
                sw.WriteLine(_stringArg);
            }
        }
    }
    static class Additional
    {
        public static void ChooseDestination(this Value _valueArg)
        {
            String _chooseStr = null;
            Boolean _flagExit = false;
            while(!_flagExit)
            {
                Console.WriteLine("Choose destination\r\n1:File in current folder\r\n2:Print in Console");
                _chooseStr = Console.ReadLine();
                switch (_chooseStr)
                {
                    case "1":
                        Value.WriteStringToFile(_valueArg.MyValue);
                        _flagExit = true;
                        break;
                    case "2":
                        Console.WriteLine(_valueArg.MyValue);
                        _flagExit = true;
                        break;
                    default:
                        Console.WriteLine("Not correct selection...");
                        break;
                }
            }
        }
    }
}
