using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public class Player
    {
        protected Hand playerHand = new Hand();
        private Boolean isAI;

        public Player()
        {

        }

        public void addCardToHand(Card card)
        {
            playerHand.addCard(card);
        }

        public void removeCardFromHand(Card card)
        {
            playerHand.removeCard(card);
        }

        public Hand getPlayerHand()
        {
            return playerHand;
        }

        public Boolean isPlayerAI
        {
            get{ return isAI; }
            set{ isAI = value; }
        }
    }
}
