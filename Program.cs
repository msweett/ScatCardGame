using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ScatCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_CARDS_IN_HAND = 3;
            const int NUM_OF_PLAYERS    = 2;

            DrawPile drawPile               = new DrawPile();
            CardPile discardPile            = new CardPile();
            Collection<Hand> playersHands   = new Collection<Hand>();

            drawPile.init();
            drawPile.shuffle();

            //deal cards
            for (int player = 0; player < NUM_OF_PLAYERS; player++)
            {
                playersHands.Add(new Hand());
                playersHands[player].handInit();

                for (int i = 0; i < MAX_CARDS_IN_HAND; i++) 
                    playersHands[player].addCard(drawPile.drawCard());
                                
            }

            foreach (Hand playerHand in playersHands)
            {
                Console.WriteLine("Players Cards: ");
                foreach (Card card in playerHand.cards)
                {
                    Console.WriteLine(card.getCardInfo());
                }
            }

            Console.ReadLine();
        }    
    }
}
