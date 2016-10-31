using System;
using System.Collections.Generic;

namespace ScatCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NUM_OF_PLAYERS = Globals.NUM_OF_AI + Globals.NUM_OF_HUMAN_PLAYERS;

            DrawPile drawPile       = new DrawPile();
            CardPile discardPile    = new CardPile();
            List<Player> players    = new List<Player>();
            
            drawPile.init();
            drawPile.shuffle();

            initPlayers(ref players);
            dealCards(ref players, ref drawPile, NUM_OF_PLAYERS);
            
            discardPile.putCard(drawPile.drawCard());

            //start playing!
            Boolean isGameOver = false;
            while (!isGameOver)
            {
                for (int playerIndex = 0; playerIndex < NUM_OF_PLAYERS; playerIndex++)
                {
                    Player player = players[playerIndex];

                    player.playTurn(ref drawPile, ref discardPile);
                    isGameOver = player.hasWinningHand();

                    if (isGameOver)
                    {
                        Console.WriteLine("\nThe cake is a lie.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nPress any key to end your turn");                    
                    }

                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public static void initPlayers(ref List<Player> players)
        {
            int playerIndex = 1;
            for (int player = 0; player < Globals.NUM_OF_HUMAN_PLAYERS; player++)
            {
                players.Add(new HumanPlayer(playerIndex));
                playerIndex++;
            }

            for (int AI = 0; AI < Globals.NUM_OF_AI; AI++)
            {
                players.Add(new AutomatedPlayer(playerIndex));
                playerIndex++;
            }
        }

        public static void dealCards(ref List<Player> players, ref DrawPile drawPile, int NUM_OF_PLAYERS)
        {
            for (int playerIndex = 0; playerIndex < NUM_OF_PLAYERS; playerIndex++)
            {
                for (int j = 0; j < Globals.MAX_CARDS_IN_HAND; j++)
                {
                    players[playerIndex].addCard(drawPile.drawCard());
                }
            }
        }
    }
}
