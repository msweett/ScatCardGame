using System;
using System.Linq;

namespace ScatCardGame
{
    public class DrawPile : CardPile
    {
        public DrawPile()
        {
            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = 1; rank <= 13; rank++)
                {
                    Card c = new Card(suit, rank);
                    PutCard(c);
                }
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            Card[] values = cardPile.ToArray();
            cardPile.Clear();

            foreach (Card value in values.OrderBy(x => rnd.Next()))
            {
                PutCard(value);
            }
        }
    }
}
