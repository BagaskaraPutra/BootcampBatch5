using System.Collections;
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
		
		bool dotDecimal = false;
	
		// do
		// {
			// Console.Write("Please input any number ... ");
			// string? userInput = Console.ReadLine();
			
			// string userInput = "69420";
			// string userInput = "69,420"; // this is ambiguous
			// string userInput = "6,942,042,069.420";
			// string userInput = "6,942,042,069.420.69";
			// string userInput = "69.420"; // this is ambiguous
			// string userInput = "6.942.042.069,420";
			// string userInput = "6.942.042.069.420,69";
			string userInput = "6.942.042.069,420,69";
			// string userInput = "0225,1 00,52 1. 13"; // FAIL
			
			// TODO: Remove spaces from string
			// TODO: Reduce ambiguity by prompting user to use "." or "," decimal
			Console.WriteLine("userInput: " + userInput);
			
			var indexesOfComma = userInput.AllIndexesOf(",");
			var indexesOfDot = userInput.AllIndexesOf(".");
			foreach (var indexOfComma in indexesOfComma)
			{
				Console.WriteLine(indexOfComma);
			} 
			foreach (var indexOfDot in indexesOfDot)
			{
				Console.WriteLine(indexOfDot);
			}
			
			int lengthOfString = userInput.Length;
			int numberOfCommas = indexesOfComma.Count();
			int numberOfDots = indexesOfDot.Count();
			Console.WriteLine("Number of commas: " + numberOfCommas);
			Console.WriteLine("Number of dots: " + numberOfDots);
			int digitsBetweenGroupsAndDecimal = 0;
			
			// (DONE): Check for decimal points
			// If , is before . , check how many digits are after ,
			// If . is before , , check how many digits are after .
			// If !=4 invalid floating point number
			
			// TODO: Reduce code duplication by making it a function
			
			// Check which indexOf... has 1 element of decimal
			if (numberOfCommas > numberOfDots)
			{
				Console.WriteLine("Probable dot decimal");
				if (numberOfDots == 0)
				{
					digitsBetweenGroupsAndDecimal = lengthOfString - indexesOfComma.Last();
				}
				else if (numberOfDots == 1)
				{
					digitsBetweenGroupsAndDecimal = indexesOfDot.ElementAtOrDefault(0) - indexesOfComma.Last();
				}
				
				if (numberOfDots == 0 || numberOfDots == 1)
				{
					Console.WriteLine("Still probable dot decimal");
					Console.WriteLine(digitsBetweenGroupsAndDecimal);
					if (digitsBetweenGroupsAndDecimal != 4)
					{
						Console.WriteLine("Invalid floating point number!");
					}
					else
					{
						int prevIndexOfComma = 0;
						foreach (var indexOfComma in indexesOfComma)
						{
							if ((indexOfComma - prevIndexOfComma != 4) 
								&& (prevIndexOfComma != 0))
							{
								Console.WriteLine("Invalid digit group index!");
								break;
							}
							prevIndexOfComma = indexOfComma; 
						}
						dotDecimal = true;
					}
				}
				else
				{
					Console.WriteLine("Invalid floating point number");
				}
			}
			else if (numberOfCommas < numberOfDots)
			{
				Console.WriteLine("Probable comma decimal");
				if (numberOfCommas == 0)
				{
					digitsBetweenGroupsAndDecimal = lengthOfString - indexesOfDot.Last();
				}
				else if (numberOfCommas == 1)
				{
					digitsBetweenGroupsAndDecimal = indexesOfComma.ElementAtOrDefault(0) - indexesOfDot.Last();
				}
				
				if (numberOfCommas == 0 || numberOfCommas == 1)
				{
					Console.WriteLine("Still probable comma decimal");
					Console.WriteLine(digitsBetweenGroupsAndDecimal);
					if (digitsBetweenGroupsAndDecimal != 4)
					{
						Console.WriteLine("Invalid floating point number!");
					}
					else
					{
						int prevIndexOfDot = 0;
						foreach (var indexOfDot in indexesOfDot)
						{
							if ((indexOfDot - prevIndexOfDot != 4) 
								&& (prevIndexOfDot != 0))
							{
								Console.WriteLine("Invalid digit group index!");
								break;
							}
							prevIndexOfDot = indexOfDot; 
						}
						dotDecimal = false;
					}
				}
				else
				{
					Console.WriteLine("Invalid floating point number");
				}
			}
			else
			{
				if (numberOfCommas == 0 || numberOfDots == 0)
				{
					Console.WriteLine("No decimal");
				}
				else if (indexesOfComma.ElementAtOrDefault(0) > indexesOfDot.ElementAtOrDefault(0))
				{
					Console.WriteLine("Comma decimal");
					dotDecimal = false;
				}
				else
				{
					Console.WriteLine("Dot decimal");
					dotDecimal = true;
				}	
			}
			
			if (dotDecimal)
			{
				status = double.TryParse(userInput, new CultureInfo("en-US"), out userDouble);
			}
			else
			{
				status = double.TryParse(userInput, new CultureInfo("id-ID"), out userDouble);
			}
			
			// foreach (var culture in cultures)
			// {
			// 	status = double.TryParse(userInput, culture, out userDouble);
			// 	// Console.WriteLine((Convert.ToChar(userDouble))); // Unhandled exception. System.InvalidCastException: Invalid cast from 'Double' to 'Char'.
				
			// 	// Check if userDouble contains a decimal point "."
			// 	// If one contains the decimal, then pick it
			// 	// If both doesn't contain decimal, also pick it
			// 	string parsedString = userDouble.ToString();
			// 	if (parsedString.Contains('.'))
			// 	{
			// 		Console.WriteLine("Contains decimal point .");
			// 		break;
			// 	}
			// 	Console.WriteLine($"{status} {userDouble}");	
			// }
			
			if(!status)
			{
				Console.WriteLine("You did not input a valid number!");
			}
		// } while (!status);
		Console.WriteLine($"Your input number: {userDouble}");
	}
}

public static class MyExtensionMethod
{
	// Source: https://stackoverflow.com/questions/12765819/more-efficient-way-to-get-all-indexes-of-a-character-in-a-string
	public static IEnumerable<int> AllIndexesOf(this string str, string searchstring)
	{
		int minIndex = str.IndexOf(searchstring);
		while (minIndex != -1)
		{
			yield return minIndex;
			minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length);
		}
	}

	public static void Dump(this object x)
	{
		Console.WriteLine(x);
	}
}