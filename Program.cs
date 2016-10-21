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
            Players players         = new Players(Globals.NUM_OF_PLAYERS, Globals.NUM_OF_AI);

            drawPile.init();
            drawPile.shuffle();

            for (int playerIndex = 0; playerIndex < Globals.NUM_OF_PLAYERS; playerIndex++)
                for (int j = 0; j < Globals.MAX_CARDS_IN_HAND; j++)
                    players.dealCard(playerIndex, drawPile.drawCard());
            
            discardPile.putCard(drawPile.drawCard());

            //start playing!
            Boolean isGameOver = false;
            while (!isGameOver)
            {
                for (int playerIndex = 0; playerIndex < Globals.NUM_OF_PLAYERS; playerIndex++)
                {
                    Player player = players.getPlayer(playerIndex);
                    
                    int playerDisplayNumber = playerIndex + 1;

                    displayPlayerHand(playerDisplayNumber, player);

                    Console.Write("\n(d) Draw a card\t(p) pick the {0} from the discard pile", discardPile.viewTopCard().getCardInfo());

                    char cardPileToDrawFrom = cardPileToDrawFromInput();

                    if (cardPileToDrawFrom == 'd')
                    {
                        player.addCard(drawPile.drawCard());
                    }
                    else if (cardPileToDrawFrom == 'p')
                    {
                        player.addCard(discardPile.drawCard());
                    }

                    displayPlayerHand(playerDisplayNumber, player);

                    Console.Write("Which card would you like to discard: ");

                    int indexOfCardToDiscard = cardToDiscardInput();
                    discarCardFromHand(indexOfCardToDiscard, ref player, ref discardPile);

                    displayPlayerHand(playerDisplayNumber, player);
                    Console.WriteLine(player.suitValuesToString());

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

        public static int cardToDiscardInput()
        {        
            int inputAsInt;
            ConsoleKeyInfo userSelection;

            do
            {
                userSelection = Console.ReadKey();
                inputAsInt = Convert.ToInt32(Char.GetNumericValue(userSelection.KeyChar));
            } while (inputAsInt< 0 || inputAsInt >= 4);

            return inputAsInt;
        }

        public static char cardPileToDrawFromInput()
        {
            char userSelection;

            do
            {
                userSelection = Console.ReadKey().KeyChar;
            } while (userSelection != 'd' && userSelection != 'p');

            return userSelection;
        }

        public static void discarCardFromHand(int indexOfCard, ref Player player, ref CardPile discardPile)
        {
            Card cardToDiscard = player.getCard(indexOfCard);
            player.removeCard(cardToDiscard);
            discardPile.putCard(cardToDiscard);
        }

        public static void displayPlayerHand(int displayNumber, Player player)
        {
            Console.Clear();
            Console.WriteLine("Player {0} turn", displayNumber);
            Console.WriteLine("Your cards are: \n");
            Console.WriteLine(player.cardsToString());
        }
    }
}
