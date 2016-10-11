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

            if (rank > 12 || rank < 0)
            {
                throw new System.ArgumentOutOfRangeException("Card rank is invalid, please chose a number between 0 and 12");
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
            string cardInfo = String.Format("{0} of {1}", rank, suit);
            return cardInfo;
        }

    }
}
