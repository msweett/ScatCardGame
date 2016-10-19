using System.Collections.Generic;

namespace ScatCardGame
{
    public class CardPile
    {
        protected readonly Stack<Card> cardPile = new Stack<Card>();
        public Card DrawCard() => cardPile.Pop();
        public void PutCard(Card card) => cardPile.Push(card);
        public Card ViewTopCard() => cardPile.Peek();
        public void Clear() => cardPile.Clear();
    }
}
