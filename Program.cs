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
            const int NUM_OF_PLAYERS    = 2;
            const int MAX_CARDS_IN_HAND = 3;
           
            ConsoleKeyInfo userSelection;
            Boolean validInput      = false;
            Boolean isWinningHand   = false;

            DrawPile drawPile               = new DrawPile();
            CardPile discardPile            = new CardPile();
            PlayersHands playersHands       = new PlayersHands(NUM_OF_PLAYERS);

            drawPile.init();
            drawPile.shuffle();

            for (int playerIndex = 0; playerIndex < NUM_OF_PLAYERS; playerIndex++)
                for (int j = 0; j < MAX_CARDS_IN_HAND; j++)
                    playersHands.dealCard(playerIndex, drawPile.drawCard());
            
            discardPile.putCard(drawPile.drawCard());

            //start playing
            while (!isWinningHand)
            {
                for (int player = 0; player < NUM_OF_PLAYERS; player++)
                {
                    Hand playerHand = playersHands.getPlayerHand(player);
                    int playerDisplayNumber = player + 1;

                    playerHand.toString(playerDisplayNumber);

                    Console.Write("\n(d) Draw a card\t(p) pick the {0} from the discard pile", discardPile.viewTopCard().getCardInfo());
                              
                    do
                    {
                        validInput = true;
                        userSelection = Console.ReadKey();
                        
                        switch (userSelection.KeyChar)
                        {
                            case 'd':
                                playerHand.addCard(drawPile.drawCard());
                                break;
                            case 'p':
                                playerHand.addCard(discardPile.drawCard());
                                break;
                            default:
                                validInput = false;
                                Console.WriteLine("\nInvalid Selection, try again");
                                break;
                        }
                    } while (!validInput);

                    
                    playerHand.toString(playerDisplayNumber);

                    int indexOfCardToDiscard = discardCardInput();

                    Card cardToRemove = playerHand.findCard(indexOfCardToDiscard);
                    playerHand.removeCard(cardToRemove);
                    discardPile.putCard(cardToRemove);
                   

                    Console.WriteLine("\n{0} has been discarded\n", cardToRemove.getCardInfo());

                    playerHand.displaySuitValues();

                    isWinningHand = playerHand.isWinner();

                    if (isWinningHand)
                    {
                        Console.WriteLine("\nThe cake is a lie.");
                        player = NUM_OF_PLAYERS;    //so we don't go to the next turn and reset isWinningHand
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

            Console.Write("\nWhich card would you like to discard: ");

            do
            {
                userSelection = Console.ReadKey();
                inputAsInt = Convert.ToInt32(Char.GetNumericValue(userSelection.KeyChar));
            } while (inputAsInt< 0 || inputAsInt >= 4);

            return inputAsInt;
        }
    }
}
