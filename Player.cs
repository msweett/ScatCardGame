using System;
using System.Collections.Generic;

namespace ScatCardGame
{
    public class Player
    {
        protected List<Card> playerHand = new List<Card>();
        private HandValue handValue = new HandValue();
        private Boolean isAI;

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
            for (int i = 0; i <= 3; i++)
            {
                suitValues += Globals.suitNames[i] + ": " + handValue.suitValue(i) + "\n";
            }
            return suitValues;
        }

        public string cardsToString()
        {
            int selection = 0;
            string handInfo = "";

            foreach (Card card in playerHand)
            {
                handInfo += "(" + selection + ")" + " " + card.getCardInfo() + "\n";
                selection++;
            }
            return handInfo;
        }

        public Boolean isWinningHand()
        {
            return handValue.isWinner(playerHand);
        }

        public Boolean isPlayerAI
        {
            get{ return isAI; }
            set{ isAI = value; }
        }
    }
}
