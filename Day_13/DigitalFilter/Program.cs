using DigitalFilter;
public class Program
{
	static void Main()
	{
		const int filterSize = 20;
		const int TOn = 4;
		const int TPeriod = 5;
		const int maxValue = 4;
		const int minValue = 0;
		
		int number = 0;
		bool up = false;
		bool reset = false;

		double currentValue = 0.0;
		Queue<double> q = new();
		double averageValue = 0.0;
		
		while (number < 100)
		{
			currentValue = Signal.DiscreteSquareWave(ref up, ref reset, number, TOn, TPeriod, minValue, maxValue);
			averageValue = Filter.MovingAverage(ref q, currentValue, filterSize);
			Console.WriteLine($"| number: {number} | up: {up} | current: {currentValue} | average: {averageValue}");
			number++;
		}
	}
}