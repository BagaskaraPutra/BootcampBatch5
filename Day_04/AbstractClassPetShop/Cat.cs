namespace AbstractClassPetShop;

class Cat : Animal, ILandAnimal
{	
	private bool _isStriped;
	public string race = "tabby";
	
	public Cat(string name, string gender, int age, float bodyWeight, bool isStriped)
		: base(name, gender, age, bodyWeight)
	{
		this._isStriped = isStriped;
	}
	public override void MakeSound() 
	{
		Console.WriteLine("Meow !!!");
	}
	public void Jump() 
	{
		Console.WriteLine("Jump ...");
	}
}