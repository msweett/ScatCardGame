using System;
using System.Collections.Generic;

namespace ScatCardGame
{
    public abstract class Player
    {
        protected List<Card> playerHand = new List<Card>();
        protected HandValue handValue = new HandValue();
        protected Dictionary<int, Card> cardDisplayMap = new Dictionary<int, Card>();

        public abstract void playDrawCardTurn(ref DrawPile drawPile, ref CardPile discardPile);
        public abstract void playDiscardCardTurn(ref CardPile discardPile);

        public Player()
        {

        }  

        public void addCard(Card card)
        {
            playerHand.Add(card);
            handValue.calculateValue(playerHand);
        }

        public void removeCard(Card card)
        {
            playerHand.Remove(card);
            handValue.calculateValue(playerHand);
        }

        public Card getCard(int indexOfCard)
        {
            return playerHand[indexOfCard];
        }

        public string suitValuesToString()
        {
            string suitValues = "";

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            { 
                suitValues += suit + ": " + handValue.suitValue(suit) + "\n";
            }
            return suitValues;
        }

        public string cardsToString()
        {
            int selection = 0;
            string handInfo = "";
            cardDisplayMap.Clear();

            foreach (Card card in playerHand)
            {
                handInfo += "(" + selection + ") " + card.getCardInfo() + "\n";
                cardDisplayMap.Add(selection, card);
                selection++;
            }
            return handInfo;
        }

        public Boolean isWinningHand()
        {
            return handValue.isWinner(playerHand);
        }
    }
}
