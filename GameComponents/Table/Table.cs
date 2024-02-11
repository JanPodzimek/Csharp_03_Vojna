using System.ComponentModel.Design;

namespace Vojna 
{
	public class Table 
	{
		public DeckOfCards Deck {get; private set;}
		public List<Card> CardsOnTheTable { get; private set;}
		public Player[] Players {get; set;}
		public Dice Dice { get;}
		public bool Draw { get; set; }
		public int WinnerId { get; set; }
		public int LooserId { get; set; }
		
		public Table()
		{
			Deck = new DeckOfCards();
			Players = new Player[]{new("Jenda"), new("AI")};
			Dice = new Dice();
			CardsOnTheTable = new List<Card>();
			Draw = false;
		}
		
		public void DealTheCards(DeckOfCards deck) {
			for (int i = 0; i < DeckOfCards.numberOfCardsInDeck; i++) 
			{
				Card card = Deck.Deck[i];
				if (i % 2 == 0) 
				{
					card.SetOwnerId(HumanPlayer());
					HumanPlayer().Cards.Add(card);
				} 
				else 
				{
					card.SetOwnerId(AiPlayer());
					AiPlayer().Cards.Add(card);
				}
			}
		}
		
		public void PutCardOnTable(Player player)
		{
			Card card = player.Cards[Dice.Rnd.Next(0, player.Cards.Count)];
			player.Cards.Remove(card);
			CardsOnTheTable.Add(card);
			Console.Write($"{card}");
		}
		
		public Card GetLastPlayedCard(Player player)
		{
			int index = CardsOnTheTable.FindLastIndex(item => item.OwnerId == player.PlayerId);
			return CardsOnTheTable[index];
		}

		public void AddAllWonCardsToHand()
		{
			Players[WinnerId - 1].Cards.AddRange(CardsOnTheTable);
			
			foreach (Card card in Players[WinnerId - 1].Cards)
			{
				if (card.OwnerId != WinnerId)
				card.OwnerId = WinnerId;
			}
		}
		
		public Player HumanPlayer()
		{
			return Players.ToList().First(player => !player.Name.ToUpper().Equals("AI"));
		}
		
		public Player AiPlayer()
		{
			return Players.ToList().First(player => player.Name.ToUpper().Equals("AI"));
		}
		
		public void ClearTable()
		{
			CardsOnTheTable.Clear();
		}
	}
}