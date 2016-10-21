﻿using System;
using System.Collections.Generic;

namespace ScatCardGame
{
    public class HandValue
    {
        private static int WINNING_HAND_VALUE = 31;
        private static int MAX_CARDS_IN_HAND = 3;
        private Dictionary<int, int> calculatedValue = new Dictionary<int, int>();

        public HandValue()
        {
            calculatedValue.Add(0, 0);   //hearts
            calculatedValue.Add(1, 0);   //diamonds
            calculatedValue.Add(2, 0);   //clubs
            calculatedValue.Add(3, 0);   //spades
        }

        public Boolean isWinner(List<Card> cards)
        {
            Boolean isWinner = false;

            if (cards.Count == MAX_CARDS_IN_HAND)
            {
                for (int suit = 0; suit <= 3; suit++)
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
                calculatedValue[(int)card.Suit] += (int)card.Rank;
            }
        }

        public int suitValue(int suitIndex)
        {
            return calculatedValue[suitIndex];
        }

        private void clearHandValues()
        {
            calculatedValue[0] = 0;
            calculatedValue[1] = 0;
            calculatedValue[2] = 0;
            calculatedValue[3] = 0;
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
