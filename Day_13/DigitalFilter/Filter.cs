namespace DigitalFilter;

public class Filter
{
    public static double MovingAverage(ref Queue<double> q, double currentValue, int filterSize)
	{
		q.Enqueue(currentValue);
		double sum = 0.0;
		foreach (var el in q)
		{
			Console.Write(el + " ");
			sum += el;
		}
		double average = sum / filterSize;

		if (q.Count >= filterSize)
		{
			q.Dequeue();
		}
		return average;
	}
}
