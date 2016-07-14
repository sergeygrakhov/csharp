using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_2_3
{
    class Program
    {
  		 static void Main()
  		{
  			System.Int32 x = 5;
  			System.Int32 y = 12; 
  			System.Int32 z = 2;
  			System.Int32 result = (x++ - --y + --x << z++)*(x + y + z);
  			Console.WriteLine(result);
  			Console.WriteLine("Why -76?:\n" +
  			                  "\n" +
  			                  "(x++ - --y + --x << z++)*(x + y + z)\n" +
  			                  "\n" +
  			                  "(5 - (12-1) + (5+1-1) << 2)*(5 + 11 + (2+1))\n" +
  			                  "(-1<<2)*(19)\n" +
  			                  "-4*19 = -76\n" +
  			                  "\n" +
  			                  "Press any key to exit...");
  			Console.ReadKey();
  		}
    }
	
}
