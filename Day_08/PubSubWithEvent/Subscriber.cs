namespace PubSubWithEvent;

public interface ISubscriber
{
	void Notification(object sender, EventArgs e);
	void Subscribe(Youtuber youtuber);
	void Unsubscribe(Youtuber youtuber);
}

public class Subscriber: ISubscriber
{
	public void Notification(object sender, EventArgs e)
	{
		Console.WriteLine($"Got message from Youtuber {sender}");
	}
	public void Subscribe(Youtuber youtuber)
	{
		youtuber.AddSubscriber(Notification);
	}
	public void Unsubscribe(Youtuber youtuber)
	{
		youtuber.RemoveSubscriber(Notification);
	}
}
public class AnonymousSubscriber: Subscriber
{
}
public class DetailedSubscriber: Subscriber
{
	private string _name;
	public DetailedSubscriber(string name)
	{
		this._name = name;
	}
	public void Notification(object sender, EventData e)
	{
		Console.WriteLine($"{this._name} received notification from YouTuber {sender} [ID: {e.id}]: {e.message}");
	}
	public new void Subscribe(Youtuber youtuber)
	{
		youtuber.AddSubscriber(this.Notification);	
	}
	public new void Unsubscribe(Youtuber youtuber)
	{
		youtuber.RemoveSubscriber(this.Notification);
	}
}
