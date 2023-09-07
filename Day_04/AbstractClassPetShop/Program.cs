using AbstractClassPetShop;
class Program
{
	static void Main()
	{
		Animal animal = new Animal();
		Console.WriteLine(animal.GetAllAnimalNames()); // ""
		
		Cat cibi = new Cat("Cibi", "female", 3, false);
		Console.WriteLine(cibi.GetAllAnimalNames()); // Cibi
		
		Dog heli = new Dog("Heli", "male", 2, "kintamani");
		Console.WriteLine(heli.GetAllAnimalNames()); // Cibi Heli
		
		Fish nemo = new Fish("Nemo", "male", 1);
		Console.WriteLine(nemo.GetAllAnimalNames()); // Cibi Heli Nemo
		
		Console.WriteLine(animal.GetAllAnimalNames()); // Cibi Heli Nemo
		Console.WriteLine(cibi.GetAllAnimalNames()); // Cibi Heli Nemo
		
		cibi.WakeUp();
		Console.WriteLine(cibi.GetAwakeStatus()); // True
		Console.WriteLine(heli.GetAwakeStatus()); // False
		
		heli.WakeUp();
		Console.WriteLine(heli.GetAwakeStatus());
		
		animal.MakeSound(); // Abstract Animal Make Sound 
		// because Animal inherits from AbstractAnimal abstract class, but it is not overriden yet
		animal.Eat(); // Animal is eating...
		// because Eat() from the AbstractAnimal abstract class is overriden in the Animal class
		
		animal.AllSleep();
		
		Console.WriteLine($"Cibi AllAwake status: {cibi.GetAllAwakeStatus()}"); // False
		Console.WriteLine($"Heli AllAwake status: {heli.GetAllAwakeStatus()}"); // False
		
		Console.WriteLine($"Cibi awake status: {cibi.GetAwakeStatus()}"); // Should be False, but why still True?
		Console.WriteLine($"Heli awake status: {heli.GetAwakeStatus()}"); // Should be False, but why still True?
		// Answer: Because animal, cibi, heli, and nemo objects are all different objects.
		// Even though _isAwake is static, it is only in its objects.
		// How to solve it?
		// TODO: Using delegates
		
		cibi.Sleep();
		Console.WriteLine($"Cibi awake status: {cibi.GetAwakeStatus()}"); // False
		Console.WriteLine($"Heli awake status: {heli.GetAwakeStatus()}"); // True
		Console.WriteLine($"Nemo awake status: {nemo.GetAwakeStatus()}"); // False
		
		animal.AllWakeUp();
		Console.WriteLine($"Nemo AllAwake status: {nemo.GetAllAwakeStatus()}"); // True
		
		cibi.MakeSound(); // Meow !!!
		heli.MakeSound(); // Woof !!!
		nemo.MakeSound(); // Abstract Animal Make Sound
	}
}
