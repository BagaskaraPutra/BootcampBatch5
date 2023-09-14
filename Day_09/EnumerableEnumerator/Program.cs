public class Program
{
	static void Main()
	{
		List<int> x = new List<int>() { 1, 2, 3 };

		Console.WriteLine("Iterating using foreach: ");
		foreach (var i in x)
		{
			Console.WriteLine(i);
		}

		Console.WriteLine("Iterating using Enumerator: ");
		IEnumerator<int> iterator = x.GetEnumerator();
		while (iterator.MoveNext())
		{
			Console.WriteLine(iterator.Current);
		}

		int currentInt = iterator.Current;
		Console.WriteLine("Manual Enumerator: ");
		iterator.Reset();
		currentInt = iterator.Current;
		Console.WriteLine(currentInt);
		iterator.MoveNext();
		currentInt = iterator.Current;
		Console.WriteLine(currentInt);
		iterator.MoveNext();
		currentInt = iterator.Current;
		Console.WriteLine(currentInt);
		iterator.MoveNext();
		currentInt = iterator.Current;
		Console.WriteLine(currentInt);
		iterator.MoveNext();
		currentInt = iterator.Current;
		Console.WriteLine(currentInt);
		iterator.MoveNext();
		currentInt = iterator.Current;
		Console.WriteLine(currentInt);
		iterator.MoveNext();
		currentInt = iterator.Current;
	}
}