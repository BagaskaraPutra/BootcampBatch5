using HewanAir;
using HewanDarat;

class Program
{
	static  void Main()
	{
		Cat burhan = new Cat("Burhan", "male", 2, true);
		Cat cibi = new Cat("Cibi", "female", 3, false);
		Fish ikan = new Fish("Nemo");
		
		burhan.PrintProperty();
		cibi.PrintProperty();
		burhan.Meow();
		cibi.Jump();
		Console.WriteLine(ikan.GetName());
	}
}