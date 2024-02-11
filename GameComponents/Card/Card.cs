namespace Vojna
{
	public class Card
	{
		public int CardId { get; set; }
		public int Value { get; private set; }
		public int Suit { get; private set; }
		public int OwnerId { get; set; }

		public Card()
		{
			Random rnd = new Random();
			Value = rnd.Next(7, 15);
			Suit = rnd.Next(1, 5);
		}
		
		public Card(int value, int suit)
		{
			Value = value;
			Suit = suit;
		}
		
		public void SetOwnerId(Player player)
		{
			OwnerId = player.PlayerId;
		}

		public override string ToString()
		{
			string stringValue = "", stringSuit = "";
			switch (Value)
			{
				case 7: stringValue = "7"; break;
				case 8: stringValue = "8"; break;
				case 9: stringValue = "9"; break;
				case 10: stringValue = "10"; break;
				case 11: stringValue = "Jack"; break;
				case 12: stringValue = "Queen"; break;
				case 13: stringValue = "King"; break;
				case 14: stringValue = "Ace"; break;
				default: break;
			}
			switch (Suit)
			{
				case 1: stringSuit = "Clubs"; break;
				case 2: stringSuit = "Diamonds"; break;
				case 3: stringSuit = "Hearts"; break;
				case 4: stringSuit = "Spades"; break;
				default: break;
			}
			return $"| {stringValue}\n| {stringSuit}\n";
		}
	}
}