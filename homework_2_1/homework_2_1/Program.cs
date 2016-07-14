using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_2_1
{
    class Program
    {
  		 static void Main()
  		{
  		 	System.Int32 _iOne = 123;
  			System.Int32 _iTwo = 42; 
  			System.String _sOne = "Hello";
  			System.String _sTwo = "World";
  			System.Boolean _bOne = false;
			System.Boolean _bTwo = true;  			
			Console.SetWindowSize(61,32);
  			Console.WriteLine("Arithmetic operations with numbers 123 and 42:\n" +
  			                  "+: {0}\n" +
  			                  "-: {1}\n" +
  			                  "*: {2}\n" +
  			                  "/: {3}\n" +
  			                  "%: {4}\n", _iOne + _iTwo,_iOne - _iTwo,_iOne * _iTwo,_iOne / _iTwo,_iOne % _iTwo);
  			Console.WriteLine("Comparsion operations with numbers 123 and 42:\n" +
  			                  ">: {0}\n" +
  			                  "<: {1}\n" +
  			                  ">=: {2}\n" +
  			                  "<=: {3}\n" +
  			                  "!=: {4}\n" +
  			                  "==: {5}\n", _iOne > _iTwo,_iOne < _iTwo,_iOne >= _iTwo,_iOne <= _iTwo,_iOne != _iTwo,_iOne == _iTwo );
  			Console.WriteLine("Logical operations with false and true:\n" +
  			                  "&&: {0}\n" +
  			                  "||: {1}\n" +
  			                  "^: {2}\n",  _bOne && _bTwo,_bOne || _bTwo,_bOne ^ _bTwo);
  			Console.WriteLine("Bit operations with numbers 123 and 42:\n" +
  			                  "&: {0}\n" +
  			                  "|: {1}\n" +
  			                  "^: {2}\n" +
  			                  "<<: {3}\n" +
  			                  ">>: {4}\n", _iOne & _iTwo,_iOne | _iTwo,_iOne ^ _iTwo,_iOne << _iTwo,_iOne >> _iTwo);
  			Console.WriteLine("Operations with strings {0} and {1}\n" +
  			                  "Concatenation: {2}\n" +
  			                  "Concatenation witn numbers and booleans: {3}",_sOne, _sTwo, _sOne + ' ' + _sTwo, _sOne +_iOne+_bOne+ _sTwo );
  			Console.WriteLine("Press any key to exit ...");
  			Console.ReadKey();
  		}
    }
}
