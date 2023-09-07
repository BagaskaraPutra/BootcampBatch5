namespace AbstractClassPetShop;

class Dog : Animal, ILandAnimal
{	
	private string _race = "wolf";
	public Dog(string name, string gender, int age, string race)
		: base(name, gender, age)
	{
		this._race = race;
	}
	public void MakeSound() 
	{
		Console.WriteLine("Woof !!!");
	}
	public void Jump() 
	{
		Console.WriteLine("Jump ...");
	}
	public new void Eat() //recommended : new, kalau ga ya gapapa
	{
		Console.WriteLine("Dog Eat");
	}
}