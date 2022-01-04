using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public interface DealerInterface
    {
        /// <summary>
        /// Creates Deck of Cards with given Suit Type and Deck Size
        /// </summary>
        /// <param name="suitType">This one of the Suit Type of the Playing Cards. e.g. Spade, Club,..</param>
        /// <param name="deckSize">This is optional parameter in case deck size need to change.</param>
        List<Card> getDeck(Enum suitType, int deckSize = 10);

        /// <summary>
        /// Deals the cards among participants in round robbin fashion
        /// </summary>
        /// <param name="deck">Collection of Cards.</param>
        /// <param name="participants">Collection of Players.</param>
        /// <returns></returns>
        Boolean dealCards(List<Card> deck, List<Player> participants);

        Stack playedCard
        {
            get;
            set;
        }
    }
}
