using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ScatCardGame
{
    class PlayersHands : Hand
    {
        public Collection<Hand> playersHands = new Collection<Hand>();
        public int NUM_OF_PLAYERS, MAX_CARDS_IN_HAND;

        public PlayersHands(int numOfPlayers, int maxCardsInHand)
        {
            NUM_OF_PLAYERS = numOfPlayers;
            MAX_CARDS_IN_HAND = maxCardsInHand;
        }

        public void init()
        {
            for (int player = 0; player < NUM_OF_PLAYERS; player++)
            {
                playersHands.Add(new Hand());
                playersHands[player].handInit();   
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
    }
}
