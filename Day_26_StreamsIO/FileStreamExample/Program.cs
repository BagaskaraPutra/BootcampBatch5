using System.Text;
using System.IO;
using Microsoft.Win32.SafeHandles;

public class Program
{
	static async Task Main()
	{
		string myString = "Hello, World! How are you?";
		byte[] bytes;
		string myPath = @"./bootcamp.txt";
		FileStream fs = new FileStream(myPath, FileMode.Create, FileAccess.Write);
		using(fs)
		{
			bytes = Encoding.UTF8.GetBytes(myString);
			fs.Write(bytes, 0, bytes.Length);	
		}
		
		var handle = new SafeFileHandle();
		// using(fs = new FileStream(handle, FileAccess.Read))
		// TODO: Ubuntu/Linux can still modify file even though FileShare.None
		using(fs = new FileStream(myPath, FileMode.Open, FileAccess.Read, FileShare.None))
		{
			byte[] readBytes = new byte[fs.Length];
			// while(true)
			// {
				fs.Read(readBytes, 0, readBytes.Length);
				// string myReadString = Encoding.UTF8.GetString(readBytes);
				// Console.WriteLine(myReadString);
				StringBuilder myReadSB = new();
				myReadSB.Append(Encoding.UTF8.GetChars(readBytes[0..5]));
				Console.WriteLine(myReadSB);
				myReadSB.Append(Encoding.UTF8.GetChars(readBytes[^4..]));
				Console.WriteLine(myReadSB);
				// fs.Lock(0, fs.Length);
			// }
		}
		
		myPath = @"openCreate.txt";
		using(fs = new FileStream(myPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
		{
			using(StreamWriter sw = new StreamWriter(fs))
			{
				sw.Write("Hi! ");
				sw.WriteLine("I'm fine, thank you");
				sw.WriteLine("Goodbye");
				
				await sw.WriteAsync("Hi! ");
				await sw.WriteLineAsync("I'm fine, thank you");
				await sw.WriteLineAsync("Goodbye");
			// 	var myStrings = File.ReadAllLines(myPath);
			// 	string x = "Awalan";
			// 	var newStrings = x + myStrings;
			// 	sw.WriteLine(newStrings);
			}
		}
	}
}