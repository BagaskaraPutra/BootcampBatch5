namespace PubSubWithEvent;

public class AnonymousSubscriber
{
	public void Notification(object sender, EventArgs e)
	{
		Console.WriteLine($"Get message from Youtuber {sender}");
	}
}
public class DetailedSubscriber
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
