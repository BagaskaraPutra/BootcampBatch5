namespace OverridingPetShop;

class Animal 
{
	private string? _name;
	private string? _gender;
	private int _age;
	private static bool _isAwake;
	
	public Animal()
	{}
	public Animal(string name, string gender, int age)
	{
		this._name 		= name;
		this._gender 	= gender;
		this._age 		= age;
	}
	public virtual void MakeSound() 
	{
		Console.WriteLine("Animal MakeSound");
	}
	public void Eat() 
	{
		Console.WriteLine("Animal is eating ...");
	}
	public void WakeUp()
	{
		_isAwake = true;
	}
	public void SleepingGas()
	{
		_isAwake = false;
	}
	public static bool GetAwakeStatus()
	{
		return _isAwake;
	}
	public bool GetIndividualAwakeStatus()
	{
		return _isAwake;
	}
}
