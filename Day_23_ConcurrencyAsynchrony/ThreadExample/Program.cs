using System;
using System.Threading;
public class Program
{
	static void Main()
	{
		Thread a = new Thread(() => SayHelloTo("B0ss"));
		Thread b = new Thread(() => SayHowAreYouTo("my friend"));
		Thread c = new Thread(() => SayGoodByeTo("World"));
		a.Start();
		a.Join();
		b.Start();
		c.Start();
		Console.WriteLine("Finish conversation");
	}
	static void SayHelloTo(string a)
	{
		Console.WriteLine("Hello, " + a);
	}
	static void SayHowAreYouTo(string b)
	{
		Console.WriteLine("How are you, " + b + "?");
	}
	static void SayGoodByeTo(string c)
	{
		Console.WriteLine("Goodbye, " + c);
	}
}