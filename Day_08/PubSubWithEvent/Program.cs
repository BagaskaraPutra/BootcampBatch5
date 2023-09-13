//Pub-Sub with Event
//Youtube

using PubSubWithEvent;
class Program
{
	static void Main()
	{
		Youtuber dfYT = new("Dirty Frank");
		Youtuber myYT = new("Mr. Yeast");
		
		AnonymousSubscriber<EventArgs> anonSub = new AnonymousSubscriber<EventArgs>();
		DetailedSubscriber<EventData> someSub = new DetailedSubscriber<EventData>("First Viewer");

		dfYT.AddSubscriber(anonSub.Notification);
		dfYT.UploadVideo();
		//dfYT.subscriber = null; You cant assign '=' for event delegate
		dfYT.UploadVideo();
		
		myYT.AddSubscriber(anonSub.Notification);
		myYT.UploadVideo();
		
		dfYT.EventClear();
		dfYT.UploadVideo();
	}
}