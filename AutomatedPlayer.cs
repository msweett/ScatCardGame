﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ScatCardGame
{
    public class AutomatedPlayer : Player
    {
        public Difficulty difficulty;

        public AutomatedPlayer(int displayNumber, Difficulty difficulty)
        {
            this.difficulty = difficulty;
            this.displayNumber = displayNumber;
        }

        public override void playTurn(ref DrawPile drawPile, ref CardPile discardPile)
        {
            displayHeader();
            Console.WriteLine(cardsToString());
            playDrawCardTurn(ref drawPile, ref discardPile);

            displayHeader();
            Console.WriteLine(cardsToString());
            playDiscardCardTurn(ref discardPile, playerHand);
        }

        private void playDrawCardTurn(ref DrawPile drawPile, ref CardPile discardPile)
        {
            Console.Write("\n(d) Draw a card\t(p) pick the {0} from the discard pile", discardPile.viewTopCard().getCardInfo());

            if (difficulty.shouldWeDrawFromDiscardPile(discardPile, handValue, playerHand))
            {
                Console.WriteLine("\nDrawing card from discard pile..");
                addCard(discardPile.drawCard());
            }

            else
            {
                Console.WriteLine("\nDrawing card from draw pile..");
                addCard(drawPile.drawCard());
            }

            Console.ReadLine();
        }

        private void playDiscardCardTurn(ref CardPile discardPile, List<Card> playerHand)
        {
            Card cardToDiscard = difficulty.cardToDiscard(playerHand);
            Console.WriteLine(" The best card to discard is: " + cardToDiscard.getCardInfo());
            discardCard(ref discardPile, cardToDiscard);
            Console.ReadLine();
        }

        private void discardCard(ref CardPile discardPile, Card card)
        {
            discardPile.putCard(card);
            removeCard(card);
        }

        /*
        Code for more complicated AI, don't have a class yet
        private int cardToDiscard()
        {
            int indexOfCardToDiscard = findLowestCardNotInPursuingSuit();

            if (indexOfCardToDiscard == -1)
            {
                indexOfCardToDiscard = findLowestCard();
            }

            return indexOfCardToDiscard;
        }

        private int findLowestCardNotInPursuingSuit()
        {
            Suit pursuingSuit = calculateBestSuitToPursue();
            int previousCardValue = 12;
            int indexOfCardToDiscard = -1;
            int counter = 0;

            foreach (Card card in playerHand)
            {
                int cardValue = card.getRankValue();

                if ((card.suit != pursuingSuit) && (cardValue < previousCardValue))
                {
                    indexOfCardToDiscard = counter;
                    previousCardValue = cardValue;
                }
                counter++;
            }

            return indexOfCardToDiscard;
        }

        private int findLowestCard()
        {
            int previousCardValue = 12;
            int indexOfCardToDiscard = -1;
            int counter = 0;

            foreach (Card card in playerHand)
            {
                int cardValue = card.getRankValue();

                if (cardValue < previousCardValue)
                {
                    indexOfCardToDiscard = counter;
                    previousCardValue = cardValue;
                }
                counter++;
            }

            return indexOfCardToDiscard;
        }

        private Boolean isDrawFromDiscardPileViable(CardPile discardPile)
        {
            int valueOfTopCard = discardPile.viewTopCard().getRankValue();
            Suit suitOfTopCard = discardPile.viewTopCard().suit;
            Suit suitToPursue = calculateBestSuitToPursue();
            Boolean isCardViable = false;

            if ((valueOfTopCard >= 6) && (suitOfTopCard == suitToPursue))
            {
                isCardViable = true;
            }

            return isCardViable;
        }

        private Suit calculateBestSuitToPursueWithDiscardPile()
        {
            List<Suit> suitsThatCanWin = getSuitsThatCanWin();

            Suit bestSuit;
            if (suitsThatCanWin.Count > 0)
            {
                bestSuit = findHighestValuedSuit(suitsThatCanWin);
            }
            else
            {
                IEnumerable<Suit> suits = Enum.GetValues(typeof(Suit)).Cast<Suit>();
                bestSuit = findHighestValuedSuit(suits);
            }

            return bestSuit;
        }
        
        private Suit calculateBestSuitToPursue()
        {
            List<Suit> suitsThatCanWin = getSuitsThatCanWin();

            Suit bestSuit;
            if (suitsThatCanWin.Count > 0)
            {
                bestSuit = findHighestValuedSuit(suitsThatCanWin);
            }
            else
            {
                IEnumerable<Suit> suits = Enum.GetValues(typeof(Suit)).Cast<Suit>();
                bestSuit = findHighestValuedSuit(suits);
            }

            return bestSuit;
        }

        private Suit findHighestValuedSuit(IEnumerable<Suit> suits)
        {
            int previousSuitValue = 0;
            Suit highestValueSuit = Suit.Hearts;

            foreach (Suit suit in suits)
            {
                if (handValue.suitValue(suit) > previousSuitValue)
                {
                    highestValueSuit = suit;
                    previousSuitValue = handValue.suitValue(suit);
                }
            }
            return highestValueSuit;
        }

        private List<Suit> getSuitsThatCanWin()
        {
            List<Suit> suitsThatCanWin = new List<Suit>();

            foreach (Card card in playerHand)
            {
                if (canSuitWin(card.suit))
                {
                    suitsThatCanWin.Add(card.suit);
                }
            }

            return suitsThatCanWin;
        }
        
        private Boolean canSuitWin(Suit suit)
        {
            List<Card> cards = getCardsFromASpecificSuit(suit);
            Card maxCard = new Card(suit, Rank.Ace);
            int maxRankValue = 11;
            int sumOfRanks = sumRanks(cards);
            int winningHandValue = handValue.getWinningHandValue();

            int remainingValueUntilWinner = winningHandValue - sumOfRanks;

            Boolean suitCanWin = false;
            if (remainingValueUntilWinner <= maxRankValue)
            {
                if ((remainingValueUntilWinner == maxRankValue) && (cards.Contains(maxCard)))
                {
                    suitCanWin = false;
                }
                else
                {
                    suitCanWin = true;
                }
            }
            return suitCanWin;
        }

        private int sumRanks(List<Card> cards)
        {
            int sum = 0;
            foreach (Card card in cards)
            {
                sum += card.getRankValue();
            }
            return sum;
        }

        private List<Card> getCardsFromASpecificSuit(Suit suit)
        {
            List<Card> cards = new List<Card>();

            foreach (Card card in playerHand)
            {
                if (card.suit == suit)
                {
                    cards.Add(card);
                }
            }

            return cards;
        }
        */
    }
}
