using AbstractClassPetShop;
class Program
{
	static void Main()
	{
		Cat cibi = new Cat("Cibi", "female", 3, false);
		Dog heli = new Dog("Heli", "male", 2, "kintamani");
		Fish nemo = new Fish("Nemo", "male", 1);
		
		cibi.WakeUp();
		Console.WriteLine(cibi.GetAwakeStatus()); // True
		Console.WriteLine(heli.GetAwakeStatus()); // False
		
		heli.WakeUp();
		Console.WriteLine(heli.GetAwakeStatus());
		
		Animal animal = new Animal();
		animal.MakeSound(); // Abstract Animal Make Sound 
		// because Animal inherits from AbstractAnimal abstract class, but it is not overriden yet
		animal.Eat(); // Animal is eating...
		// because Eat() from the AbstractAnimal abstract class is overriden in the Animal class
		
		animal.AllSleep();
		Console.WriteLine(cibi.GetAllAwakeStatus()); // False
		Console.WriteLine(heli.GetAllAwakeStatus()); // False
		Console.WriteLine(cibi.GetAwakeStatus()); // Should be False, but why still True?
		Console.WriteLine(heli.GetAwakeStatus()); // Should be False, but why still True?
	}
}
