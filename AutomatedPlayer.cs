using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    class AutomatedPlayer : Player
    { 
        public AutomatedPlayer()
        {
            isPlayerAI = true;
        }

        public Card calculateBestCardToDraw(Card cardOne, Card cardTwo)
        {
            return cardOne;
        }

        /*
        private int calculateBestSuitToPursue()
        {
            int suitValue = 0;

            for (int i = 0; i < playerHand.countCards(); i++)
            {
                if (playerHand.findCard(i).Rank >= 6)
                {
                    if (playerHand.suitValueFor(i) > suitValue)
                    {
                        suitValue = playerHand.suitValueFor(i);
                    }
                }
            }

            return 3;
        }
        */

    }
}
