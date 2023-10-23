using System.Text.Json;

public class Program
{
	static void Main()
	{
		Car car = new Car("totoya2", 4);
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
	}

}

public class Car
{
	public Car(string brand, int year)
	{
		Brand = brand;
		Year = year;
	}
	public int Year { get; private set; }
	public string Brand { get; private set; }
}