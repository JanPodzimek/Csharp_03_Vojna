namespace Vojna 
{
	public class ExtraRound : BasicRound 
	{
		public int NumberOfCards { get; set; }
		
		public ExtraRound(Table table) : base(table) 
		{
			NumberOfCards = 5;
		}
		
		override public void StartRound()
		{
			SetNumberOfCards();
			foreach (Player player in Table.Players)
			{
				Announcements.AnnouncPlayerExtraRound(player.Name, NumberOfCards);
				for (int i = 0; i < NumberOfCards; i++)
				{
					Table.PutCardOnTable(player);
					
					Console.Read();
				}
			}
		}
		
		public override void FinishRound()
		{
			Table.AddAllWonCardsToHand();
			Announcements.AnnouncExtraRoundWinner(Table);
			
			if (Table.HumanPlayer().Cards.Count > 0 && Table.AiPlayer().Cards.Count > 0)
			{
			Announcements.AnnoucScore(
				Table.HumanPlayer().Cards.Count, 
				Table.AiPlayer().Cards.Count, 
				Table.HumanPlayer().Name, 
				Table.AiPlayer().Name);
			}
			
			Table.ClearTable();
			Console.Clear();
		}
		
		public void SetNumberOfCards()
		{
			int lessCards = 5;
			
			if (Table.HumanPlayer().Cards.Count < 5 || Table.AiPlayer().Cards.Count < 5)
			{
				lessCards = Math.Min(Table.HumanPlayer().Cards.Count, Table.AiPlayer().Cards.Count);
			}
			
			NumberOfCards = lessCards;
		}
	}
}