using System;
using System.Collections.Generic;

namespace ScatCardGame
{
    public class CardPile
    {
        protected Stack<Card> cardPile = new Stack<Card>();

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

        public Boolean containsCard(Card card)
        {
            return cardPile.Contains(card);
        }

        protected void clearCardPile()
        {
            cardPile.Clear();
        }
    }
}
