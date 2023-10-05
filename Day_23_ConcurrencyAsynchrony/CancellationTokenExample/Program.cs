public class Program
{
	static async Task Main()
	{
		CancellationTokenSource cts = new();
		CancellationToken token = cts.Token;
		
		Task taskHello = SayHelloAsync(token);
		Task taskWork  = DoWorkAsync(token);

		Console.WriteLine("Press 'c' to cancel the operation.");
		char userInputChar;
		do
		{
			userInputChar = Console.ReadKey().KeyChar;
		}
		while(userInputChar != 'c');
		if(userInputChar == 'c')
		{
			cts.Cancel();
		}
		
		try
		{
			await taskWork;
			Console.WriteLine("Operation completed.");
		}
		catch (OperationCanceledException)
		{
			Console.WriteLine("Operation canceled.");
		}
		// Console.WriteLine("Operation completed.");
	}
	
	static async Task SayHelloAsync(CancellationToken token)
	{
		int i=0;
		while(true)
		{
			i++;
			await Task.Delay(2000, token);
			Console.WriteLine($"Hello! {i} times");
		}
	}
	
	static async Task DoWorkAsync(CancellationToken token)
	{
		for (int i = 0; i < 10; i++)
		{
			token.ThrowIfCancellationRequested();

			Console.WriteLine($"Work in progress: {i * 10}%");
			await Task.Delay(500, token);
		}
	}
}