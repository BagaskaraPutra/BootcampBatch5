public class Program
{
	static void Main()
	{
		bool status = false;
		double userDouble = 0.0;
		do
		{
			Console.Write("Please input any number ... ");
			status = double.TryParse(Console.ReadLine(), out userDouble);	
			if(!status)
			{
				Console.WriteLine("You did not input a number!");
			}
		} while (!status);
		double result = userDouble / (userDouble - userDouble);
		try
		{
			if ((double.IsInfinity(result)) || result == double.NaN) 
			{
   				throw new ArithmeticException();
			}
			Console.WriteLine(result);
		}
		catch (ArithmeticException e)
		{
			Console.WriteLine($"{e.Message} Result is Infinity of NaN");
		}
		catch (Exception e)
		{
			Console.WriteLine($"{e.Message} Format Error");
		}
		finally {
			Console.WriteLine("Apapun yang terjadi, tetaplah bernapas");
		}
		Console.WriteLine("Program finished");
	}
}