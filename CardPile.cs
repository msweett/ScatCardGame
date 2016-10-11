using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    class CardPile
    {
        public Stack<Card> cardPile = new Stack<Card>();

        public CardPile()
        {
            
        }

        public Card drawCard()
        {
            return cardPile.Pop();
        }

        public void putCard(Card card)
        {
            cardPile.Push(card);
        }

        public Card viewTopCard()
        {
            return cardPile.Peek();
        }
    }
}
