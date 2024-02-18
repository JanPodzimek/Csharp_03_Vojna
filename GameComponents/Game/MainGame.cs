
using System.Dynamic;

namespace Vojna
{
	public class Game
	{
		public Table Table { get; set; }
		public BasicRound BasicRound { get; set; }
		public ExtraRound ExtraRound { get; set; } 
		public static bool RoundType { get; set; } 
		// RoundType = false, means Basic round, otherwise means Extra round

		public Game() {
			Table = new Table();
			Table.DealTheCards(Table.Deck);
			BasicRound = new BasicRound(Table);
			ExtraRound = new ExtraRound(Table);
			RoundType = false;
		}
		
		public void SetUp()
		{
			SetUpBeforeGame.SetPlayerName(Table.Players[0]);
		}
		
		public void Play()
		{
			Announcements.AnnoucStart();
			while (Player.CheckCards(Table.HumanPlayer(), Table.AiPlayer()))
			{
				RoundType = false;
				BasicRound.StartRound();
				BasicRound.Decision();
				if (!Table.Draw) 
				{
					BasicRound.FinishRound();
				}
				else 
				{
					RoundType = true;
					ExtraRound.StartRound();
					ExtraRound.Decision();
					if (!Table.Draw) 
					{
						ExtraRound.FinishRound();
					}
					else 
					{
						while (Table.Draw && Player.CheckCards(Table.HumanPlayer(), Table.AiPlayer()))
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
		