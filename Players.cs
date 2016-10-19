using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public class Players
    {
        private List<Player> players = new List<Player>();

        public Players(int numberOfPlayers, int numberOfAI)
        {
            for (int player = 0; player < numberOfPlayers; player++)
            {
                players.Add(new Player());
            }

            for (int AI = 0; AI < numberOfAI; AI++)
            {
                players.Add(new AutomatedPlayer());
            }
        }

        public void dealCard(int player, Card card)
        {
            players[player].addCardToHand(card);
        }

        public Player getPlayer(int indexOfPlayer)
        {
            return players[indexOfPlayer];
        }

    }
}
