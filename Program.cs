using System;
using System.Collections.Generic;

namespace ScatCardGame
{
    class Program
    {
        static void Main(string[] args)
        {   
            DrawPile drawPile       = new DrawPile();
            CardPile discardPile    = new CardPile();
            List<Player> players    = new List<Player>();

            drawPile.init();
            drawPile.shuffle();

            playersInit(ref players);
            dealCards(ref players, ref drawPile);
            
            discardPile.putCard(drawPile.drawCard());

            //start playing!
            Boolean isGameOver = false;
            while (!isGameOver)
            {
                for (int playerIndex = 0; playerIndex < Globals.NUM_OF_PLAYERS; playerIndex++)
                {
                    int playerDisplayNumber = playerIndex + 1;
                    Player player = players[playerIndex];

                    displayHeader(playerDisplayNumber);
                    player.playDrawCardTurn(ref drawPile, ref discardPile);

                    displayHeader(playerDisplayNumber);
                    player.playDiscardCardTurn(ref discardPile);

                    isGameOver = player.isWinningHand();

                    if (isGameOver)
                    {
                        Console.WriteLine("\nThe cake is a lie.");
                        playerIndex = Globals.NUM_OF_PLAYERS;    //so we don't go to the next turn and reset isWinningHand
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

        public static void displayHeader(int displayNumber)
        {
            Console.Clear();
            Console.WriteLine("Player {0} turn", displayNumber);
            Console.WriteLine("Your cards are: \n");
        }

        public static void playersInit(ref List<Player> players)
        {
            for (int player = 0; player < Globals.NUM_OF_PLAYERS; player++)
            {
                players.Add(new HumanPlayer());
            }

            for (int AI = 0; AI < Globals.NUM_OF_AI; AI++)
            {
                players.Add(new AutomatedPlayer());
            }
        }

        public static void dealCards(ref List<Player> players, ref DrawPile drawPile )
        {
            for (int playerIndex = 0; playerIndex < Globals.NUM_OF_PLAYERS; playerIndex++)
                for (int j = 0; j < Globals.MAX_CARDS_IN_HAND; j++)
                    players[playerIndex].addCard(drawPile.drawCard());
        }
    }
}
