using HewanAir;
using HewanDarat;
class Program

{
	static  void Main()
	
	{
		Cat burhan = new Cat();
		Cat cibi = new Cat();
		Fish ikan = new Fish("Nemo");
		burhan.name = "Burhan";
		cibi.name = "Cibi";
		
		Console.WriteLine(burhan.name);
		Console.WriteLine(cibi.name);
		Console.WriteLine(ikan.GetName());
	}
}