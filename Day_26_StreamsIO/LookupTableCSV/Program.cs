// Source: https://joshclose.github.io/CsvHelper/getting-started/

using CsvHelper;
using System.Globalization;
using LookupTableCSV;
using CsvHelper.Configuration;
public class Program
{
	static void Main()
	{
		List<Person> personsList;

		using (var reader = new StreamReader("lookupTable.csv"))
		using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
		{
			csv.Context.RegisterClassMap<PersonMap>();
			var persons = csv.GetRecords<Person>();
			personsList = persons.ToList();
		}
		foreach (var person in personsList)
		{
			Console.WriteLine($"id: {person.Id}, name: {person.Name}, age: {person.Age}, job: {person.Job}");
		}
		int inputId = 303;
		string inputName = "Alex";
		string outputJob = personsList.FirstOrDefault(x => x.Id == inputId && x.Name == inputName ).Job;
		Console.WriteLine(outputJob);
	}
}