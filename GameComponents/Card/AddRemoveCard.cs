// /// <summary>
// 		/// card that played player who lost the round is moved into winners pack
// 		/// </summary>
// 		public void AddLoosersCardToWinnersHand() {
// 			Player winner = GetRoundWinner();
// 			Player looser = GetRoundLooser();
// 			winner.Hand.Add(new Card(looser.PlayedCardValue, looser.PlayedCardSuit));
// 			winner.ActualNumberOfCards++;
// 		}
// 		/// <summary>
// 		/// cards that played player who lost the round, includes the extra round, is moved into winners pack
// 		/// </summary>
// 		public void AddAllLoosersCardsOnTheTableToWinnersHand() {
// 			Player winner = GetRoundWinner();
// 			Player looser = GetRoundLooser();
// 			//Player winner = player2;
// 			//Player looser = player1;
// 			for (int i = 0; i < looser.CardsOnTheTable.Count; i++) {
// 				winner.Hand.Add(new Card(looser.CardsOnTheTable[i].Value, looser.CardsOnTheTable[i].Suit));
// 			}
// 			winner.ActualNumberOfCards += looser.CardsOnTheTable.Count;
// 			winner.CardsOnTheTable.Clear();
// 		}
// 		/// <summary>
// 		/// card that played player who lost the round is removed from his pack
// 		/// </summary>
// 		public void RemoveLoosersCardFromLoosersHand() {
// 			Player looser = GetRoundLooser();
// 			foreach (Card c in looser.Hand) {
// 				if (looser.PlayedCardValue == c.Value && looser.PlayedCardSuit == c.Suit) {
// 					looser.Hand.Remove(c);
// 					looser.ActualNumberOfCards--;
// 					break;
// 				}
// 			}
// 		}
// 		/// <summary>
// 		/// cards that played player who lost the round is removed from his pack, includes cards in extra round
// 		/// </summary>
// 		public void RemoveAllLoosersCardOnTheTableFromLoosersHand() {
// 			Player looser = GetRoundLooser();
// 			//Player looser = player1;
// 			for (int i = 0; i < looser.CardsOnTheTable.Count; i++) {
// 				for (int j = 0; j < looser.Hand.Count; j++) {
// 					if (looser.CardsOnTheTable[i].Value == looser.Hand[j].Value
// 						&& looser.CardsOnTheTable[i].Suit == looser.Hand[j].Suit) {
// 						looser.Hand.RemoveAt(j);
// 					}
// 				}
// 			}
// 			looser.ActualNumberOfCards -= looser.CardsOnTheTable.Count;
// 			looser.CardsOnTheTable.Clear();
// 		}
// 		/// <summary>
// 		/// in case of extra round, card from first round is add into the list of cards that are played for further use
// 		/// </summary>
// 		/// <param name="player"></param>
// 		public void SetCardsOnTheTable(Player player) {
// 			player.CardsOnTheTable.Add(new Card(player.PlayedCardValue, player.PlayedCardSuit));
// 		}