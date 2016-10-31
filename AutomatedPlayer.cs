using System;
using System.Collections.Generic;
using System.Linq;

namespace ScatCardGame
{
    public class AutomatedPlayer : Player
    {
        public AutomatedPlayer(int displayNumber)
        {
            this.displayNumber = displayNumber;
        }

        public override void playTurn(ref DrawPile drawPile, ref CardPile discardPile)
        {
            displayHeader();
            Console.WriteLine(cardsToString());
            playDrawCardTurn(ref drawPile, ref discardPile);

            displayHeader();
            Console.WriteLine(cardsToString());
            playDiscardCardTurn(ref discardPile);
        }

        private void playDrawCardTurn(ref DrawPile drawPile, ref CardPile discardPile)
        {
            Console.Write("\n(d) Draw a card\t(p) pick the {0} from the discard pile", discardPile.viewTopCard().getCardInfo());
            Console.WriteLine("\nThe best suit to pursue is: " + calculateBestSuitToPursue());

            if (isDrawFromDiscardPileViable(discardPile))
            {
                Console.WriteLine("Drawing card from discard pile..");
                addCard(discardPile.drawCard());
            }

            else
            {
                Console.WriteLine("Drawing card from draw pile..");
                addCard(drawPile.drawCard());
            }

            Console.ReadLine();
        }

        private void playDiscardCardTurn(ref CardPile discardPile)
        {
            Console.WriteLine("Best suit: " + calculateBestSuitToPursue() + " The best card to discard is: " + cardToDiscard());
            discardCard(ref discardPile);
            Console.ReadLine();
        }

        private void discardCard(ref CardPile discardPile)
        {
            Card card = cardDisplayMap[cardToDiscard()];

            discardPile.putCard(card);
            removeCard(card);
        }

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
                int cardValue = handValue.getRankValue(card.rank);

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
                int cardValue = handValue.getRankValue(card.rank);

                if (cardValue < previousCardValue)
                {
                    indexOfCardToDiscard = counter;
                    previousCardValue = cardValue;
                }
                counter++;
            }

            return indexOfCardToDiscard;
        }

        private Card calculateBestCardToDraw(Card cardOne, Card cardTwo)
        {
            return cardOne;
        }

        private Boolean isDrawFromDiscardPileViable(CardPile discardPile)
        {
            int valueOfTopCard = handValue.getRankValue(discardPile.viewTopCard().rank);
            Suit suitOfTopCard = discardPile.viewTopCard().suit;
            Suit suitToPursue = calculateBestSuitToPursue();
            Boolean isCardViable = false;

            if ((valueOfTopCard >= 6) && (suitOfTopCard == suitToPursue))
            {
                isCardViable = true;
            }

            return isCardViable;
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
            List<Rank> cards = getCardsFromASpecificSuit(suit);
            Rank maxRank = Rank.Ace;
            int maxRankValue = handValue.getRankValue(maxRank);
            int sumOfRanks = sumRanks(cards);
            int winningHandValue = handValue.getWinningHandValue();

            int remainingValueUntilWinner = winningHandValue - sumOfRanks;

            Boolean suitCanWin = false;
            if (remainingValueUntilWinner <= maxRankValue)
            {
                if ((remainingValueUntilWinner == maxRankValue) && (cards.Contains(maxRank)))
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

        private int sumRanks(List<Rank> ranks)
        {
            int sum = 0;
            foreach (Rank i in ranks)
            {
                sum += handValue.getRankValue(i);
            }
            return sum;
        }

        private List<Rank> getCardsFromASpecificSuit(Suit suit)
        {
            List<Rank> ranks = new List<Rank>();

            foreach (Card card in playerHand)
            {
                if (card.suit == suit)
                {
                    ranks.Add(card.rank);
                }
            }

            return ranks;
        }
    }
}
