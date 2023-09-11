using System.Text;

class Program
{
	static void Main()
	{
		int x;
		ChangeTo4(out x); // out: you can use x it even though it is not assigned yet
		("Change x to 4: " + x).Dump();
		int y = 3;
		y.Checker();
		Subtract(ref y); // ref: you need to assign it first
		long longXpow = Power(x, y);
		longXpow.Dump();
		
		// Add(ref lxpow); // cannot convert 'ref long' to 'ref int'
		int intXpow = Convert.ToInt32(longXpow);
		Add(ref intXpow);

		// string mixedString = "0a1b 2-c3.0"; // will return result = 1230
		string mixedString = "0a1b 2-c3"; // will return result = 123
		mixedString.Dump();
		mixedString.Checker();
		
		object objMixedString = mixedString;
		objMixedString.Dump();
		string? asMixedString = objMixedString as string; // as: type conversion
		asMixedString.Dump();
		
		//Parsing string -> int (safety)
		bool status = int.TryParse(asMixedString, out int result);
		result.Dump();
		status.Dump();
		
		// Parsing method 1: 
		// string numbersOnly = new String(s.Where(Char.IsDigit).ToArray());
		
		// Parsing method 2:
		while(!status)
		{
			StringBuilder numbersOnlySB = new StringBuilder();
			for (int i=0; i< mixedString.Length; i++)
			{
				if (Char.IsDigit(mixedString[i]))
					numbersOnlySB.Append(mixedString[i]);
			}
			status = int.TryParse(numbersOnlySB.ToString(), out result);
		}
		result.Dump();
		status.Dump();
		
		object g = result; // boxing
		long l = (int)g; // implicitly convert to long after unboxing object to int
		Console.WriteLine(l);
		long ll = (long)(int)g; // explicitly convert to long after unboxing object to int
		ll.Dump();
		
		Parent parent = new Parent();
		Child child = new Child();
		parent.Checker();
		child.Checker();

	}
	static void Add(ref int x)
	{
		x++;
		x.Dump();
	}
	static void Subtract(ref int x)
	{
		x--;
		x.Dump();
	}
	static void ChangeTo4(out int x)
	{
		x = 4;
	}
	static long Power(int baseNum, in int n)
	{
		long power = 1;
		for (int i = 0; i < n; i++)
		{
			power = power * baseNum;
		}
		return power;
	}
}

public static class MyExtensionMethod
{
	public static void Checker(this object x)
	{
		if (x is Child)
		{
			"this object is child of Parent".Dump();
		}
		if (x is int)
		{
			"this object is int".Dump();
		}
		if (x is int y)
		{ //Pattern matching ( if x is int, then assign it to y)
			y.Dump();
		}
		if (x is ValueType)
		{
			"this object is value type".Dump();
		}
		if (!(x is ValueType))
		{
			"this object is reference type".Dump();
		}
		if (x is null)
		{
			"this object is null".Dump();
		}
		else if (x.GetType().IsClass) {
			"this object is class type".Dump();
		}
	}

	public static void Dump(this object x)
	{
		Console.WriteLine(x);
	}
}
public class Parent { }
public class Child : Parent { }