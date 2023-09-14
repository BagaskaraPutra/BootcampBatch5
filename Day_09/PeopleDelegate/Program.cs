// Source: https://stackoverflow.com/questions/2019402/when-why-to-use-delegates

/// <summary>
/// A class to define a person
/// </summary>
public class Person
{
	public string Name { get; set; }
	public int Age { get; set; }
}

class Program
{
	//Our delegate
	// public delegate bool FilterDelegate(Person p); // original delegate
	
	static void Main(string[] args)
	{
		// Func<Person,bool> FilterDelegate; // in fact, you don't need to declare this
		// Just make sure the type passed into DisplayPeople(tring title, List<Person> people, Func<Person,bool> filter)
		// is the same as FilterDelegate
		
		//Create 4 Person objects
		Person p1 = new Person() { Name = "John", Age = 41 };
		Person p2 = new Person() { Name = "Jane", Age = 69 };
		Person p3 = new Person() { Name = "Jake", Age = 12 };
		Person p4 = new Person() { Name = "Jessie", Age = 25 };

		//Create a list of Person objects and fill it
		List<Person> people = new List<Person>() { p1, p2, p3, p4 };
		//Invoke DisplayPeople using appropriate delegate
		DisplayPeople("Children:", people, IsChild);
		DisplayPeople("Adults:", people, IsAdult);
		DisplayPeople("Seniors:", people, IsSenior);
		
		// But what if I want to pass the Is{Category} functions simultaneously into a Func?
		Func<Person,bool> FilterAgeFunc = DisplayIsChild;
		FilterAgeFunc += DisplayIsAdult;
		FilterAgeFunc += DisplayIsSenior;
		InvokePeople(people, FilterAgeFunc);

		Console.Read();
	}

	/// <summary>
	/// A method to filter out the people you need
	/// </summary>
	/// <param name="people">A list of people</param>
	/// <param name="filter">A filter</param>
	/// <returns>A filtered list</returns>
	
	// static void DisplayPeople(string title, List<Person> people, FilterDelegate filter) // original delegate
	static void DisplayPeople(string title, List<Person> people, Func<Person,bool> filter)
	{
		
		Console.WriteLine(title);

		foreach (Person p in people)
		{
			if (filter(p))
			{
				Console.WriteLine("{0}, {1} years old", p.Name, p.Age);
			}
		}

		Console.Write("\n\n");
	}

		
	static void InvokePeople(List<Person> people, Func<Person,bool> filter)
	{
		foreach (Person p in people)
		{
			Delegate[] dels = filter.GetInvocationList();
			foreach (Func<Person,bool> f in dels)
			{
				if (f(p))
				{
					Console.WriteLine("{0}, {1} years old", p.Name, p.Age);
				}	
			}
		}

		Console.Write("\n\n");
	}
	
	//==========FILTERS===================
	static bool IsChild(Person p)
	{
		return p.Age < 18;
	}

	static bool IsAdult(Person p)
	{
		return p.Age >= 18;
	}

	static bool IsSenior(Person p)
	{
		return p.Age >= 65;
	}
	
	//----CUSTOM FILTER----------------
	static bool DisplayIsChild(Person p)
	{
		if (p.Age < 18)
		{
			Console.Write("Child: ");
			return true;		
		}
		return false;
	}

	static bool DisplayIsAdult(Person p)
	{
		if (p.Age >= 18)
		{
			Console.Write("Adult: ");
			return true;	
		}
		return false;
	}

	static bool DisplayIsSenior(Person p)
	{
		if (p.Age >= 65)
		{
			Console.Write("Senior: ");
			return true;		
		}
		return false;
	}
}

