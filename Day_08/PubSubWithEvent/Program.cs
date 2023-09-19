//Pub-Sub with Event
//Youtube

using PubSubWithEvent;
class Program
{
	static void Main()
	{
		Youtuber oldYT = new("Dirty Frank");
		Youtuber newYT = new("Mr. Yeast");
		
		AnonymousSubscriber anonSub = new AnonymousSubscriber();
		DetailedSubscriber detailSub = new DetailedSubscriber("First Viewer");

		anonSub.Subscribe(oldYT);
		detailSub.Subscribe(oldYT);
		
		detailSub.Subscribe(newYT);
		anonSub.Subscribe(newYT);
		
		oldYT.UploadVideo();
		//oldYT.subscriber = null; You can't assign '=' for event delegate
		newYT.UploadVideo();
		
		detailSub.Unsubscribe(oldYT);
		oldYT.UploadVideo();
		
		anonSub.Unsubscribe(newYT);
		newYT.UploadVideo();
		
		oldYT.EventClear();
	}
}