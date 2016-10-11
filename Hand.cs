using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public class Hand
    {
        public Dictionary<int, int> calculatedValue = new Dictionary<int, int>();
        public HashSet<Card> cards = new HashSet<Card>();
        public int winningHandValue = 31;

        public Hand()
        {
       
        }

        public void addCard(Card card)
        {
            cards.Add(card);
            calculatedValue[card.getSuit()] += card.getRank();
        }

        public void removeCard(Card card)
        {
            cards.Remove(card);
            calculatedValue[card.getSuit()] -= card.getRank();
        }

        public void handInit()
        {
            calculatedValue.Add(0, 0);   //hearts
            calculatedValue.Add(1, 0);   //diamonds
            calculatedValue.Add(2, 0);   //clubs
            calculatedValue.Add(3, 0);   //spades
        }

        public Boolean isWinner()
        {
            Boolean isWinner = false;

            for (int suit = 0; suit < 3; suit++)
            {
                if (calculatedValue[suit] == winningHandValue)
                {
                    isWinner = true;
                }
            }

            return isWinner;
        }
    }
}
