using CsvHelper.Configuration;

namespace LookupTableCSV
{
	public class PersonMap: ClassMap<Person>
	{
		public PersonMap()
		{
			Map(m => m.Id).Name("id");
			Map(m => m.Name).Name("name");
			Map(m => m.Age).Name("age");
			Map(m => m.Job).Name("job");
		}		
	}
}