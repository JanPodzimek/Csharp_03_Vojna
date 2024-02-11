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

		public override string ToString()
		{
			return $"{Name}";
		}
	}
}