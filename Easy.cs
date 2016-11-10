using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public class Easy : Difficulty
    {
        private Suit pursuingSuit;

        public override Boolean shouldWeDrawFromDiscardPile(CardPile discardPile, HandValue handValue, List<Card> playerHand)
        {
            Boolean drawFromDiscardPile = false;
            Card topOfDiscardPile = discardPile.viewTopCard();

            calculateBestSuitToPursue(handValue);

            //if top of discard pile is not in the highest valued suit, draw from draw pile
            if (topOfDiscardPile.suit == pursuingSuit)
            {
                //if hand contains 3 of the same pursuing suit, compare lowest valued card with top of discard pile, 
                //if it's higher, draw it, if not don't
                if ((numberOfCardsInPursuingSuit(playerHand) == 3 && lowestCardInPursuingSuit(playerHand).rank < topOfDiscardPile.rank)
                        || numberOfCardsInPursuingSuit(playerHand) < 3)
                {
                    drawFromDiscardPile = true;
                }
            }
               
            return drawFromDiscardPile;
        }

        
        public override Card cardToDiscard(List<Card> playerHand)
        {
            Card cardToDiscard = lowestCardNotInPursuingSuit(playerHand);

            if (cardToDiscard == null)
            {
                cardToDiscard = lowestCardInPursuingSuit(playerHand);
            }

            return cardToDiscard;
        }
        

        public override Boolean knock()
        {
            return true;
        }

        private Card lowestCardNotInPursuingSuit(List<Card> playerHand)
        {
            int cardValue;
            int previousCardValue = 12;
            Card lowestCard = null;

            foreach (Card card in playerHand)
            {
                cardValue = card.getRankValue();

                if ((card.suit != pursuingSuit) && (cardValue < previousCardValue))
                {
                    lowestCard = card;
                    previousCardValue = cardValue;
                }
            }

            return lowestCard;
        }

        private void calculateBestSuitToPursue(HandValue handValue)
        {
            pursuingSuit = handValue.highestValuedSuit();
        }

        private Card lowestCardInPursuingSuit(List<Card> playerHand)
        {
            int cardValue;
            int previousCardValue = 12;
            Card lowestCard = null;

            foreach (Card card in playerHand)
            {
                cardValue = card.getRankValue();
                if (cardValue < previousCardValue && card.suit == pursuingSuit)
                {
                    lowestCard = card;
                    previousCardValue = cardValue;
                }
            }

            return lowestCard;
        }

        private int numberOfCardsInPursuingSuit(List<Card> playerHand)
        {
            int cardsInSuit = 0;
            foreach (Card card in playerHand)
            {
                if (card.suit == pursuingSuit)
                {
                    cardsInSuit++;
                }
            }
            return cardsInSuit;
        }

    }
}
