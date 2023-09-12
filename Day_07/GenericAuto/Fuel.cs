using System.ComponentModel;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace Auto;

public interface IFuel<T> where T : INumber<T>
{
	T CheckAmount();
	void Use(T useAmount);
	void FillUp(T fillAmount);
}

public class Fuel<T> : IFuel<T> where T : INumber<T>
{
	private readonly T _maxCapacity;
	private readonly T _minCapacity;
	// private readonly _unit;
	private T _amount;
	public Fuel(T minCapacity, T maxCapacity, T amount)
	{
		this._minCapacity 	= minCapacity;
		this._maxCapacity 	= maxCapacity;
		this._amount 		= amount;
	}
	public T CheckAmount()
	{
		return _amount;
	}
	// public void Use<T>(T useAmount) // Do not use this! Why?
	// Because the user can call Use<float>, Use<string> 
	// which is a different type than specified in the class Fuel<T>
	public void Use(T useAmount)
	{
		this._amount -= useAmount;
		// this._amount = Subtract(this._amount, useAmount);
		if(_amount <= _minCapacity)
		{
			this._amount = _minCapacity;
			Console.WriteLine("[WARNING!!!] Fuel empty");
		}
	}
	public void FillUp(T fillAmount) 
	{
		//  this._amount = _amount + fillAmount;
		this._amount = Add(this._amount, fillAmount);
		if(_amount > _maxCapacity)
		{
			this._amount = this._maxCapacity;
			Console.WriteLine("[WARNING!!!] Fuel overloaded");
		}
	}
	
	public T Add(T left, T right)
	{
		return (left + right);
	}
	
	static T Subtract(T left, T right)
	{
		return left - right;
	}
}
