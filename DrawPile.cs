using System;
using System.Linq;
using System.Collections.Generic;

namespace ScatCardGame
{
    public class DrawPile : CardPile
    {
        public DrawPile()
        {
           
        }

        public void init()
        {
            clearCardPile();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Card c = new Card(suit, rank);
                    putCard(c);
                }
            }
        }

        public void shuffle()
        {
            Random rnd = new Random();
            var values = cardPile.ToArray();
            clearCardPile();

            foreach (var value in values.OrderBy(x => rnd.Next()))
                putCard(value);
        }
    }
}
