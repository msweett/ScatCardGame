using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public abstract class Difficulty
    {
        public abstract Boolean shouldWeDrawFromDiscardPile(CardPile discardPile, HandValue handValue, List<Card> playerHand);
        public abstract Card cardToDiscard(List<Card> playerHand);
        public abstract Boolean knock();  
    }
}
