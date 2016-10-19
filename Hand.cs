using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public class Hand
    {
        private HandValue handValue = new HandValue();
        private List<Card> cards = new List<Card>();

        public Hand()
        {

        }

        public void addCard(Card card)
        {
            cards.Add(card);
            handValue.calculateHandValue(this);
        }

        public void removeCard(Card card)
        {
            cards.Remove(card);
            handValue.calculateHandValue(this);
        }

        public Boolean isWinner()
        {
            return handValue.isWinner(this);
        }
        
        public Boolean isValidWinningHand()
        {
            Boolean validWinningHand = false;

            if (countCards() == 3)
            {
                validWinningHand = true;
            }

            return validWinningHand;
        }

        public string toString()
        {
            int selection = 0;
            string handInfo = "";

            foreach (Card card in cards)
            {
                handInfo += "(" + selection + ")" + " " + card.getCardInfo() + "\n";
                selection++;
            }
            return handInfo;
        }

        public List<Card> getListOfCards()
        {
            return cards;
        }

        public void displaySuitValues()
        {
            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine("{0}: {1}", Globals.suitNames[i], handValue.suitValueFor(i));
            }
        }

        public Boolean containsCard(Card card)
        {
            return cards.Contains(card);
        }

        public int countCards()
        {
            return cards.Count;
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

        /*
        private Boolean canSuitWin(int suit)
        {
            List<int> ranks = new List<int>();

            foreach (Card card in cards)
            {
                if (card.Suit == suit)
                {
                    ranks.Add(card.Rank);
                }
            }

            int sum = 0;
            foreach (int i in ranks)
            {
                sum += i;
            }

            Boolean suitCanWin = false;
            if ((winningHandValue-sum < 13) && (!ranks.Contains(13)))
            {
                suitCanWin = true;
            }
            return suitCanWin;
        }
        */
    }
}
