using HewanAir;
using HewanDarat;

class Program
{
	static  void Main()
	{
		Cat burhan = new Cat("Burhan", "male", 2, true);
		Cat cibi = new Cat("Cibi", "female", 3, false);
		Dog heli = new Dog("Heli", "male", 2);
		Fish ikan = new Fish("Nemo");
		
		burhan.PrintProperty();
		cibi.PrintProperty();
		heli.PrintProperty();
		
		burhan.Meow();
		cibi.Jump();
		heli.Bark();
		
		Console.WriteLine(ikan.GetName());
	}
}