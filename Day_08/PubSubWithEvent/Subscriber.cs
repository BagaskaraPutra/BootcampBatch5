namespace PubSubWithEvent;

public interface ISubscriber<TEvent>
{
	void Notification(object sender, TEvent e);
}

public class AnonymousSubscriber <TEvent>: ISubscriber<TEvent>
{
	public void Notification(object sender, TEvent e)
	{
		Console.WriteLine($"Get message from Youtuber {sender}");
	}
}
public class DetailedSubscriber <TEvent>: ISubscriber<TEvent>
where TEvent: EventData
{
	private string _name;
	public DetailedSubscriber(string name)
	{
		this._name = name;
	}
	public void Notification(object sender, TEvent e)
	{
		Console.WriteLine($"{this._name} received notification from YouTuber {sender} {e.id}: {e.message}");
	}
}
