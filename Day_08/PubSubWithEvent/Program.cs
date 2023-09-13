//Pub-Sub with Event
//Youtube
class Program
{
	static void Main()
	{
		Youtuber dfYT = new("Dirty Frank");
		Youtuber myYT = new("Mr. Yeast");
		
		AnonymousSubscriber anon = new AnonymousSubscriber();
		DetailedSubscriber sub2 = new DetailedSubscriber("First Viewer");

		dfYT.AddSubscriber(anon.Notification);
		dfYT.UploadVideo();
		//dfYT.subscriber = null; You cant assign '=' for event delegate
		dfYT.UploadVideo();
		
		myYT.AddSubscriber(anon.Notification);
		myYT.UploadVideo();
		
		dfYT.EventClear();
		dfYT.UploadVideo();
	}
}

class Youtuber
{
	private EventHandler _subscriber;
	//  EventHandler<EventData> subscriber; // generic type EventHandler
	
	private string _name;
	
	public Youtuber(string name)
	{
		_name = name;
	}
	public void UploadVideo()
	{
		Console.WriteLine($"{this._name} is uploading a video...");
		SendNotification();
	}
	public void SendNotification() {
		if(_subscriber != null) 
		{
			// Console.WriteLine($"{this._name} is sending notification to subscribers ...");
			_subscriber.Invoke(this, new EventData { id = 1, message = "Uploaded Video" });
		}
	}
	public bool AddSubscriber(EventHandler sub) {
		if(_subscriber is null || !_subscriber.GetInvocationList().Contains(sub))
		{
		 	_subscriber += sub;
			return true;
		}
		return false;
	}
	public void RemoveSubscriber(EventHandler sub) {
		_subscriber -= sub;
	}
	public void EventClear() {
		_subscriber = null;
	}
	public override string ToString()
	{
		 return _name;
	}
}
class AnonymousSubscriber
{
	public void Notification(object sender, EventArgs e)
	{
		Console.WriteLine($"Get message from Youtuber {sender}");
	}
}
class DetailedSubscriber
{
	private string _name;
	public DetailedSubscriber(string name)
	{
		this._name = name;
	}
	public void Notification(object sender, EventData e)
	{
		Console.WriteLine($"{this._name} received notification from YouTuber {sender} {e.id}: {e.message}");
	}
}
class EventData : EventArgs
{
	public int id;
	public string message;
}