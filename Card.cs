﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public class Card
    {
        public Rank Rank { get; }
        public Suit Suit { get; }

        public Card(int suit, int rank)
        {
            if (!Enum.IsDefined(typeof(Suit), suit))
            {
                throw new System.ArgumentOutOfRangeException("Card suit is invalid, please chose a number between 0 and 3");
            }

            if (!Enum.IsDefined(typeof(Rank), rank))
            {
                throw new System.ArgumentOutOfRangeException("Card rank is invalid, please chose a number between 1 and 13");
            }

            Suit = (Suit)suit;
            Rank = (Rank)rank;
        }

        public string getCardInfo()
        {
            return $"{Rank} of {Suit}";//,{rank}, Globals.suitNames[(int)suit]);
        }
    }
}

