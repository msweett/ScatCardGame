using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public class Easy : Difficulty
    {
        public override Boolean shouldWeDrawFromDiscardPile(CardPile discardPile, HandValue handValue, List<Card> playerHand)
        {
            Boolean drawFromDiscardPile = false;
            Suit highestValuedSuit = handValue.highestValuedSuit();
            Card topOfDiscardPile = discardPile.viewTopCard();

            //if top of discard pile is not in the highest valued suit, draw from draw pile
            if (topOfDiscardPile.suit == highestValuedSuit)
            {
                //if hand contains 3 of the same highest valued suit, compare lowest valued card with top of discard pile, 
                //if it's higher, draw it, if not don't
                if ((numberOfCardsInSuit(playerHand, highestValuedSuit) == 3 && lowestCardInSuit(playerHand, highestValuedSuit).rank < topOfDiscardPile.rank)
                        || numberOfCardsInSuit(playerHand, highestValuedSuit) < 3)
                {
                    drawFromDiscardPile = true;
                }
            }
               
            return drawFromDiscardPile;
        }

        
        public override Card bestCardToDiscard(HandValue handValue, List<Card> playerHand)
        {
            //card that isn't in dominant suit
                //if there are 2, pick the lowest card
            
            //isCardInSuit(handValue.highestValuedSuit);   
            //lowest card in dominant suit 
            int indexOfCardToDiscard = findLowestCardNotInPursuingSuit();

            if (indexOfCardToDiscard == -1)
            {
                indexOfCardToDiscard = findLowestCard();
            }

            return indexOfCardToDiscard;
        }
        

        public override Boolean knock()
        {
            return true;
        }

        private int findLowestCardNotInPursuingSuit(List<Card> playerHand, HandValue handValue)
        {
            Suit pursuingSuit = handValue.highestValuedSuit(); 
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

        private Suit bestSuitToPursue(List<Card> playerHand, HandValue handValue)
        {
            Suit bestSuit;

            //find highest value suit

            bestSuit = handValue.highestValuedSuit();
              
            return bestSuit;
        }

        private Card lowestCardInSuit(List<Card> playerHand, Suit suit)
        {
            Card lowestCard = new Card(suit, Rank.Ace);

            foreach (Card card in playerHand)
            {
                if (card.getRankValue() < lowestCard.getRankValue() && card.suit == suit)
                {
                    lowestCard = card;
                }
            }

            return lowestCard;
        }

        private Card lowestCardNotInSuit(List<Card> playerHand, Suit suit)
        {
            int previousCardValue = (int)Rank.Ace;
            Card lowestCard = null;

            foreach (Card card in playerHand)
            {
                int cardValue = card.getRankValue();
                if (card.suit != suit && cardValue < previousCardValue)
                {
                    lowestCard = card;
                    previousCardValue = cardValue;
                }
            }

            return lowestCard;
        }

        private int numberOfCardsInSuit(List<Card> playerHand, Suit suit)
        {
            int cardsInSuit = 0;
            foreach (Card card in playerHand)
            {
                if (card.suit == suit)
                {
                    cardsInSuit++;
                }
            }
            return cardsInSuit;
        }

    }
}
