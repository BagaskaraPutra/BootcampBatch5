// Source: https://dotnettutorials.net/lesson/thread-pooling/

using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadPoolApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			// //Warmup Code start
			// for (int i = 0; i < 10; i++)
			// {
			// 	MethodWithThread();
			// 	MethodWithThreadPool();
			// }
			//Warmup Code start
			Stopwatch stopwatch = new Stopwatch();

			Console.WriteLine("Execution using Thread");
			stopwatch.Start();
			MethodWithThread();
			stopwatch.Stop();
			Console.WriteLine("Time consumed by MethodWithThread is : " +
								 stopwatch.ElapsedTicks.ToString());
			
			stopwatch.Reset();

			Console.WriteLine("Execution using Thread Pool");
			stopwatch.Start();
			MethodWithThreadPool();
			stopwatch.Stop();
			Console.WriteLine("Time consumed by MethodWithThreadPool is : " +
								 stopwatch.ElapsedTicks.ToString());
			
			Console.Read();
		}

		public static void MethodWithThread()
		{
			for (int i = 0; i < 10; i++)
			{
				Thread thread = new Thread(CheckThreadPoolStatus);
				thread.Start();
				// thread.Join();
			}
		}
		
		public static void MethodWithThreadPool()
		{
			for (int i = 0; i < 10; i++)
			{
				// ThreadPool.QueueUserWorkItem(new WaitCallback(Test));
				ThreadPool.QueueUserWorkItem(new WaitCallback(CheckThreadPoolStatus));
			}           
		}
		
		public static void CheckThreadPoolStatus(object obj)
		{
			Thread thread = Thread.CurrentThread;
			string message = $"Background: {thread.IsBackground}, Thread Pool: {thread.IsThreadPoolThread}, Thread ID: {thread.ManagedThreadId}";
			Console.WriteLine(message);
		}

		public static void Test(object obj)
		{
		}       
	}
}