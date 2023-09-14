//Pub-Sub with Event
//Youtube

using PubSubWithEvent;
class Program
{
	static void Main()
	{
		Youtuber oldYT = new("Dirty Frank");
		Youtuber newYT = new("Mr. Yeast");
		
		AnonymousSubscriber<EventArgs> anonSub = new AnonymousSubscriber<EventArgs>();
		DetailedSubscriber<EventData> detailSub = new DetailedSubscriber<EventData>("First Viewer");

		oldYT.AddSubscriber(anonSub.Notification);
		oldYT.AddSubscriber(detailSub.Notification);
		
		newYT.AddSubscriber(detailSub.Notification);
		newYT.AddSubscriber(anonSub.Notification);
		
		oldYT.UploadVideo();
		//oldYT.subscriber = null; You can't assign '=' for event delegate
		newYT.UploadVideo();
		
		newYT.RemoveSubscriber(anonSub.Notification);
		newYT.UploadVideo();
		
		oldYT.EventClear();
		oldYT.UploadVideo();
	}
}