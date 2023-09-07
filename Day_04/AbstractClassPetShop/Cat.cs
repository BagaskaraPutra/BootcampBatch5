namespace AbstractClassPetShop;

class Cat : Animal, ILandAnimal
{	
	private bool _isStriped;
	public string race = "tabby";
	
	public Cat(string name, string gender, int age, bool isStriped)
		: base(name, gender, age)
	{
		this._isStriped = isStriped;
	}
	public void MakeSound() 
	{
		Console.WriteLine("Meow !!!");
	}
	public void Jump() 
	{
		Console.WriteLine("Jump ...");
	}
	public new void Eat() //recommended : new, kalau ga ya gapapa
	{
		Console.WriteLine("Cat is eating ... ");
	}
}