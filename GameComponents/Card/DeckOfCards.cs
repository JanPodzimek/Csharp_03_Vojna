namespace Vojna
{
	public class DeckOfCards
	{
		public const int numberOfCardsInDeck = 32;
		public Card[] Deck { get; private set; }
		
		public DeckOfCards()
		{
			Deck = getNewDeckOfCards();
		}
		
		public Card[] getNewDeckOfCards()
		{
			List<Card> deck = new List<Card>(numberOfCardsInDeck);
			bool unique;
			int cardId = 1;
			for (int i = 0; i < numberOfCardsInDeck; i++)
			{
				Card card;
				do
				{
					unique = true;
					card = new Card();
					int value = card.Value;
					int suit = card.Suit;
					foreach (Card c in deck)
					{
						if (c.Suit == suit && c.Value == value)
							unique = false;
					}
				} while (!unique);
				card.CardId = cardId;
				cardId++;
				deck.Add(card);
			}
			return deck.ToArray();
		}
		
		public int GetRandomCardFromDeck()
		{
			Random rdn = new Random();
			return rdn.Next(1, numberOfCardsInDeck);
		}
	}
}