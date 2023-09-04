namespace HewanDarat;

public class Dog
{
	private string? _name;
	private string? _gender;
	private int _age;
	
	public Dog(string? name, string? gender, int age)
	{
		this._name 		= name;
		this._gender 	= gender;
		this._age 		= age;
	}
	
	public void Bark()
	{
		Console.WriteLine($"{_name} is barking ... (GUK GUK GUK)");
	}
	
	public void Jump()
	{
		Console.WriteLine($"{_name} is jumping ...");
	}
	
	public void PrintProperty()
	{
		Console.WriteLine($"My name is {_name}. I am {_gender} dog. I am {_age} years old.");
	}
}
