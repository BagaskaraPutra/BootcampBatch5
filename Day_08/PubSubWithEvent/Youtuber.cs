namespace PubSubWithEvent;

// public interface IYoutuber<TEvent>
// {
// 	public void UploadVideo();
// 	public void SendNotification();
// 	public bool AddSubscriber(TEvent sub);
// }

public class Youtuber 
{
	private EventHandler<EventData> _subscriber; // generic type EventHandler
	private string _name;
	private static int _id;
	
	public Youtuber(string name)
	{
		_name = name;
	}
	public void UploadVideo()
	{
		Console.WriteLine($"{this._name} is uploading a video...");
		_id++;
		SendNotification();
	}
	public void SendNotification() {
		if(_subscriber != null) 
		{
			_subscriber.Invoke(this, new EventData { id = _id, message = "Uploaded Video" });
		}
	}
	public bool AddSubscriber(EventHandler<EventData> sub) {
		if(_subscriber is null || !_subscriber.GetInvocationList().Contains(sub))
		{
		 	_subscriber += sub;
			return true;
		}
		return false;
	}
	public void RemoveSubscriber(EventHandler<EventData> sub) {
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