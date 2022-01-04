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
    public class CardTests
    {
        /// <summary>
        /// Successful testcase for checking deck size of 40 card.
        /// </summary>
        [TestMethod()]
        public void DeckSize_40_Test_Success()
        {
            DealerInterface iDealer = new DefaultDealer();
            int deckSize = 10;
            List<Card> deck = new List<Card>();
            deck = Card.PopulateCardsDeck(iDealer, deckSize);
            
            Assert.AreEqual(40, deck.Count());

            if (deck.Count == 40)
            {
                Console.WriteLine("Pass!! Deck contains " + deck.Count.ToString() + " cards");
                for (int i = 0; i < deck.Count; i++)
                {
                    Console.WriteLine("Normal Deck \t" + deck[i].getSuit() + "(" + deck[i].getValue().ToString() + ")");
                    Console.WriteLine("------------------------------");
                }
            }
        }
        
        /// <summary>
        /// This test case is used to test the fail scenario of deck size 40
        /// deckSize => by changing the variable value in the below testcase can test the deck Size.
        /// </summary>
        [TestMethod()]
        public void DeckSize_40_Test_Fail()
        {
            DealerInterface iDealer = new DefaultDealer();
            
            // change the deck size to test it
            int deckSize = 2;

            List<Card> deck = new List<Card>();
            deck = Card.PopulateCardsDeck(iDealer, deckSize);

            Assert.AreEqual(40, deck.Count());

            if (deck.Count == 40)
            {
                Console.WriteLine("Pass!! Deck contains 40 cards.");
            }
            else
            {
                Console.WriteLine("Fail!! Deck is having the " + deck.Count.ToString() + " cards only.");
            }
        }

        /// <summary>
        /// In the shuffle function cannot be tested for expected values, as the function will return different values in every run
        /// Just to cross check, checking the top 1 record from both the list are matching. if not matching, then success.
        /// Hence just displaying the before shuffle and after shuffled card details form Decks.
        /// Just to cross check, run this Shuffle testcase multiple times and compare the values.
        /// In multiple runs, should not get the same order of cards with suit.
        /// </summary>
        [TestMethod()]
        public void ShuffleCardTest_Success()
        {
            DealerInterface iDealer = new DefaultDealer();
            int deckSize = 10;
            List<Card> deck = new List<Card>();
            deck = Card.PopulateCardsDeck(iDealer, deckSize);

            List<Card> shuffledDeck = new List<Card>();

            shuffledDeck = Card.ShuffleCard(deck);
            int intDeckIndex = 0;
            while (deck.Count > intDeckIndex)
            {
                intDeckIndex++;

                if (deck[intDeckIndex].getValue() != shuffledDeck[intDeckIndex].getValue()
                    ||
                    deck[intDeckIndex].getSuit() != shuffledDeck[intDeckIndex].getSuit()
                    )
                {
                    Console.WriteLine("\nPass.\n");
                    break;
                }
            }

            intDeckIndex = 0;
            for (int i = 0; i < deck.Count; i++)
            {
                Console.WriteLine("Normal Deck \t" + deck[i].getSuit() + "(" + deck[i].getValue().ToString() + ")");
                Console.WriteLine("Shuffled Deck \t" + shuffledDeck[i].getSuit() + "(" + shuffledDeck[i].getValue().ToString() + ")");

                Console.WriteLine("------------------------------");
            }
        }
    }
}