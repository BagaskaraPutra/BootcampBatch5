using System.Xml.Serialization;

public class Program
{
	static void Main()
	{
		Car car = new Car();
		Car car2 = new Car();
		car.year = 4;
		car.brand = "totoya2";
		car2.year = 5;
		car2.brand = "mitsubishi";

		List<Car> cars = new();
		cars.Add(car);
		cars.Add(car2);

		var serializer = new XmlSerializer(typeof(List<Car>));
		using (StreamWriter fs = new StreamWriter(@"./listOfCars.xml"))
		{
			serializer.Serialize(fs, cars);
		}

		List<Car> result;
		using (StreamReader fs = new StreamReader(@"./listOfCars.xml"))
		{
			result = (List<Car>)serializer.Deserialize(fs);
		}
		foreach (Car c in result)
		{
			Console.WriteLine(c.year);
		}
	}
}

public class Car
{
	public int year;
	public string brand { get; set; }
}