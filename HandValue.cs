using System;
using System.Collections.Generic;

namespace ScatCardGame
{
    public class HandValue
    {
        private static int WINNING_HAND_VALUE = 31;
        private static int MAX_CARDS_IN_HAND = 3;
        private Dictionary<Suit, int> calculatedValue = new Dictionary<Suit, int>();

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
        
        public HandValue()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                calculatedValue.Add(suit, 0);
            }
        }

        public int getRankValue(Rank rank)
        {
            return rankToValue[rank];
        }

        public Boolean isWinner(List<Card> cards)
        {
            Boolean isWinner = false;

            if (cards.Count == MAX_CARDS_IN_HAND)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    if (calculatedValue[suit] == WINNING_HAND_VALUE)
                    {
                        isWinner = true;
                    }
                }
            }
            return isWinner;
        }

        public void calculateValue(List<Card> cards)
        {
            clearHandValues();

            foreach (Card card in cards)
            {
                calculatedValue[card.suit] += rankToValue[card.rank];
            }
        }

        public int suitValue(Suit suit)
        {
            return calculatedValue[suit];
        }

        public int getWinningHandValue()
        {
            return WINNING_HAND_VALUE;
        }

        private void clearHandValues()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                calculatedValue[suit] = 0;
            }
        }
    }
}
