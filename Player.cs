using System;
using System.Collections.Generic;

namespace ScatCardGame
{
    public abstract class Player
    {
        protected List<Card> playerHand = new List<Card>();
        protected HandValue handValue   = new HandValue();

        protected Dictionary<int, Card> cardDisplayMap = new Dictionary<int, Card>();
        public int displayNumber;

        public abstract void playTurn(ref DrawPile drawPile, ref CardPile discardPile);

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

        public Boolean hasWinningHand()
        {
            return handValue.isWinner(playerHand);
        }

        protected string suitValuesToString()
        {
            string suitValues = "";

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            { 
                suitValues += suit + ": " + handValue.suitValue(suit) + "\n";
            }
            return suitValues;
        }

        protected string cardsToString()
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

        protected int playerDisplayNumber
        {
            get { return displayNumber; }
            set { displayNumber = value; }
        }

        protected void displayHeader()
        {
            Console.Clear();
            Console.WriteLine("Player {0} turn", playerDisplayNumber);
            Console.WriteLine("Your cards are: \n");
        }

        private Card lowestCardForSuit(Suit suit)
        {
            Card lowestCard = new Card(suit, Rank.Ace);

            foreach (Card card in playerHand)
            {
                if (card.rank < lowestCard.rank && card.suit == suit)
                {
                    lowestCard = card;
                }
            }
            return lowestCard;
        }
    }
}
