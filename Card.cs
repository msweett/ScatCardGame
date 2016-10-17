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

        public Card(int newSuit, int newRank)
        {
            if (newSuit > 3 || newSuit < 0)
            {
                throw new System.ArgumentOutOfRangeException("Card suit is invalid, please chose a number between 0 and 3");
            }
            else
            {
                Suit = newSuit;
            }

            if (newRank > 13 || newRank < 1)
            {
                throw new System.ArgumentOutOfRangeException("Card rank is invalid, please chose a number between 1 and 13");
            }
            else
            {
                Rank = newRank;
            } 
        }

        public int Rank
        {
            get{ return rank; }
            set{ rank = value; }
        }

        public int Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        public string getCardInfo()
        {
            return String.Format("{0} of {1}", rank, Globals.suitNames[suit]);
        }
    }
}
