using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public class Hand
    {
        public Dictionary<Suit, int> CalculatedValue = new Dictionary<Suit, int>();
        public List<Card> Cards = new List<Card>();

        private int WinningHandValue = 31;

        public Hand()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                CalculatedValue.Add(suit, 0);
            }
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
            CalculatedValue[card.Suit] += (int)card.Rank;
        }

        public void RemoveCard(Card card)
        {
            Cards.Remove(card);
            CalculatedValue[card.Suit] -= (int)card.Rank;
        }

        public bool IsWinner() => CalculatedValue.Any(keyValuePair => keyValuePair.Value == WinningHandValue);
    }
}
