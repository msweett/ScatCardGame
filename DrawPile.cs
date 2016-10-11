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

        public void drawPileInit()
        {
            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = 0; rank < 13; rank++)
                {
                    Card c = new Card(suit, rank);
                    cardPile.Push(c);
                }
            }
        }

        public void shuffle()
        {
            Random rnd = new Random();
            var values = cardPile.ToArray();
            cardPile.Clear();

            foreach (var value in values.OrderBy(x => rnd.Next()))
                cardPile.Push(value);
        }
    }
}
