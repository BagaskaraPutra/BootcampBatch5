// Source: https://www.geeksforgeeks.org/c-sharp-program-to-implement-idisposable-interface/

// Code Implementation of IDisposable interface in C#
using System;

namespace GFG
{
	/// <summary>
	/// A File class which acts
	/// as an unmanaged data
	/// </summary>
	public class File
	{
		public string Name
		{
			get;
			set;
		}

		public File(string name) { this.Name = name; }
	}

	/// <summary>
	/// File Handler class which
	/// implements IDisposable
	/// interface
	/// </summary>
	public class FileHandler : IDisposable
	{
		// unmanaged object
		private File? _fileObject = null;

		// managed object
		private static int _totalFiles = 0;

		// boolean variable to ensure dispose
		// method executes only once
		private bool _disposedValue;
		private bool disposedValue;

		// Constructor
		public FileHandler(string fileName)
		{
			if (_fileObject == null)
			{
				_totalFiles++;
				_fileObject = new File(fileName);
			}
		}
		
		// Get the details of the file object
		public void GetFileDetails()
		{
			Console.WriteLine(
				"{0} file has been successfully created.",
				_fileObject.Name);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
					_totalFiles = 0;
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				Console.WriteLine("The {0} has been disposed",
						  _fileObject.Name);
				_fileObject = null;
				
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		~FileHandler()
		{
			Console.WriteLine("FileHandler Destructor called");
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
		/*
// Gets called by the below dispose method
// resource cleaning happens here
protected virtual void Dispose(bool disposing)
{
	// check if already disposed
	if (!_disposedValue) {
		if (disposing) {
			// free managed objects here
			_totalFiles = 0;
		}

		// free unmanaged objects here
		Console.WriteLine("The {0} has been disposed",
						  _fileObject.Name);
		_fileObject = null;

		// set the bool value to true
		_disposedValue = true;
	}
}

// The consumer object can call
// the below dispose method
public void Dispose()
{
	// Invoke the above virtual
	// dispose(bool disposing) method
	Dispose(disposing : true);

	// Notify the garbage collector
	// about the cleaning event
	GC.SuppressFinalize(this);
}

// Destructors should have the following
// invocation in order to dispose
// unmanaged objects at the end
~FileHandler() 
{ 
	Console.WriteLine("FileHandler Destructor called");
	Dispose(disposing : false); 
}
*/
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(
				"Explicit calling of dispose method - ");
			Console.WriteLine("");

			FileHandler filehandler = new FileHandler("GFG-1");
			filehandler.GetFileDetails();
			// manual calling
			// filehandler.Dispose();
			// filehandler.Dispose();
			// filehandler.Dispose();

			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine(
				"Implicit calling using 'Using' keyword - ");
			Console.WriteLine("");
			using (FileHandler fileHandler2
				  = new FileHandler("GFG-2"))
			{
				fileHandler2.GetFileDetails();
				// The dispose method is called automatically
				// by the using keyword at the end of scope
			}
		}
	}
}