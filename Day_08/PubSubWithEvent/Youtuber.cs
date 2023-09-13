namespace PubSubWithEvent;

public class Youtuber
{
	private EventHandler _subscriber;
	// private EventHandler<EventData> _subscriber; // generic type EventHandler
	
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