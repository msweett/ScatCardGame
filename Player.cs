using System;

namespace ScatCardGame
{
    public class Player
    {
        private static int playerNumber;

        public Hand Hand { get; private set; }
        public int Number { get; private set; }
        public Player()
        {
            Hand = new Hand();
            Number = ++playerNumber;
        }

        public void DisplayCardsInHand()
        {
            int selection = 0;

            Console.Clear();
            Console.WriteLine($"Player {Number} turn");
            Console.WriteLine("Your cards are: \n");

            foreach (Card card in Hand.Cards)
            {
                Console.WriteLine($"({selection}) {card}");
                selection++;
            }
        }
    }
}
