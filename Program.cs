using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            DrawPile drawPile = new DrawPile();
            CardPile discardPile = new CardPile();

            Console.WriteLine("The first card on the draw pile is: {0}", drawPile.viewTopCard().getCardInfo());
            discardPile.putCard(drawPile.drawCard());
            Console.WriteLine("The first card on the draw pile is: {0}", drawPile.viewTopCard().getCardInfo());
            Console.WriteLine("The first card on the discard pile is: {0}", discardPile.viewTopCard().getCardInfo());
            Console.ReadLine();
            */

            int hearts = 0;
            int diamonds = 1;

            Card firstCard = new Card(hearts, 6);
            Card secondCard = new Card(diamonds, 9);
            Card thirdCard = new Card(hearts, 8);

            Hand hand = new Hand();

            hand.handInit();
            hand.addCard(firstCard);
            hand.addCard(secondCard);
            hand.addCard(thirdCard);

            Console.ReadLine();
        }
    }
}
