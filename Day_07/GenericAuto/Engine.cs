namespace Auto;

public interface IEngine 
{
	// automatically set to public due to interface
	void EngineRun(); 
}

// IInternalCombustionEngine interface inherits from IEngine interface
public interface IInternalCombustionEngine : IEngine
{
	int CheckCylinders();
}

public interface IElectricEngine : IEngine
{
	double CheckVoltage();
}

class Engine
{
	// protected access modifier: only this class and its childs can access it
	protected string _brandName;
	protected string _fuelType;
	
	public Engine(string brandName, string fuelType)
	{
		this._brandName = brandName;
		this._fuelType = fuelType;
	}
	
	public string CheckFuelType()
	{
		return this._fuelType;
	}
}

// InternalCombustionEngine class inherits from the Engine class
class InternalCombustionEngine : Engine
{
	protected int _cylinders;

	public InternalCombustionEngine(string brandName, string fuelType, int cylinders) 
		: base(brandName, fuelType)
	{
		this._cylinders = cylinders;
	}
	public int CheckCylinders()
	{
		return this._cylinders;
	}
}

// PetrolEngine inherits from the InternalCombustionEngine class and implements the IInternalCombustionEngine interface
class PetrolEngine : InternalCombustionEngine, IInternalCombustionEngine
{
	public PetrolEngine(string brandName, string fuelType, int cylinders) 
		: base(brandName, fuelType, cylinders)
	{}
	public void EngineRun()
	{
		Console.WriteLine("Petrol Engine Running ...");
	}
}


class DieselEngine : InternalCombustionEngine, IInternalCombustionEngine
{
	public DieselEngine(string brandName, string fuelType, int cylinders) 
		: base(brandName, fuelType, cylinders)
	{}	
	public void EngineRun()
	{
		Console.WriteLine("Diesel Engine Running ...");
	}
}

class ElectricEngine : Engine, IElectricEngine
{
	private double _voltage;
	
	public ElectricEngine(string brandName, string fuelType, double voltage)
		: base(brandName, fuelType)
	{
		this._voltage = voltage;
	}
	public void EngineRun()
	{
		Console.WriteLine("Electric Engine Running ...");
	}
	public double CheckVoltage()
	{
		return this._voltage;
	}
}

class HydrogenEngine : IEngine
{
	public void EngineRun() 
	{
		Console.WriteLine("Hydrogen Engine Running ...");
	}
}

class HamsterEngine : IEngine
{
	public void EngineRun()
	{
		Console.WriteLine("Hamster Engine Running ...");
	}
	public void GiveHamsterFood()
	{
		Console.WriteLine("Hamster food");
	}
}
