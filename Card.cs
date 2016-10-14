using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public class Card
    {
        private int rank;
        private int suit;

        public Card(int suit, int rank)
        {
            if (suit > 3 || suit < 0)
            {
                throw new System.ArgumentOutOfRangeException("Card suit is invalid, please chose a number between 0 and 3");
            }
            else
            {
                this.suit = suit;
            }

            if (rank > 13 || rank < 1)
            {
                throw new System.ArgumentOutOfRangeException("Card rank is invalid, please chose a number between 1 and 13");
            }
            else
            {
                this.rank = rank;
            } 
        }

        public int getRank()
        {
            return rank;
        }

        public int getSuit()
        {
            return suit;
        }

        public string getCardInfo()
        {
            string suitName;

            switch (suit)
            {
                case 0: suitName = "Hearts"; break;
                case 1: suitName = "Diamonds"; break;
                case 2: suitName = "Clubs"; break;
                case 3: suitName = "Spades"; break;
                default:suitName = "Error"; break;
            }

            string cardInfo = String.Format("{0} of {1}", rank, suitName);
            return cardInfo;
        }
    }
}
