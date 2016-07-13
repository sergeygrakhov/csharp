using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_2
{
    class Program
    {
        static void Main()
        {
            string str = "hello world";

            foreach (char symbol in str)
            {
                int dec = Convert.ToInt32(symbol);
                string hex = String.Format("{0:X}", dec);
                Console.WriteLine("Char {0}: dec {1,3}, hex {2,3} ", symbol, dec, hex);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
