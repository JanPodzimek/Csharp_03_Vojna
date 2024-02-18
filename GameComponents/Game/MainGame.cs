
using System.Dynamic;

namespace Vojna
{
	public class Game
	{
		public Table Table { get; set; }
		public BasicRound BasicRound { get; set; }
		public ExtraRound ExtraRound { get; set; } 
		public static bool IsExtraRound { get; set; } 

		public Game() {
			Table = new Table();
			Table.DealTheCards(Table.Deck);
			BasicRound = new BasicRound(Table);
			ExtraRound = new ExtraRound(Table);
			IsExtraRound = false;
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
				IsExtraRound = false;
				StartRound();
				if (!Table.Draw) 
				{
					FinishRound();
				}
				else 
				{
					IsExtraRound = true;
					StartRound();
					if (!Table.Draw) 
					{
						FinishRound();
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
		
		public void StartRound()
		{
			if (!IsExtraRound)
			{
				BasicRound.StartRound();
				BasicRound.Decision();
			}
			else 
			{
				ExtraRound.StartRound();
				ExtraRound.Decision();
			}
		}
		
		public void FinishRound()
		{
			if (!IsExtraRound)
			{
				BasicRound.FinishRound();
			}
			else 
			{
				ExtraRound.FinishRound();
			}
		}
	}
}
		