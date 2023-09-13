public delegate void Publish(string name, string message);

class Program {
	static void Main() {
		Publisher pubY = new("Mr. Yeast");
		Publisher pubFF = new("Dizasta Music");
		Subscriber sub1 = new("Viewer 1");
		Subscriber sub2 = new("Viewer 2");
		
		pubFF.AddSubscriber(sub1.Notify);
		pubFF.AddSubscriber(sub2.Notify);
		pubFF.SendNotification();
		pubY.SendNotification(); // no subscriber in pubY yet
		pubY.RemoveSubscriber(sub1.Notify);
		pubY.RemoveSubscriber(sub2.Notify);
		
		pubY.AddSubscriber(sub1.Notify);
		pubY.AddSubscriber(sub1.Notify); // duplicate delegate 
		pubY.SendNotification();
		
		pubY.RemoveSubscriber(sub1.Notify);
		pubY.SendNotification();
		pubY.AddSubscriber(sub2.Notify);
		pubY.SendNotification();
	}
}
class Publisher {
	private Publish? _subscriber;
	private string _name;
	public Publisher(string name)
	{
		this._name = name;
	}
	public void SendNotification() {
		if(_subscriber != null) 
		{
			Console.WriteLine($"{this._name} is sending notification to subscribers ...");
			_subscriber.Invoke(this._name, "New video!");
		}
	}
	public bool AddSubscriber(Publish sub) {
		if(_subscriber is null || !_subscriber.GetInvocationList().Contains(sub))
		{
		 	_subscriber += sub;
			return true;
		}
		return false;
	}
	public void RemoveSubscriber(Publish sub) {
		_subscriber -= sub;
	}
}
class Subscriber {
	private string _name;
	public Subscriber(string name)
	{
		this._name = name;
	}
	public void Notify(string pubName, string message) {
		Console.WriteLine($"{this._name} received notification from {pubName}: {message}");
	}
}