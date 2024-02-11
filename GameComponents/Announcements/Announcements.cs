namespace Vojna 
{
	public static class Announcements 
	{
		
		public static void AnnouncPlayerBasicRound(string name)
		{
			Console.WriteLine($"{name} plays:");
		}
		
		public static void AnnouncPlayerExtraRound(string name, int numberOfCards)
		{
			Console.WriteLine($"{name} plays another {numberOfCards} cards!");
		}
		
		public static void AnnoucStart()
		{
			Console.WriteLine();
			Console.WriteLine(@"\/ [] _| |\| /-\");
			Console.WriteLine();
			Console.WriteLine("Press enter to start the game...");
			Console.Read();
		}
		
		public static void AnnouncBasicRoundWinner(Table table)
		{
			Player winner = table.Players.First(player => player.PlayerId == table.WinnerId);
			Console.WriteLine($"{winner} won the round!");
			if (table.HumanPlayer().Cards.Count < 1 || table.AiPlayer().Cards.Count < 1)
				AnnouncGameWinner(table);
		}
		
		public static void AnnouncExtraRoundWinner(Table table)
		{
			Player winner = table.Players.First(player => player.PlayerId == table.WinnerId);
			Console.WriteLine($"{winner} won the extra round and takes all the played cards!");
			if (table.HumanPlayer().Cards.Count < 1 || table.AiPlayer().Cards.Count < 1)
				AnnouncGameWinner(table);
		}
		
		public static void AnnoucScore(int player1score, int player2score, string player1name, string player2name)
		{
			Console.WriteLine($"The score is {player1name} [{player1score}] : [{player2score}] {player2name}");
			Console.Read();
		}
		
		public static void AnnouncDraw()
		{
			Console.WriteLine();
			Console.WriteLine("It's a DRAW!");
			Console.WriteLine();
			Console.Read();
		}
		
		public static void AnnouncGameWinner(Table table)
		{
			if (table.HumanPlayer().Cards.Count < 1)
			{
				Console.WriteLine($"\nAnd it seems that {table.HumanPlayer().Name} is out of cards.");
				Console.WriteLine($"So {table.AiPlayer().Name} is the winner of the game!");
				Congratule();
			}
			
			if (table.AiPlayer().Cards.Count < 1)
			{
				Console.WriteLine($"\nAnd it seems that {table.AiPlayer().Name} is out of cards.");
				Console.WriteLine($"So {table.HumanPlayer().Name} is the winner of the game!");
				Congratule();
			}
		}
		
		public static void Congratule()
		{
			Console.WriteLine("Congratulations!");
		}
	}
}