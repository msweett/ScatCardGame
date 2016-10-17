using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public class Hand
    {
        private Dictionary<int, int> calculatedValue = new Dictionary<int, int>();
        private List<Card> cards = new List<Card>();
        private int winningHandValue = 31;

        public Hand()
        {
            calculatedValue.Add(0, 0);   //hearts
            calculatedValue.Add(1, 0);   //diamonds
            calculatedValue.Add(2, 0);   //clubs
            calculatedValue.Add(3, 0);   //spades
        }

        public void addCard(Card card)
        {
            cards.Add(card);
            calculatedValue[card.Suit] += card.Rank;
        }

        public void removeCard(Card card)
        {
            cards.Remove(card);
            calculatedValue[card.Suit] -= card.Rank;
        }

        public Boolean isWinner()
        {
            Boolean isWinner = false;

            for (int suit = 0; suit <= 3; suit++)
            {
                if (calculatedValue[suit] == winningHandValue)
                {
                    isWinner = true;
                }
            }

            return isWinner;
        }

        public void toString(int playerIndex)
        {
            int selection = 0;

            Console.Clear();
            Console.WriteLine("Player {0} turn", playerIndex);
            Console.WriteLine("Your cards are: \n");

            foreach (Card card in cards)
            {
                Console.WriteLine("({0}) {1}", selection, card.getCardInfo());
                selection++;
            }
        }

        public Card findCard(int indexOfCard)
        {
            return cards[indexOfCard];
        }

        public void displaySuitValues()
        {
            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine("{0}: {1}", Globals.suitNames[i], calculatedValue[i]);
            }
        }

        public int suitValueFor(int index)
        {
            return calculatedValue[index];
        }

        public Boolean containsCard(Card card)
        {
            return cards.Contains(card);
        }

    }
}
