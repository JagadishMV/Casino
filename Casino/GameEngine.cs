using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Casino;

namespace Casino
{
    public class GameEngine
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n");
            Console.WriteLine("\t********** Game Started **********\n");

            // Dealer Class serves the Card dealing and filling Card Deck functionality
            DealerInterface iDealer = new DefaultDealer();

            // declaring the List of type Card
            List<Card> cardDeck = new List<Card>();

            // Adding the card to cardDeck list array for each defined Suit
            cardDeck = Card.PopulateCardsDeck(iDealer);

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

            Console.Read();
        }
    }
}
