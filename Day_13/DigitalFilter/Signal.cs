namespace DigitalFilter;

public class Signal
{
    public static double DiscreteSquareWave(ref bool up, ref bool reset, int number, uint TOn, uint TPeriod, double minValue, double maxValue)
	{
		// bool up = false; // TODO: Cannot set to static in C#, unlike C++
		// bool reset = false;
		
		if (number % TPeriod == 0 && !reset)
		{
			up = !up;
			reset = true; 
		}
		if (number % TOn == 0 && reset)
		{
			up = !up;
		}
		
		double currentValue = up ? maxValue : minValue;
		return currentValue;
	}
}
