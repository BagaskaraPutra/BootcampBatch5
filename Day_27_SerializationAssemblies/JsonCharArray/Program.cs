using System.Text.Json;


public class Card
{
	private int _orientation;
	private List<List<char>> _cardImage;
	public List<List<char>> verticalCardImage {get; set; } 
	// = new()
	// 	{
	// 		new() {'┌','─','─','─','┐'},
	// 		new() {'│',' ','H',' ','│'},
	// 		new() {'│','─','─','─','│'},
	// 		new() {'│',' ','T',' ','│'},
	// 		new() {'└','─','─','─','┘'}
	// 	};
	public List<List<char>> horizontalCardImage {get; set;}
		// = new()
	// 	{
	// 		new(){'┌','─','─','─','─','─','─','─','┐'},
	// 		new(){'│',' ','H',' ','│',' ','T',' ','│'},
	// 		new(){'└','─','─','─','─','─','─','─','┘'}
	// 	};
	
	public static List<List<char>> StaticVerticalCardImage {get; set;}
	public static List<List<char>> StaticHorizontalCardImage {get; set;}
	public Card()
	{
	}
	public Card(int orientation)
	{
		_orientation = orientation;
	}
	public void UpdateConfig()
	{
		StaticHorizontalCardImage = horizontalCardImage;
		StaticVerticalCardImage = verticalCardImage;
	}
	
	public void DisplayCard()
	{
		if(_orientation == 0)
		{
			_cardImage = StaticVerticalCardImage;
		}
		else
		{
			_cardImage = StaticHorizontalCardImage;
		}
		foreach (var rows in _cardImage)
		{
			foreach (var image in rows)
			{
				Console.Write(image);
			}
			Console.Write("\n");
		}	
	}
}

public class Program
{
	static void Main()
	{
		// Card card = new();
		// string serializer = JsonSerializer.Serialize(card);
		// using (StreamWriter fs = new StreamWriter(@"./card.json"))
		// {
		// 	fs.Write(serializer);
		// }

		Card result;
		using (StreamReader fs = new StreamReader(@"./card.json"))
		{
			string resultJson = fs.ReadToEnd();
			result = JsonSerializer.Deserialize<Card>(resultJson);
		}
		foreach (var rows in result.verticalCardImage)
		{
			foreach (var image in rows)
			{
				Console.Write(image);
			}
			Console.Write("\n");
		}
		Console.WriteLine(result.verticalCardImage);
		Console.WriteLine(result.horizontalCardImage);
		
		result.UpdateConfig();
		
		foreach (var rows in Card.StaticHorizontalCardImage)
		{
			foreach (var image in rows)
			{
				Console.Write(image);
			}
			Console.Write("\n");
		}
		
		Card card2 = new(0);
		card2.DisplayCard();
		
	}

}