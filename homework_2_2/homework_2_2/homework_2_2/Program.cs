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
  		 	System.Double _Value;
  		 	System.Double _ValueSecond;
  		 	System.Double _ValueThird;
  		 	Console.WriteLine("1. Square of a circle:");
  		 	Console.Write("Input radius: ");
  		 	_Value = Convert.ToDouble(Console.ReadLine());
  		 	Console.WriteLine("Square of a circle equals {0}",Math.PI*_Value*_Value);
  		 	Console.WriteLine("2. Volume of a sphere:");
  		 	Console.Write("Input radius: ");
  		 	_Value = Convert.ToDouble(Console.ReadLine());
  		 	Console.WriteLine("Volume of a sphere equals {0}",4*_Value*_Value*_Value*Math.PI/3);
  		 	Console.WriteLine("3. Square of a rectangle:");
  		 	Console.Write("Input first dimension: ");
  		 	_Value = Convert.ToDouble(Console.ReadLine());
  		 	Console.Write("Input second dimension: ");
  		 	_ValueSecond = Convert.ToDouble(Console.ReadLine());
  		 	Console.WriteLine("Square of a rectangle equals {0}",_Value*_ValueSecond);
  		 	Console.WriteLine("4. Volume of a cuboid:");
  		 	Console.Write("Input first dimension: ");
  		 	_Value = Convert.ToDouble(Console.ReadLine());
  		 	Console.Write("Input second dimension: ");
  		 	_ValueSecond = Convert.ToDouble(Console.ReadLine());
  		 	Console.Write("Input third dimension: ");
  		 	_ValueThird = Convert.ToDouble(Console.ReadLine());
  		 	Console.WriteLine("Square of a rectangle equals {0}",_Value*_ValueSecond*_ValueThird);
  			Console.WriteLine("Press any key to exit ...");
  			Console.ReadKey();
  			//проверку на правильность ввода не реализовывал
  		}
    }
}
