
using System.Dynamic;

namespace Vojna
{
	public class Game
	{
		public Table Table { get; set; }
		public BasicRound BasicRound { get; set; }
		public ExtraRound ExtraRound { get; set; } 

		public Game() {
			Table = new Table();
			Table.DealTheCards(Table.Deck);
			BasicRound = new BasicRound(Table);
			ExtraRound = new ExtraRound(Table);
		}
		
		public void SetUp()
		{
			SetUpBeforeGame.SetPlayerName(Table.Players[0]);
		}
		
		public void Play()
		{
			Announcements.AnnoucStart();
			while (Table.Players[0].Cards.Count > 0 && Table.Players[1].Cards.Count > 0)
			{
				BasicRound.StartRound();
				BasicRound.Decision();
				if (!Table.Draw) 
				{
					BasicRound.FinishRound();
				}
				else 
				{
					ExtraRound.StartRound();
					ExtraRound.Decision();
					if (!Table.Draw) 
					{
						ExtraRound.FinishRound();
					}
					else 
					{
						while (Table.Draw && Table.Players[0].Cards.Count > 0 && Table.Players[1].Cards.Count > 0)
						{
							BasicRound.StartRound();
							BasicRound.Decision();
						}
						
						ExtraRound.FinishRound();
					}
				}
			}	
		} 
	}
}
		