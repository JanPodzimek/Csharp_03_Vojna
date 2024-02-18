namespace Vojna 
{
	public class ExtraRound : BasicRound 
	{
		public const int StandardNumberOfCardsShowedInDraw = 10;
		public int AlteredNumberOfCardsShowedInDraw { get; set;}
		
		public ExtraRound(Table table) : base(table) 
		{
			AlteredNumberOfCardsShowedInDraw = StandardNumberOfCardsShowedInDraw;
		}
		
		override public void StartRound()
		{
			SetNumberOfCardsForDraw();
			foreach (Player player in Table.Players)
			{
				Announcements.AnnouncPlayerExtraRound(player.Name, AlteredNumberOfCardsShowedInDraw);
				for (int i = 0; i < AlteredNumberOfCardsShowedInDraw; i++)
				{
					Table.PutCardOnTable(player);
					// Console.Read();
				}
			}
		}
		
		public override void FinishRound()
		{
			Table.AddAllWonCardsToHand();
			Announcements.AnnouncRoundWinner(Table);
			Announcements.AnnouncScore(Table.HumanPlayer(), Table.AiPlayer());
			Table.ClearTable();
			Console.Clear();
		}
		
		public void SetNumberOfCardsForDraw()
		{
			int numberOfCards = StandardNumberOfCardsShowedInDraw;
			
			if (Table.HumanPlayer().Cards.Count < StandardNumberOfCardsShowedInDraw || 
				Table.AiPlayer().Cards.Count < StandardNumberOfCardsShowedInDraw)
			{
				numberOfCards = Math.Min(Table.HumanPlayer().Cards.Count, Table.AiPlayer().Cards.Count);
				AlteredNumberOfCardsShowedInDraw = numberOfCards; return;
			}
			
			AlteredNumberOfCardsShowedInDraw = StandardNumberOfCardsShowedInDraw;
		}
	}
}