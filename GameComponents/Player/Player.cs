namespace Vojna
{
	public class Player
	{
		private static int Id = 0;
		public int PlayerId {get; private set;}
		public string Name {get; set;}
		public List<Card> Cards {get; set;}
		public ConsoleKeyInfo GameButton {get; set;}

		public Player()
		{
			Id++;
			PlayerId = Id;
			Name = "";
			Cards = new List<Card>();
		}
		public Player(string name)
		{
			Id++;
			PlayerId = Id;
			Name = name;
			Cards = new List<Card>();
		}
		
		public static bool CheckCards(Player p1, Player p2)
		{
			if (p1.Cards.Count > 0 && p2.Cards.Count > 0)
			{
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			return $"{Name}";
		}
	}
}