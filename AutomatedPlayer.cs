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
            int bestSuitValue = 0;
            List<Card> cardsInHand = playerHand.getListOfCards();

            foreach (Card card in cardsInHand)
            {

            }

            return 3;
        }
        */

        /*
        private Boolean canSuitWin(int suit, List<Card> cards)
        {
            List<int> ranks = new List<int>();

            //add all cards from a given suit to a list
            foreach (Card card in cards)
            {
                if (card.Suit == suit)
                {
                    ranks.Add(card.Rank);
                }
            }

            //sum up all ranks in the list
            int sum = 0;
            foreach (int i in ranks)
            {
                sum += i;
            }

            int winningHandValue = 31;
            Boolean suitCanWin = false;
            if ((winningHandValue - sum < 13) && (!ranks.Contains(13))) //eventually add: && if the 
            {
                suitCanWin = true;
            }
            return suitCanWin;
        }
        */

    }
}
