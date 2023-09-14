using System.Reflection.Metadata;

namespace AbstractClassPetShop;

public abstract class AbstractAnimal
{
	protected string? _name;
	protected string? _gender;
	protected int _age;
	protected float _bodyMass; // kg
	public enum UnitMass
	{
		kg = 0, hg, dag, g, dg, cg, mg
	}
	protected static bool _allIsAwake;
	
	public abstract void Eat(float foodWeight, UnitMass unit);
	public abstract void Sleep(); //wajib di override
	public abstract void WakeUp(); 
	public virtual void MakeSound() {
		Console.WriteLine("Abstract Animal Make Sound");
	}
	public abstract float GetBodyMass();
}
