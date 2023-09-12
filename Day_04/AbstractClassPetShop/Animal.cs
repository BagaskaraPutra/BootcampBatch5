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
		this._bodyMass = bodyWeight;
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

	public override float GetBodyMass()
	{
		return this._bodyMass;
	}
	public override void Eat(float foodWeight, UnitMass unit)
	{
		var className = GetType().Name;
		if (foodWeight > 0)
		{
			this._bodyMass += (float) (Math.Pow(10,-(double)unit) * foodWeight);
			Console.WriteLine($"{className} is eating {foodWeight} {unit.ToString()} of food ...");
		}
		else
		{
			Console.WriteLine("Food weight cannot be negative");
		}
	}
}
