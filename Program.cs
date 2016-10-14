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
            
            const int NUM_OF_PLAYERS    = 2;
            const int MAX_CARDS_IN_HAND = 3;
           
            ConsoleKeyInfo userSelection;
            Boolean validInput      = false;
            Boolean isWinningHand   = false;

            DrawPile drawPile               = new DrawPile();
            CardPile discardPile            = new CardPile();
            PlayersHands playersHands       = new PlayersHands(NUM_OF_PLAYERS, MAX_CARDS_IN_HAND);

            drawPile.init();
            drawPile.shuffle();
            playersHands.init();

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
                    
                    displayCardsInHand(playerHand, playerDisplayNumber);

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
                                Console.WriteLine("Invalid Selection, try again");
                                break;
                        }
                    } while (!validInput);

                    
                    displayCardsInHand(playerHand, playerDisplayNumber);

                    int indexOfCardToDiscard = discardCardInput();

                    Card cardToRemove = playerHand.cards[indexOfCardToDiscard];
                    discardPile.putCard(cardToRemove);
                    playerHand.removeCard(cardToRemove);

                    Console.WriteLine("\n{0} has been discarded\n", cardToRemove.getCardInfo());

                    displaySuitStatus(playerHand);

                    isWinningHand = playerHand.isWinner();

                    if (isWinningHand)
                    {
                        Console.WriteLine("\nThe cake is a lie.");
                        player = NUM_OF_PLAYERS;    //so we don't go to the next turn and clear isWinningHand
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

        public static void displayCardsInHand(Hand playersHand, int player)
        {
            int selection = 0;

            Console.Clear();
            Console.WriteLine("Player {0} turn", player);
            Console.WriteLine("Your cards are: \n");

            foreach (Card card in playersHand.cards)
            {
                Console.WriteLine("({0}) {1}",selection, card.getCardInfo());
                selection++;
            }
        }

        public static List<String> suitMapInit()
        {
            List<String> suitMap = new List<String>();

            suitMap.Add("Hearts");
            suitMap.Add("Diamonds");
            suitMap.Add("Clubs");
            suitMap.Add("Spades");

            return suitMap;
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

        public static void displaySuitStatus(Hand playerHand)
        {
            List<String> suitMap = suitMapInit();

            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine("{0}: {1}", suitMap[i], playerHand.calculatedValue[i]);
            }
        }
    }
}
