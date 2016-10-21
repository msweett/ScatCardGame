using System;
using System.Linq;

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

            for (int suit = (int)Suit.Hearts; suit < 4; suit++)
            {
                for (int rank = 1; rank <= 13; rank++)
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
