namespace Auto;

public class Engine
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

public interface IEngine 
{
	// automatically set to public due to interface
	void EngineRun(); 
}

public interface ICylinderEngine
{
	int CheckCylinders();
}

public interface IElectricEngine
{
	int CheckVoltage();
}

// PistonEngine inherits from the Engine class and implements the IEngine interface
public class PistonEngine : Engine, IEngine, ICylinderEngine
{
	private int _cylinders;
	
	public PistonEngine(string brandName, string fuelType, int cylinders) 
		: base(brandName, fuelType)
	{
		this._cylinders = cylinders;
	}
	
	public void EngineRun()
	{
		Console.WriteLine("Piston Engine Running");
	}
	
	public int CheckCylinders()
	{
		return this._cylinders;
	}
}


class DieselEngine : IEngine
{
	public void EngineRun()
	{
		Console.WriteLine("Diesel Engine Running");
	}
}

class ElectricEngine : IEngine
{
	public void EngineRun()
	{
		Console.WriteLine("Electric Engine Run");
	}
}

class HydrogenEngine : IEngine
{
	public void EngineRun() 
	{
		Console.WriteLine("Hydrogen Engine Run");
	}
}

class HamsterEngine : IEngine
{
	public void EngineRun()
	{
		Console.WriteLine("Hamster Engine Run");
	}
	public void GiveHamsterFood()
	{
		Console.WriteLine("Hamster food");
	}
}
