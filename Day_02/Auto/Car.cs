namespace Auto;

public class Car
{
	private IEngine _engine;
	private ICylinderEngine _cylinderEngine;
	private Tire _tire;
	private string _brandName;
	
	// Polymorphism: Constructor overloading (same name, different parameters)
	public Car()
	{}
	
	public Car(string brandName, IEngine engine)
	{
		this._brandName = brandName;
		this._engine = engine;
	}
	public Car(string brandName, IEngine engine, Tire tire)
	{
		this._brandName = brandName;
		this._engine = engine;
		this._tire = tire;
	}	

	public IEngine CheckEngine()
	{
		return this._engine;
	}
	
	public ICylinderEngine CheckCylinderEngine()
	{
		return this._cylinderEngine;
	}
	
	public string CheckBrandName()
	{
		return this._brandName;
	}
}
