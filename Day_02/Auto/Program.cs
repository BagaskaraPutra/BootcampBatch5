using Auto;
class Program
{
	static void Main()
	{
		PistonEngine vtec = new PistonEngine("VTEC", "gasoline", 4);
		ElectricEngine electricEngine = new ElectricEngine();
		Tire bridgestone = new Tire("Bridgestone", 40);
		
		Car honda = new Car("Honda", vtec, bridgestone);
		Car tesla = new Car("Tesla", electricEngine);
		
		Console.WriteLine(honda.CheckBrandName());
		Console.WriteLine(honda.CheckEngine());
		Console.WriteLine(tesla.CheckEngine());
		Console.WriteLine(vtec.CheckCylinders());
		honda.CheckEngine().EngineRun();
		Console.WriteLine(honda.CheckCylinderEngine());
		Console.WriteLine(honda.CheckCylinderEngine().CheckCylinders());
	}
}