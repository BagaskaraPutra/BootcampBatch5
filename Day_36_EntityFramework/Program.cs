using EFDatabase;

class MainProgram
{
	static void Main() 
	{
		using(Northwind db = new Northwind()) 
		{
			Console.WriteLine($"Name: {db.Database}");
			Console.WriteLine($"Database.ProviderName: {db.Database.ProviderName}");
			Console.WriteLine($"Database.CanConnect(): {db.Database.CanConnect()}");
		}
	}
}