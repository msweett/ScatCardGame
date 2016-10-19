using System;

namespace ScatCardGame
{
    public class Card
    {
        public Rank Rank { get; }
        public Suit Suit { get; }

        public Card(int suit, int rank)
        {
            if (!Enum.IsDefined(typeof(Suit), suit))
            {
                throw new ArgumentOutOfRangeException("Card suit is invalid, please chose a number between 0 and 3");
            }

            if (!Enum.IsDefined(typeof(Rank), rank))
            {
                throw new ArgumentOutOfRangeException("Card rank is invalid, please chose a number between 1 and 13");
            }

            Rank = (Rank)rank;
            Suit = (Suit)suit;
        }

        public override string ToString() => $"{Rank} of {Suit}";
    }
}
