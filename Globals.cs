using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public static class Globals
    {
        public static List<String> suitNames = new List<String> { "Hearts", "Diamonds", "Clubs", "Spades" };
        public const int NUM_OF_PLAYERS = 2;
        public const int MAX_CARDS_IN_HAND = 3;
        public const int NUM_OF_AI = 0;
    }
}
