using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            for (int suit = 0; suit < 4; suit++)
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
