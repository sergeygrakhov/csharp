using System;

	class HomeWork1_2
	{
		public static void Main()
		{
			string str = "hello world";
						
			foreach (char symbol in str)
			{
				int dec = Convert.ToByte(symbol);
				string  hex = String.Format("{0:X}", dec);
				Console.WriteLine("Char {0}: dec {1,3}, hex {2,3} ",symbol, dec, hex);
			}
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	
}
