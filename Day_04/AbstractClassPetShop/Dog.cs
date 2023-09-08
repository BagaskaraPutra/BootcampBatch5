namespace AbstractClassPetShop;

class Dog : Animal, ILandAnimal
{	
	private string _race = "wolf";
	public Dog(string name, string gender, int age, float bodyWeight, string race)
		: base(name, gender, age, bodyWeight)
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
}