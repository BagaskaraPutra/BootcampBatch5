//Source: https://www.c-sharpcorner.com/article/async-and-await-in-c-sharp/

class Program
{
	static void Main(string[] args)
	{
		Method1();
		Method2();
		Console.ReadKey();
	}

	public static async Task Method1()
	{
		await Task.Run(() =>
		{
			for (int i = 0; i < 20; i++)
			{
				Console.WriteLine(" Method 1: {0}", i);
				// Do something
				Task.Delay(500).Wait();
			}
		});
	}


	public static void Method2()
	{
		for (int i = 0; i < 10; i++)
		{
			Console.WriteLine(" Method 2: {0}", i);
			// Do something
		   Task.Delay(1000).Wait();
		}
	}
}