using System;

namespace ScatCardGame
{
    public class Card
    {
        public Rank rank { get; }
        public Suit suit { get; }

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public string getCardInfo()
        {
            return $"{rank} of {suit}";
        }
    }
}

