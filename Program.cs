using System;
using System.Collections.Generic;

namespace ScatCardGame
{
    public static class Globals
    {
        public static List<String> suitNames = new List<String> { "Hearts", "Diamonds", "Clubs", "Spades" };
    }

    class Program
    {
        static void Main(string[] args)
        {   
            const int NUM_OF_PLAYERS = 2;
            const int MAX_CARDS_IN_HAND = 3;
            const int NUM_OF_AI = 0;
            
            Boolean isGameOver   = false;

            DrawPile drawPile       = new DrawPile();
            CardPile discardPile    = new CardPile();
            Players players         = new Players(NUM_OF_PLAYERS, NUM_OF_AI);

            drawPile.init();
            drawPile.shuffle();

            for (int playerIndex = 0; playerIndex < NUM_OF_PLAYERS; playerIndex++)
                for (int j = 0; j < MAX_CARDS_IN_HAND; j++)
                    players.dealCard(playerIndex, drawPile.drawCard());
            
            discardPile.putCard(drawPile.drawCard());

            //start playing!
            while (!isGameOver)
            {
                for (int playerIndex = 0; playerIndex < NUM_OF_PLAYERS; playerIndex++)
                {
                    Player player = players.getPlayer(playerIndex);
                    Hand playerHand = player.getPlayerHand();
                    int playerDisplayNumber = playerIndex + 1;

                    displayPlayerHand(playerDisplayNumber, playerHand);

                    Console.Write("\n(d) Draw a card\t(p) pick the {0} from the discard pile", discardPile.viewTopCard().getCardInfo());

                    char cardPileToDrawFrom = drawCardInput();
                    drawCard(cardPileToDrawFrom, ref player, ref discardPile, ref drawPile);

                    displayPlayerHand(playerDisplayNumber, playerHand);

                    Console.Write("Which card would you like to discard: ");

                    int indexOfCardToDiscard = discardCardInput();
                    discarCardFromHand(indexOfCardToDiscard, ref playerHand, ref discardPile);

                    displayPlayerHand(playerDisplayNumber, playerHand);
                    playerHand.displaySuitValues();

                    isGameOver = playerHand.isWinner();

                    if (isGameOver)
                    {
                        Console.WriteLine("\nThe cake is a lie.");
                        playerIndex = NUM_OF_PLAYERS;    //so we don't go to the next turn and reset isWinningHand
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

        public static int discardCardInput()
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

        public static char drawCardInput()
        {
            char userSelection;

            do
            {
                userSelection = Console.ReadKey().KeyChar;
            } while (userSelection != 'd' && userSelection != 'p');

            return userSelection;
        }

        public static void drawCard(char cardPileToDrawFrom, ref Player player, ref CardPile cardPile, ref DrawPile drawPile)
        {
            if (cardPileToDrawFrom == 'd')
            {
                player.getPlayerHand().addCard(drawPile.drawCard());
            }
            else if (cardPileToDrawFrom == 'p')
            {
                player.getPlayerHand().addCard(cardPile.drawCard());
            }
        }

        public static void discarCardFromHand(int indexOfCard, ref Hand hand, ref CardPile discardPile)
        {
            Card cardToDiscard = hand.getListOfCards()[indexOfCard];

            hand.removeCard(cardToDiscard);
            discardPile.putCard(cardToDiscard);

            Console.WriteLine("\n{0} has been discarded\n", cardToDiscard.getCardInfo());
        }

        public static void printHeaderMessage(int playerDisplayNumber)
        {
            Console.Clear();
            Console.WriteLine("Player {0} turn", playerDisplayNumber);
            Console.WriteLine("Your cards are: \n");
        }

        public static void displayPlayerHand(int displayNumber, Hand playerHand)
        {
            printHeaderMessage(displayNumber);
            Console.WriteLine(playerHand.toString());
        }
    }
}
