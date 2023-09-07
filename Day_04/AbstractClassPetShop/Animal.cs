using System.Text;

namespace AbstractClassPetShop;

class Animal : AbstractAnimal
{
	protected bool _isAwake;
	protected static StringBuilder? _sbAllAnimalNames = new StringBuilder();
	
	public Animal()
	{}
	public Animal(string name, string gender, int age)
	{
		this._name 		= name;
		this._gender 	= gender;
		this._age 		= age;
		// _sbAllAnimalNames = new StringBuilder(name);
		_sbAllAnimalNames.Append(name);
		_sbAllAnimalNames.Append(" ");
	}
	
	// Distinct individual objects' methods
	public void Eat() 
	{
		Console.WriteLine("Animal is eating ...");
	}
	public void WakeUp()
	{
		_isAwake = true || _allIsAwake;
	}
	public override void Sleep()
	{
		_isAwake = false && _allIsAwake;
	}
	public bool GetAwakeStatus()
	{
		return _isAwake;
	}
	
	// Make all Animal instances go to sleep
	public override void AllSleep()
	{
		_allIsAwake = false;
		_isAwake = false;
	}
	public bool GetAllAwakeStatus()
	{
		return _allIsAwake;
	}
	
	public StringBuilder GetAllAnimalNames()
	{
		return _sbAllAnimalNames;
	}
}
