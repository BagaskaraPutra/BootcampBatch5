class LivingBeing {
	public bool isAlive;
}
class Animal : LivingBeing {
	public string name;
	public string age;
	public Animal(string name) {
		Console.WriteLine($"Animal {name} Created");
	}

	public void Eat() {
		Console.WriteLine("Eat");
	}
}
class Fish : Animal {
	public Fish() : base("fish")
	{
		Console.WriteLine("Fish Created");
	}
	public void Swim() {
		Console.WriteLine("Swim");
	}
}
class Cat : Animal {
	public Cat(string name) : base(name) {
		Console.WriteLine($"Cat {name} created");
		this.name = name;
	}
	public void Meow() {
		Console.WriteLine("Meow");
	}
	public void Jump() {
		Console.WriteLine("Jump");
	}
}

class Program {
	static void Main() {
		Cat cat = new Cat("cibi");
		Console.WriteLine(cat.name);
		cat.Eat();
		cat.Meow();
		cat.Jump();
		Console.WriteLine(cat.isAlive);
		
		Fish fish = new Fish();
		fish.Eat();
		fish.Swim();
		
		Animal animal = new Animal("kucing");
		animal.Eat();
		Console.WriteLine(animal.name);
	}
}