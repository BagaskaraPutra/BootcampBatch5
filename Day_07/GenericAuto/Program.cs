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
		
		Car honda = new Car("Honda", vtec, bridgestone);
		Car toyota = new Car("Toyota", kdToyota, goodyear);
		Car tesla = new Car("Tesla", electricEngine, bridgestone);
		
		
		Console.WriteLine(honda.CheckBrandName() + " internal combustion engine object: " + honda.CheckICEngine());
		Console.WriteLine(toyota.CheckBrandName() + " internal combustion engine object: " + toyota.CheckICEngine());
		Console.WriteLine(tesla.CheckBrandName() + " electric engine object: " + tesla.CheckElectricEngine());
		
		honda.CheckICEngine().EngineRun();
		toyota.CheckICEngine().EngineRun();
		tesla.CheckElectricEngine().EngineRun();
		
		Console.WriteLine(honda.CheckBrandName() + " number of cylinders: " + honda.CheckICEngine().CheckCylinders());
		Console.WriteLine(toyota.CheckBrandName() + " number of cylinders: " + toyota.CheckICEngine().CheckCylinders());
		Console.WriteLine(tesla.CheckBrandName() + " voltage: " + tesla.CheckElectricEngine().CheckVoltage());
	}
}