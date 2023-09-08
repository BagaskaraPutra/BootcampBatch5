namespace AbstractClassPetShop;

public abstract class AbstractAnimal
{
	protected string? _name;
	protected string? _gender;
	protected int _age;
	protected float _bodyWeight; // kg
	protected static bool _allIsAwake;
	
	public abstract void Eat(float _foodWeight);
	public abstract void Sleep(); //wajib di override 
	public virtual void MakeSound() {
		Console.WriteLine("Abstract Animal Make Sound");
	}
	
	// Shared objects' methods
	public void AllWakeUp()
	{
		_allIsAwake = true;
	}
	public abstract void AllSleep();
	public abstract float GetBodyWeight();
}
