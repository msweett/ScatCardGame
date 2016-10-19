using System;
using System.Collections.Generic;

namespace ScatCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawPile drawPile = new DrawPile();
            CardPile discardPile = new CardPile();
            List<Player> players = new List<Player>();

            for (int i = 0; i < ScatGlobals.NumOfPlayers; i++)
            {
                players.Add(new Player());
            }

            drawPile.Shuffle();

            foreach (Player player in players)
            {
                while (player.Hand.Cards.Count < ScatGlobals.MaxCardsInHand)
                {
                    player.Hand.AddCard(drawPile.DrawCard());
                }
            }

            discardPile.PutCard(drawPile.DrawCard());

            foreach (Player player in players)
            {
                Hand playerHand = player.Hand;

                player.DisplayCardsInHand();

                Console.Write($"\n(d) Draw a card\t(p) pick the {discardPile.ViewTopCard()} from the discard pile");

                bool validInput;
                do
                {
                    validInput = true;
                    ConsoleKeyInfo userSelection = Console.ReadKey();

                    switch (userSelection.KeyChar)
                    {
                        case 'd':
                            playerHand.AddCard(drawPile.DrawCard());
                            break;
                        case 'p':
                            playerHand.AddCard(discardPile.DrawCard());
                            break;
                        default:
                            validInput = false;
                            Console.WriteLine("Invalid Selection, try again");
                            break;
                    }
                } while (!validInput);

                player.DisplayCardsInHand();

                int indexOfCardToDiscard = DiscardCardInput();

                Card cardToRemove = playerHand.Cards[indexOfCardToDiscard];
                discardPile.PutCard(cardToRemove);
                playerHand.RemoveCard(cardToRemove);

                Console.WriteLine($"\n{cardToRemove} has been discarded\n");

                foreach (Card card in playerHand.Cards)
                {
                    Console.WriteLine(card);
                }

                if (playerHand.IsWinner())
                {
                    Console.WriteLine("\nThe cake is a lie.");
                    break; //so we don't go to the next turn and clear isWinningHand
                }

                Console.WriteLine("\nPress any key to end your turn");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static int DiscardCardInput()
        {
            int inputAsInt;

            Console.Write("\nWhich card would you like to discard: ");

            do
            {
                ConsoleKeyInfo userSelection = Console.ReadKey();
                inputAsInt = Convert.ToInt32(char.GetNumericValue(userSelection.KeyChar));
            }
            while (inputAsInt < 0 || inputAsInt >= 4);

            return inputAsInt;
        }
    }
}
