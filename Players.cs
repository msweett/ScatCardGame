using System.Collections.Generic;
using System;

namespace ScatCardGame
{
    public class Players
    {
        private List<Player> players = new List<Player>();

        public Players(int numberOfPlayers, int numberOfAI)
        {
            for (int player = 0; player < numberOfPlayers; player++)
            {
                players.Add(new HumanPlayer());
            }

            for (int AI = 0; AI < numberOfAI; AI++)
            {
                players.Add(new AutomatedPlayer());
                players[AI].isPlayerAI = true;
            }
        }

        public void dealCard(int player, Card card)
        {
            players[player].addCard(card);
        }

        public Player getPlayer(int indexOfPlayer)
        {

            return players[indexOfPlayer];
        }
    }
}
