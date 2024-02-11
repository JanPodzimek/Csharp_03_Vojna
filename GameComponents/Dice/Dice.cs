namespace Vojna
{
	public class Dice
	{
		public int Sides {get; private set;}
		public Random Rnd {get; private set;}
		public Dice()
		{
			Sides = 6;
			Rnd = new Random();
		}
		public Dice(int sides)
		{
			Sides = sides;
			Rnd = new Random();
		}
		public int ThrowDice()
		{
			return Rnd.Next(1, Sides);
		}
		public int ThrowDice(int numberOfLeftCardsInHand)
		{
			int result;
			do
			{
				result = Rnd.Next(1, Sides);	
			} while (result > numberOfLeftCardsInHand);
			return result;
		}
	}
}