using OverridingPetShop;
class Program
{
	static void Main()
	{
		Cat cibi = new Cat("Cibi", "female", 3, false);
		Dog heli = new Dog("Heli", "male", 2, "kintamani");
		Fish nemo = new Fish("Nemo", "male", 1);
		
		// Static shared variable _isAwake
		cibi.WakeUp();
		Console.WriteLine(cibi.GetIndividualAwakeStatus()); // True
		Console.WriteLine(heli.GetIndividualAwakeStatus()); // True
		// Even though GetIndividualAwakeStatus() is non-static, but 
		// because _isAwake is static, _isAwake is shared through the whole instances
		
		//Overriding
		Animal landAnimal = cibi;
		cibi.MakeSound(); 		//meow
		landAnimal.MakeSound(); //meow

		Animal waterAnimal = nemo;
		waterAnimal.MakeSound();  // Animal MakeSound
		// Animal MakeSound still appears even though there is no MakeSound() in the Fish class 
		// because nemo (child object) is passed into waterAnimal (parent object)
		// TODO: Solve using interface aggregation principle
		
		//Method Hiding
		cibi.Eat(); 		//Cat is eating ...
		landAnimal.Eat(); 	//Animal is eating ...
		waterAnimal.Eat(); 	// Animal is eating
		nemo.Eat();  		// Fish is eating ...
		
		//Static shared variable example 2
		Console.WriteLine(Animal.GetAwakeStatus()); // True
		nemo.SleepingGas();
		Console.WriteLine(Animal.GetAwakeStatus()); // False
		heli.WakeUp();
		Console.WriteLine(Animal.GetAwakeStatus()); // True
		
		// Casting Parent -> Child (InvalidCastException)
		Animal genericAnimal = new Animal();
		// Cat cat2 = (Cat) genericAnimal; // Unhandled exception. System.InvalidCastException: Unable to cast object of type 'OverridingPetShop.Animal' to type 'OverridingPetShop.Cat'.
		
		// Casting Child -> Parent -> Chid (Bisa)
		Animal animal = cibi;
		Cat cat3 = (Cat) animal;
		cat3.MakeSound();
	}
}
