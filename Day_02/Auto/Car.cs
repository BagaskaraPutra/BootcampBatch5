namespace Auto;

public class Car
{
	private IInternalCombustionEngine _internalCombustionEngine;
	private IElectricEngine _electricEngine;
	private Tire _tire;
	private string _brandName;
	
	// Polymorphism: Constructor overloading (same name, different parameters)
	public Car(string brandName, IInternalCombustionEngine engine, Tire tire)
	{
		this._brandName = brandName;
		this._internalCombustionEngine = engine;
		this._tire = tire;
	}		
	
	public Car(string brandName, IElectricEngine engine, Tire tire)
	{
		this._brandName = brandName;
		this._electricEngine = engine;
		this._tire = tire;
	}

	public IInternalCombustionEngine CheckICEngine()
	{
		return this._internalCombustionEngine;
	}
	
	public IElectricEngine CheckElectricEngine()
	{
		return this._electricEngine;
	}

	public string CheckBrandName()
	{
		return this._brandName;
	}
}
