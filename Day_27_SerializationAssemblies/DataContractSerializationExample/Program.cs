using System.Runtime.Serialization.Json;
using System.Runtime.Serialization; // for [DataMember] attribute

public class Program
{
	static void Main()
	{
		Car car = new Car();
		car.year = 4;
		car.brand = "totoya2";
		var serializer = new DataContractJsonSerializer(typeof(Car));
		using (FileStream fs = new FileStream(@"./contractCar.json", FileMode.Create))
		{
			serializer.WriteObject(fs, car);
		}
		Car result;
		using (FileStream fs = new FileStream(@"./contractCar.json", FileMode.Open))
		{
			result = (Car)serializer.ReadObject(fs);
		}
		Console.WriteLine(result.brand);
		Console.WriteLine(result.year);
	}
}

[DataContract]
public class Car
{
	[DataMember]
	public int year;
	[DataMember]
	public string brand {get; set;}
	[DataMember]
	private int x = 3;
}