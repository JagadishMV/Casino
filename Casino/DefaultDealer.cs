using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class DefaultDealer : DealerInterface
    {
        /// <summary>
        /// 
        /// </summary>
        public Stack PlayedCard = new Stack();

        public Stack playedCard
        {
            get
            {
                return PlayedCard;
            }
            set
            {
                PlayedCard = value;
            }
        }

        /// <summary>
        /// Creates Deck of Cards with given Suit Type and Deck Size
        /// </summary>
        /// <param name="suitType">This one of the Suit Type of the Playing Cards. e.g. Spade, Club,..</param>
        /// <param name="deckSize">This is optional parameter in case deck size need to change.</param>
        public List<Card> getDeck(Enum suitType, int deckSize = 10)
        {
            List<Card> suitCards = new List<Card>(deckSize);
            for (int i = 1; i <= deckSize; i++)
            {
                suitCards.Add(new Card(i, suitType));
            }

            return suitCards;
        }

        /// <summary>
        /// Deals the cards among participants in round robbin fashion
        /// </summary>
        /// <param name="deck">Collection of Cards.</param>
        /// <param name="participants">Collection of Players.</param>
        /// <returns>Return the boolean value.</returns>
        public Boolean dealCards(List<Card> deck, List<Player> participants)
        {
            Stack<Card> stack = new Stack<Card>();
            for (int i = 0; i < deck.Count; i++)
            {
                stack.Push(deck[i]);
            }

            while (stack.Count != 0)
            {
                foreach (Player player in participants)
                {
                    if (stack.Count != 0)
                    {
                        Card card = stack.Pop();
                        player.getDrawPile().Add(card);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Loop through the cards in Draw Pile and Discard Pile until a player win
        /// </summary>
        /// <param name="firstPlayer">First Player</param>
        /// <param name="secondPlayer">Second Player</param>
        /// <param name="iDealer">Dealer Interface contains with the deatils of deal</param>
        public static void PlayCards(Player firstPlayer, Player secondPlayer, DealerInterface iDealer)
        {
            // declared a local variable of type int just to hold and display the number of itterations occured accross the game
            int intRounds = 0;

            /* 
             *  Loop till a player become zero in drawPile and getDiscardPile once drawPile become zero, 
             *  the reshuffle the getDiscardPile and shift those cards to drawPile.
             *  
             *  Below while loop is written to check each player should have atleast 1 card in draw pile or discarded pile,
             *  who loses all the cards from draw pile and discarded file, that player loses the game.
            */
            while ((firstPlayer.getDrawPile().Count > 0 || firstPlayer.getDiscardPile().Count > 0)
                && (secondPlayer.getDrawPile().Count > 0 || secondPlayer.getDiscardPile().Count > 0))
            {
                intRounds++;

                /*
                 * Condition to check if the 1st player draw piles are over and has piles in discarded pile,
                 * then add the collection of discarded pile to Draw pile
                */
                if (firstPlayer.getDrawPile().Count == 0 && firstPlayer.getDiscardPile().Count > 0)
                {
                    Console.WriteLine("\t=====> Player 1 Cards are over. Shifting Discarded piles to Draw Piles by re-shuffling.\n");

                    firstPlayer.getDrawPile().AddRange(Card.ShuffleCard(firstPlayer.getDiscardPile()));

                    firstPlayer.getDiscardPile().Clear();
                }

                /*  
                 *  Condition to check if the 2nd player draw piles are over and has piles in discarded pile,
                 *  then add the collection of discarded pile to Draw pile.
                */
                if (secondPlayer.getDrawPile().Count == 0 && secondPlayer.getDiscardPile().Count > 0)
                {
                    Console.WriteLine("\t=====> Player 2 Cards are over. Shifting Discarded piles to Draw Piles by re-shuffling.\n");

                    secondPlayer.getDrawPile().AddRange(Card.ShuffleCard(secondPlayer.getDiscardPile()));
                    secondPlayer.getDiscardPile().Clear();
                }

                // send the players and dealer object variable to play the game
                DefaultDealer.CardShow(firstPlayer, secondPlayer, iDealer);

                Console.WriteLine("\tPlayer 1 [ Draw Pile => " + firstPlayer.getDrawPile().Count.ToString() + ", Discard Pile => " + firstPlayer.getDiscardPile().Count.ToString() + " cards ]");
                Console.WriteLine("\tPlayer 2 [ Draw Pile => " + secondPlayer.getDrawPile().Count.ToString() + ", Discard Pile => " + secondPlayer.getDiscardPile().Count.ToString() + " cards ]");
                Console.WriteLine("\n\t--------------------------------------------- " + intRounds + " Round Completed ---------------------------------------------\n");
            }

            if (firstPlayer.getDrawPile().Count == 0 && firstPlayer.getDiscardPile().Count == 0)
            {
                Console.WriteLine("\n\t****************************************************************");
                Console.WriteLine("\n\tPlayer - 2 is winner!!");
                Console.WriteLine("\n\t****************************************************************");
            }
            else
            {
                Console.WriteLine("\n\t****************************************************************");
                Console.WriteLine("\n\tPlayer - 1 is winner!!");
                Console.WriteLine("\n\t****************************************************************");
            }
        }

        /// <summary>
        /// CardShow - Announce the winner, collects the discard pile with respect to each player 
        /// and holds and allocation same value cards in previous round,  
        /// </summary>
        /// <param name="one">First Player</param>
        /// <param name="two">Second Player</param>
        /// <param name="dealer">Dealer Interface contains with the deatils of deal</param>
        public static void CardShow(Player one, Player two, DealerInterface dealer)
        {
            Card card_Player_One = one.drawCard();
            Card card_Player_Two = two.drawCard();
            
            if (card_Player_One.getValue() == card_Player_Two.getValue())
            {
                dealer.playedCard.Push(card_Player_One);
                dealer.playedCard.Push(card_Player_Two);

                Console.WriteLine("\tPlayer 1 (" + (one.getDrawPile().Count + one.getDiscardPile().Count + 1).ToString() + " cards) : " + card_Player_One.getValue().ToString());
                Console.WriteLine("\tPlayer 2 (" + (two.getDrawPile().Count + two.getDiscardPile().Count + 1).ToString() + " cards) : " + card_Player_Two.getValue().ToString());
                Console.WriteLine("\tNo winner in this round");
            }
            else if (card_Player_One.getValue() > card_Player_Two.getValue())
            {
                Console.WriteLine("\tPlayer 1 (" + (one.getDrawPile().Count + one.getDiscardPile().Count + 1).ToString() + " cards) : " + card_Player_One.getValue().ToString());
                Console.WriteLine("\tPlayer 2 (" + (two.getDrawPile().Count + two.getDiscardPile().Count + 1).ToString() + " cards) : " + card_Player_Two.getValue().ToString());

                one.getDiscardPile().Add(card_Player_One);
                one.getDiscardPile().Add(card_Player_Two);

                if (dealer.playedCard.Count > 0)
                {
                    // loop though the clash cards
                    while (dealer.playedCard.Count > 0)
                    {
                        one.getDiscardPile().Add((Casino.Card)dealer.playedCard.Pop());
                        one.getDiscardPile().Add((Casino.Card)dealer.playedCard.Pop());
                    }
                }
                Console.WriteLine("\tPlayer 1 wins this round");
            }
            else
            {
                Console.WriteLine("\tPlayer 1 (" + (one.getDrawPile().Count + one.getDiscardPile().Count + 1).ToString() + " cards) : " + card_Player_One.getValue().ToString());
                Console.WriteLine("\tPlayer 2 (" + (two.getDrawPile().Count + two.getDiscardPile().Count + 1).ToString() + " cards) : " + card_Player_Two.getValue().ToString());

                two.getDiscardPile().Add(card_Player_One);
                two.getDiscardPile().Add(card_Player_Two);

                if (dealer.playedCard.Count > 0)
                {
                    // loop though the clash cards
                    while (dealer.playedCard.Count > 0)
                    {
                        two.getDiscardPile().Add((Casino.Card)dealer.playedCard.Pop());
                        two.getDiscardPile().Add((Casino.Card)dealer.playedCard.Pop());
                    }
                }
                Console.WriteLine("\tPlayer 2 wins this round");
            }

            Console.WriteLine("\n");
        }
    }
}
