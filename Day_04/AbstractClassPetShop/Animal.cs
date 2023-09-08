using System.Text;

namespace AbstractClassPetShop;

class Animal : AbstractAnimal
{
	protected bool _isAwake;
	protected static StringBuilder? _sbAllAnimalNames = new StringBuilder();
	
	public Animal()
	{}
	public Animal(string name, string gender, int age, float bodyWeight)
	{
		this._name 		= name;
		this._gender 	= gender;
		this._age 		= age;
		this._bodyWeight = bodyWeight;
		_sbAllAnimalNames.Append(name);
		_sbAllAnimalNames.Append(" ");
	}
	
	// Distinct individual objects' methods
	public new void Eat() 
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

	public override float GetBodyWeight()
	{
		return this._bodyWeight;
	}
	public override void Eat(float _foodWeight)
	{
		var className = GetType().Name;
		if (_foodWeight > 0)
		{
			this._bodyWeight += 0.001f*_foodWeight;
			Console.WriteLine($"{className} is eating {_foodWeight} grams of food ...");
		}
		else
		{
			Console.WriteLine("Food weight cannot be negative");
		}
	}
}
