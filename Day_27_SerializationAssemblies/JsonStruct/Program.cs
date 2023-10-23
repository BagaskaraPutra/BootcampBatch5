using System.Text.Json;
using DominoConsole;

public class Program
{
	static void Main()
	{
		Car car = new Car("totoya", 4, 2, 3);
		// car.year = 4;
		// car.brand = "totoya2";
		string serializer = JsonSerializer.Serialize(car);
		using (StreamWriter fs = new StreamWriter(@"./singleCar.json"))
		{
			fs.Write(serializer);
		}

		Car result;
		using (StreamReader fs = new StreamReader(@"./singleCar.json"))
		{
			string resultJson = fs.ReadToEnd();
			result = JsonSerializer.Deserialize<Car>(resultJson);
		}
		Console.WriteLine(result.Year);
		Console.WriteLine(result.Brand);
		Console.WriteLine(result.Position.X);
		Console.WriteLine(result.Position.Y);
	}
}

public class Car
{
	public Car(){}
	public Car(string brand, int year, int x, int y)
	{
		Brand = brand;
		Year = year;
		Position = new PositionStruct(x,y);
	}
	public int Year { get; set; } // fail when private set
	public string Brand { get; set; } // fail when private set
	public PositionStruct Position {get; set;}
}