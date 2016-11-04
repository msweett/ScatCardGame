using System;
using System.Collections.Generic;

namespace ScatCardGame
{
    public class Card
    {
        private static readonly Dictionary<Rank, int> rankToValue = new Dictionary<Rank, int>
        {
            { Rank.Ace, 11 },
            { Rank.Two, 2 },
            { Rank.Three, 3 },
            { Rank.Four, 4 },
            { Rank.Five, 5 },
            { Rank.Six, 6 },
            { Rank.Seven, 7 },
            { Rank.Eight, 8 },
            { Rank.Nine, 9 },
            { Rank.Ten, 10 },
            { Rank.Jack, 10 },
            { Rank.Queen, 10 },
            { Rank.King, 10 }
        };

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

        public int getRankValue()
        {
            return rankToValue[rank];
        }
    }
}

