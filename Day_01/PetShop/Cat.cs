namespace HewanDarat;

public class Cat
{
	private string? _name;
	private string? _gender;
	private int _age;
	private bool _isStriped;
	
	public Cat(string? name, string? gender, int age, bool isStriped)
	{
		this._name 		= name;
		this._gender 	= gender;
		this._age 		= age;
		this._isStriped = isStriped;
	}
	
	public void Meow()
	{
		Console.WriteLine($"{_name} is meowing ... (MEOW)");
	}
	
	public void Jump()
	{
		Console.WriteLine($"{_name} is jumping ...");
	}
	
	public void PrintProperty()
	{
		string? _stripedStr;
		if (_isStriped)
		{
			_stripedStr = "a striped cat";
		}
		else
		{
			_stripedStr = "not a striped cat";
		}
		Console.WriteLine($"My name is {_name}. I am {_gender} cat. I am {_stripedStr} and I am {_age} years old.");
	}
}
