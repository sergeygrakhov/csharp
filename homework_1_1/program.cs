 using System;

	class HomeWork1_1
	{
		public static void Main()
		{
			Console.SetWindowSize(101,15);
			Console.WriteLine("Type byte: default value {0}, min {1}, max {2}",default(byte), byte.MinValue, byte.MaxValue);
			Console.WriteLine("Type sbyte: default value {0}, min {1}, max {2}",default(sbyte), sbyte.MinValue, sbyte.MaxValue);
			Console.WriteLine("Type short: default value {0}, min {1}, max {2}",default(short), short.MinValue, short.MaxValue);
			Console.WriteLine("Type ushort: default value {0}, min {1}, max {2}",default(ushort), ushort.MinValue, ushort.MaxValue);
			Console.WriteLine("Type int: default value {0}, min {1}, max {2}",default(int), int.MinValue, int.MaxValue);
			Console.WriteLine("Type uint: default value {0}, min {1}, max {2}",default(uint), uint.MinValue, uint.MaxValue);
			Console.WriteLine("Type long: default value {0}, min {1}, max {2}",default(long), long.MinValue, long.MaxValue);
			Console.WriteLine("Type ulong: default value {0}, min {1}, max {2}",default(ulong), ulong.MinValue, ulong.MaxValue);
			Console.WriteLine("Type float: default value {0}, min {1}, max {2}",default(float), float.MinValue, float.MaxValue);
			Console.WriteLine("Type double: default value {0}, min {1}, max {2}",default(double), double.MinValue, double.MaxValue);
			Console.WriteLine("Type decimal: default value {0}, min {1}, max {2}",default(decimal), decimal.MinValue, decimal.MaxValue);
			Console.WriteLine("Type bool: default value {0}",default(bool));
			Console.WriteLine("Type char: default value {0}",default(char));
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	
}
