using System.Globalization;
public class Program
{
	static void Main()
	{
		bool status = false;
		double userDouble = 0.0;
		// Array of culture info to accept both "," and "." decimals
	  	CultureInfo[] cultures = { new CultureInfo("en-US"),
								 new CultureInfo("id-ID")};
		do
		{
			Console.Write("Please input any number ... ");
			string? userInput = Console.ReadLine();
			foreach (var culture in cultures)
			{
				status = double.TryParse(userInput, culture, out userDouble);
				// Console.WriteLine((Convert.ToChar(userDouble))); // Unhandled exception. System.InvalidCastException: Invalid cast from 'Double' to 'Char'.
				
				// Check if userDouble contains a decimal point "."
				// If one contains the decimal, then pick it
				// If both doesn't contain decimal, also pick it
				string parsedString = userDouble.ToString();
				if (parsedString.Contains('.'))
				{
					Console.WriteLine("Contains decimal point .");
					break;
				}
				Console.WriteLine($"{status} {userDouble}");	
			}
			if(!status)
			{
				Console.WriteLine("You did not input a number!");
			}
		} while (!status);
		Console.WriteLine($"Your input number: {userDouble}");
	}
}