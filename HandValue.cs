using System;
using System.Collections.Generic;

namespace ScatCardGame
{
    public class HandValue
    {
        private static int WINNING_HAND_VALUE = 31;
        private static int MAX_CARDS_IN_HAND = 3;
        private Dictionary<Suit, int> calculatedValue = new Dictionary<Suit, int>();

        public HandValue()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                calculatedValue.Add(suit, 0);
            }
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
                calculatedValue[card.Suit] += (int)card.Rank;
            }
        }

        public int suitValue(Suit suit)
        {
            return calculatedValue[suit];
        }

        private void clearHandValues()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                calculatedValue[suit] = 0;
            }
        }


        /*
        public int highestValuedSuit()
        {
            int highestValuedSuit = 0;

            for (int i = 0; i <= 3; i++)
            {
                if ((calculatedValue[i] > highestValuedSuit) && ())
                {
                    //highestValuedSuit = calculatedValue[i];

                }
            }

            return highestValuedSuit;
        }
        */
    }
}
