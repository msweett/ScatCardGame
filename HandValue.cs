using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public class HandValue
    {
        private static int WINNING_HAND_VALUE = 31;
        private Dictionary<int, int> calculatedValue = new Dictionary<int, int>();

        public HandValue()
        {
            calculatedValue.Add(0, 0);   //hearts
            calculatedValue.Add(1, 0);   //diamonds
            calculatedValue.Add(2, 0);   //clubs
            calculatedValue.Add(3, 0);   //spades
        }

        public Boolean isWinner(Hand hand)
        {
            Boolean isWinner = false;

            if (hand.isValidWinningHand())
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

        public void calculateHandValue(Hand hand)
        {
            List<Card> cards = hand.getListOfCards();
            clearHandValues();

            foreach (Card card in cards)
            {
                calculatedValue[card.Suit] += card.Rank;
            }
        }

        public int suitValueFor(int suitIndex)
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
