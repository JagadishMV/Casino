using Microsoft.VisualStudio.TestTools.UnitTesting;
using Casino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Tests
{
    [TestClass()]
    public class DefaultDealerTests
    {
        /// <summary>
        /// This method is written to add the cards to a Deck for testing purpose.
        /// </summary>
        /// <param name="suitType">Suit Type</param>
        /// <param name="cardNumber">Card number to add.</param>
        /// <returns></returns>
        public List<Card> AddCardToDeck(Enum suitType, int cardNumber)
        {
            List<Card> suitCards = new List<Card>();
            suitCards.Add(new Card(cardNumber, suitType));
            return suitCards;
        }

        /// <summary>
        /// Testcase to check the queall number of cards
        /// this will write the values in the in "Test Explorer" window under "Test Detail Summery"
        /// </summary>
        [TestMethod()]
        public void EqualValuedCardsTest_Success()
        {
            DealerInterface iDealer = new DefaultDealer();

            // declaring the List of type Card
            List<Card> cardDeck = new List<Card>();

            // Adding the card to cardDeck list array for each defined Suit
            cardDeck.AddRange(AddCardToDeck(Suit.club, 4));
            cardDeck.AddRange(AddCardToDeck(Suit.diamond, 4));

            // Shuffling the cards which are in cardDeck list array
            cardDeck = Card.ShuffleCard(cardDeck);

            // creating variable for First Player
            Player firstPlayer = new Player();
            firstPlayer.setId("one");

            // creating variable for Second Player
            Player secondPlayer = new Player();
            secondPlayer.setId("two");

            // adding players in "participants" list array
            List<Player> participants = new List<Player>();
            participants.Add(firstPlayer);
            participants.Add(secondPlayer);

            // dealing fist card from both the participants
            iDealer.dealCards(cardDeck, participants);

            while (firstPlayer.getDrawPile().Count > 0 || secondPlayer.getDrawPile().Count > 0)
            {
                DefaultDealer.PlayCards(firstPlayer, secondPlayer, iDealer);
            }
        }

        /// <summary>
        /// Passing 2 cards, each card to a player.
        /// whos card will be having the higher value/number, that player will win the round
        /// </summary>
        [TestMethod()]
        public void HigherCardWinTest_Success()
        {
            DealerInterface iDealer = new DefaultDealer();

            // declaring the List of type Card
            List<Card> cardDeck = new List<Card>();

            // Adding the card to cardDeck list array for each defined Suit
            cardDeck.AddRange(AddCardToDeck(Suit.club, 3));
            cardDeck.AddRange(AddCardToDeck(Suit.club, 8));

            // Shuffling the cards which are in cardDeck list array
            cardDeck = Card.ShuffleCard(cardDeck);

            // creating variable for First Player
            Player firstPlayer = new Player();
            firstPlayer.setId("one");

            // creating variable for Second Player
            Player secondPlayer = new Player();
            secondPlayer.setId("two");

            // adding players in "participants" list array
            List<Player> participants = new List<Player>();
            participants.Add(firstPlayer);
            participants.Add(secondPlayer);

            // dealing fist card from both the participants
            iDealer.dealCards(cardDeck, participants);
            
            DefaultDealer.PlayCards(firstPlayer, secondPlayer, iDealer);
        }

        /// <summary>
        /// if cards are same value/number from both player, then next round winner will get 4 cards in discardedPile
        /// </summary>
        [TestMethod()]
        public void SameCardValueNextRoundWinner_Success()
        {
            DealerInterface iDealer = new DefaultDealer();

            // declaring the List of type Card
            List<Card> cardDeck = new List<Card>();

            // Adding the card to cardDeck list array for each defined Suit
            cardDeck.AddRange(AddCardToDeck(Suit.diamond, 8));
            cardDeck.AddRange(AddCardToDeck(Suit.diamond, 8));
            cardDeck.AddRange(AddCardToDeck(Suit.diamond, 5));
            cardDeck.AddRange(AddCardToDeck(Suit.diamond, 6));

            // Shuffling the cards which are in cardDeck list array
            //cardDeck = Card.ShuffleCard(cardDeck);

            // creating variable for First Player
            Player firstPlayer = new Player();
            firstPlayer.setId("one");

            // creating variable for Second Player
            Player secondPlayer = new Player();
            secondPlayer.setId("two");

            // adding players in "participants" list array
            List<Player> participants = new List<Player>();
            participants.Add(firstPlayer);
            participants.Add(secondPlayer);
            
            // dealing fist card from both the participants
            iDealer.dealCards(cardDeck, participants);
            
            DefaultDealer.PlayCards(firstPlayer, secondPlayer, iDealer);
        }
    }
}