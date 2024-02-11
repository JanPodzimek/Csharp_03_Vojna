namespace Vojna 
{
	public static class SetUpBeforeGame 
	{
		/// <summary>
		/// It's likely going to be used in future development.
		/// </summary>
		/// <param name="SET NUMBER OF PLAYERS"></param>
		// public static int SetNumberOfPlayers()
		// {
		// 	string? temp;
		// 	bool isNumber;
		// 	int result = 0;
			
		// 	do
		// 	{
		// 		try
		// 		{
		// 			do 
		// 			{
		// 				Console.Write("Enter the number of players: ");
		// 				temp = Console.ReadLine();
		// 				isNumber = int.TryParse(temp, out result);
		// 				if (!isNumber)
		// 				{
		// 					Console.WriteLine($"Sorry, but \"{temp}\" is not a valid whole number, try again.\n");
		// 				}
		// 			} while (!isNumber);
					
		// 			if (result < 1)
		// 				throw new ValueMustBeHigherThanZeroException("The value must be higher than zero, try again.\n");
		// 		} 
		// 		catch (ValueMustBeHigherThanZeroException ex)
		// 		{
		// 			Console.WriteLine(ex.Message);
		// 		}
		// 	} while (result < 1);
		// 	return result;
		// }
		
		public static void SetPlayerName(Player player) {
			bool OK;
			string? playerName = "";
			do {
				Console.Write($"Enter your name: ");
				OK = true;

				try 
				{
					playerName = Console.ReadLine();
					if (playerName is null || playerName.Trim() == "")
						throw new FieldCannotBeEmptyException("Name cannot be empty, try again.\n");
					
					player.Name = playerName;
				} 
				catch (FieldCannotBeEmptyException e)
				{
					OK = false;
					Console.WriteLine(e.Message);
				}
				catch (NamesMustBeDifferentException e)
				{
					OK = false;
					Console.WriteLine(e.Message);
				}
				catch (Exception e) 
				{
					OK = false;
					Console.WriteLine(e.Message);
				}
			} while (!OK);
		}
		
		/// <summary>
		/// It's likely going to be used in future development.
		/// </summary>
		/// <param name="SET NAME OF PLAYERS"></param>
		// public static void SetPlayerNames(Player[] players) {
		// 	bool OK;
		// 	string? playerName = "";
		// 	for (int i = 0; i < players.Length; i++)
		// 	{
		// 		do {
		// 			Console.Write($"Enter the name of player{players[i].PlayerId}: ");
		// 			OK = true;

		// 			try 
		// 			{
		// 				playerName = Console.ReadLine();
		// 				if (playerName is null || playerName.Trim() == "")
		// 					throw new FieldCannotBeEmptyException("Player name cannot be empty, try again.\n");
		// 				if (i > 0 && String.Equals(playerName.ToLower(), players[i - 1].Name.ToLower()))
		// 					throw new NamesMustBeDifferentException("Player names must be different, try again.\n");
		// 				players[i].Name = playerName;
		// 			} 
		// 			catch (FieldCannotBeEmptyException e)
		// 			{
		// 				OK = false;
		// 				Console.WriteLine(e.Message);
		// 			}
		// 			catch (NamesMustBeDifferentException e)
		// 			{
		// 				OK = false;
		// 				Console.WriteLine(e.Message);
		// 			}
		// 			catch (Exception e) 
		// 			{
		// 				OK = false;
		// 				Console.WriteLine(e.Message);
		// 			}
		// 		} while (!OK);
		// 	}
		// }


		/// <summary>
		/// Sets players special ability button which is used to use his special skill.
		/// </summary>
		/// <param name="player"></param>
		public static void SetSpecialAbilityButton(Player player) {}
	}
}