using Auto;
class Program
{
	static void Main()
	{
		PetrolEngine vtec = new PetrolEngine("VTEC", "gasoline", 4);
		DieselEngine kdToyota = new DieselEngine("KD Toyota", "solar", 4);
		ElectricEngine electricEngine = new ElectricEngine("Tesla", "Li-ion battery", 375);
		Tire bridgestone = new Tire("Bridgestone", 40);
		Tire goodyear = new Tire("Goodyear", 45);
		
		Car<PetrolEngine> honda = new Car<PetrolEngine>("Honda", vtec, bridgestone);
		Car<DieselEngine> toyota = new Car<DieselEngine>("Toyota", kdToyota, goodyear);
		Car<ElectricEngine> tesla = new Car<ElectricEngine>("Tesla", electricEngine, bridgestone);
		
		
		Console.WriteLine(honda.CheckBrandName() + " engine object: " + honda.CheckEngine());
		Console.WriteLine(toyota.CheckBrandName() + " engine object: " + toyota.CheckEngine());
		Console.WriteLine(tesla.CheckBrandName() + " engine object: " + tesla.CheckEngine());
		
		honda.CheckEngine().EngineRun();
		toyota.CheckEngine().EngineRun();
		tesla.CheckEngine().EngineRun();
		
		Console.WriteLine(honda.CheckBrandName() + " number of cylinders: " + honda.CheckEngine().CheckCylinders());
		Console.WriteLine(toyota.CheckBrandName() + " number of cylinders: " + toyota.CheckEngine().CheckCylinders());
		Console.WriteLine(tesla.CheckBrandName() + " voltage: " + tesla.CheckEngine().CheckVoltage());
	}
}