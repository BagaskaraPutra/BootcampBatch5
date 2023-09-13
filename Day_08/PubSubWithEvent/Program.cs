//Pub-Sub with Event
//Youtube

using PubSubWithEvent;
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