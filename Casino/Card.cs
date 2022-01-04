using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Casino;

namespace Casino
{
    public class Card
    {
        /// <summary>
        /// Collects the cards
        /// </summary>
        /// <param name="cardValue">Card number</param>
        /// <param name="suit">Suit Type</param>
        public Card(int cardValue, Enum suit)
        {
            this.cardValue = cardValue;
            this.suit = suit;
        }

        private int cardValue;
        private Enum suit;

        /// <summary>
        /// Provides the card value
        /// </summary>
        /// <returns></returns>
        public int getValue()
        {
            return this.cardValue;
        }

        /// <summary>
        /// Provides the Suit Type
        /// </summary>
        /// <returns></returns>
        public Enum getSuit()
        {
            return this.suit;
        }

        /// <summary>
        /// Fisher–Yates algo to shuffle the cards in deck
        /// </summary>
        /// <param name="deckList">Receives the list of Cards to shuffle.</param>
        /// <returns></returns>
        public static List<Card> ShuffleCard(List<Card> deckList)
        {
            Random r = new Random();
            int n = deckList.Count();
            Card[] deck = deckList.ToArray();

            for (int i = n - 1; i > 0; i--)
            {
                int j = r.Next(i + 1);
                Card temp = (Card)deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
            return deck.ToList();
        }


        /// <summary>
        /// Populate the card of type suit and returns the cards in Deck.
        /// </summary>
        /// <param name="iDealer">Dealer Interface.</param>
        /// <returns>Retunr the list of cards of all suits.</returns>
        public static List<Card> PopulateCardsDeck(DealerInterface iDealer, int deckSize = 10)
        {
            List<Card> cardDeck = new List<Card>();

            cardDeck.AddRange(iDealer.getDeck(Suit.spade, deckSize));
            cardDeck.AddRange(iDealer.getDeck(Suit.club, deckSize));
            cardDeck.AddRange(iDealer.getDeck(Suit.diamond, deckSize));
            cardDeck.AddRange(iDealer.getDeck(Suit.heart, deckSize));

            return cardDeck;
        }
    }

    /// <summary>
    /// Fixed set of Suit types (Clud, Spade, Diamond, Heart)
    /// </summary>
    public enum Suit
    {
        club,
        spade,
        diamond,
        heart
    }
}
