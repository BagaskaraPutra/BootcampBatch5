using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Program
{
	static void Main()
	{
		// Func
		Func<string> myMessages = WarningMessage;
		myMessages += ErrorMessage;
		Console.WriteLine(myMessages.Invoke()); // Only prints the last registered function
		Delegate[] dels = myMessages.GetInvocationList();
		
		// Prints every function registered in myMessages
		foreach(Func<string> x in dels) {
			Console.WriteLine(x.Invoke());
		}
		
		// Action
		// public delegate void myEventActions(object? sender, EventArgs e);
		// public delegate void EventHandler(object? sender, EventArgs e);
		Action<object?,EventArgs> myEventActions; // Equivalent to an EventHandler ?
		Action<string> myPrinters = WarningPrinter;
		myPrinters += ErrorPrinter;
		myPrinters.Invoke("in vehicle number 1");
		
		// Lambda expression
		Func<string> myFuncPrint = () => "Hellooo"+"World";
		Func<string> myFuncPrint2 = () => "WOW";
		Func<string> result = myFuncPrint + myFuncPrint2;
		result += () => "!!!";
		
		dels = result.GetInvocationList();
		Console.WriteLine("Number of registered functions in result: " + dels.Length);
		
		foreach(Func<string> x in dels) {
			Console.WriteLine(x.Invoke());
		}
		
		// Cannot unregister a lambda expression from a delegate or its derivatives
		result -= () => "!!!";
		dels = result.GetInvocationList();
		Console.WriteLine("Number of registered functions in result: " + dels.Length);
		
		foreach(Func<string> x in dels) {
			Console.WriteLine(x.Invoke());
		}
		
	}
	static string WarningMessage()
	{
		return "WARNING!";
	}
	static string ErrorMessage()
	{
		return "ERROR!";
	}
	static void WarningPrinter(string x)
	{
		Console.WriteLine($"[Warning!] {x}");	
	}
	static void ErrorPrinter(string x)
	{
		Console.WriteLine($"[Error!] {x}");
	}
	
}

