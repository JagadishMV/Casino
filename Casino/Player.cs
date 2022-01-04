using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Player
    {
        private string id = "";
        private List<Card> drawPile = new List<Card>();
        private List<Card> discardPile = new List<Card>();

        public void setId(string id)
        {
            this.id = id;
        }

        /// <summary>
        /// Returns the first card of the player in stack
        /// </summary>
        /// <returns></returns>
        public Card drawCard()
        {
            Stack<Card> drawStack = new Stack<Card>();
            Card card = null;

            for (int i = 0; i < drawPile.Count; i++)
            {
                drawStack.Push(drawPile[i]);
            }

            if (drawStack.Count > 0)
            {
                card = drawStack.Pop();
                drawPile = drawStack.ToList();
            }

            return card;
        }

        /// <summary>
        /// Returns the draw pilem of the player
        /// </summary>
        /// <returns></returns>
        public List<Card> getDrawPile()
        {
            return this.drawPile;
        }

        /// <summary>
        /// Return the discard pile of the player
        /// </summary>
        /// <returns></returns>
        public List<Card> getDiscardPile()
        {
            return this.discardPile;
        }
    }
}
