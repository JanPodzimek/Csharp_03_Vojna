namespace Vojna 
{
	delegate void CardProcessor(Player player);
	public class BasicRound
	{
		public Table Table { get; set;}
		
		public BasicRound(Table table)
		{
			Table = table;
		}
		virtual public void StartRound()
		{
			// Variant with delegate for practice
			CardProcessor playerPutCardOnTable, aiPutCardOnTable;
			playerPutCardOnTable = new CardProcessor(Table.PutCardOnTable);
			aiPutCardOnTable = new CardProcessor(Table.PutCardOnTable);
			
			Announcements.AnnouncPlayer(Table.HumanPlayer().Name, ExtraRound.AlteredNumberOfCardsShowedInDraw);
			playerPutCardOnTable(Table.HumanPlayer());
			// Console.Read();
			
			Announcements.AnnouncPlayer(Table.AiPlayer().Name, ExtraRound.AlteredNumberOfCardsShowedInDraw);
			aiPutCardOnTable(Table.AiPlayer());
			// Console.Read();
			
			// foreach (Player player in Table.Players)
			// {
			// 	Announcements.AnnouncPlayerBasicRound(player.Name);
			// 	Table.PutCardOnTable(player);
			// 	Console.Read();
			// }
		}
		
		public void Decision()
		{
			Card[] temp = new Card[2];
			
			for (int i = 0; i < temp.Length; i++)
			{
				temp[i] = Table.GetLastPlayedCard(Table.Players[i]);
			}
			
			if (temp[0].Value > temp[1].Value)
			{
				Table.Draw = false; 
				Table.WinnerId = Table.HumanPlayer().PlayerId;
				Table.LooserId = Table.AiPlayer().PlayerId;
			}
			else if (temp[0].Value < temp[1].Value)
			{
				Table.Draw = false;
				Table.WinnerId = Table.AiPlayer().PlayerId;
				Table.LooserId = Table.HumanPlayer().PlayerId;
			}
			else 
			{
				Announcements.AnnouncDraw();
				Table.Draw = true;
			}
		}
		
		public virtual void FinishRound()
		{
			Table.AddAllWonCardsToHand();
			Announcements.AnnouncRoundWinner(Table);
			Announcements.AnnouncScore(Table.HumanPlayer(), Table.AiPlayer());
			Table.ClearTable(); 
			Console.Clear();
		}
		
	}
}
