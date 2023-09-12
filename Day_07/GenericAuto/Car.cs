namespace Auto;

public class Car <TEngine> where TEngine: class
{
	private TEngine _engine;
	private Tire _tire;
	private string _brandName;
	
	public Car(string brandName, TEngine engine, Tire tire)
	{
		this._brandName = brandName;
		this._engine = engine;
		this._tire = tire;
	}		
	
	public TEngine CheckEngine()
	{
		return this._engine;
	}

	public string CheckBrandName()
	{
		return this._brandName;
	}
}
