﻿using System;

namespace ScatCardGame
{
    public class Card
    {
        public Rank Rank { get; }
        public Suit Suit { get; }

        public Card(Suit suit, Rank rank)
        {
            if (!Enum.IsDefined(typeof(Suit), suit))
            {
                throw new System.ArgumentOutOfRangeException("Card suit is invalid, please chose a number between 0 and 3");
            }

            if (!Enum.IsDefined(typeof(Rank), rank))
            {
                throw new System.ArgumentOutOfRangeException("Card rank is invalid, please chose a number between 1 and 13");
            }

            Suit = suit;
            Rank = rank;
        }

        public string getCardInfo()
        {
            return $"{Rank} of {Suit}";
        }
    }
}

