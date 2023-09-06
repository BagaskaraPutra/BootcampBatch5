namespace OverridingPetShop;

class Fish : Animal
{
	public Fish(string name, string gender, int age)
		: base(name, gender, age)
	{
	}
	public new void Eat()
	{
		Console.WriteLine("Fish is eating ...");
	}
}
