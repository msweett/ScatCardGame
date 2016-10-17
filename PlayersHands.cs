using System;
using System.Collections.ObjectModel;

namespace ScatCardGame
{
    public class PlayersHands : Hand
    {
        private Collection<Hand> playersHands = new Collection<Hand>();

        public PlayersHands(int numOfPlayers)
        {
            for (int player = 0; player < numOfPlayers; player++)
            {
                playersHands.Add(new Hand());
            }
        }

        public void dealCard(int player, Card card)
        {
            playersHands[player].addCard(card);
        }

        public Hand getPlayerHand(int playerIndex)
        {
            return playersHands[playerIndex];          
        }

        public int countCards()
        {
            return playersHands.Count;
        }

    }
}
