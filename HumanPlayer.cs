using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatCardGame
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(int displayNumber)
        {
            this.displayNumber = displayNumber;
        }

        public override void playTurn(ref DrawPile drawPile, ref CardPile discardPile)
        {
            displayHeader();
            playDrawCardTurn(ref drawPile, ref discardPile);

            displayHeader();
            playDiscardCardTurn(ref discardPile);
        }

        private void playDrawCardTurn(ref DrawPile drawPile, ref CardPile discardPile)
        {
            Console.WriteLine(cardsToString());
            Console.Write("\n(d) Draw a card\t(p) pick the {0} from the discard pile", discardPile.viewTopCard().getCardInfo());

            switch (drawCardInput())
            {
                case 'd':
                    addCard(drawPile.drawCard());
                    break;
                case 'p':
                    addCard(discardPile.drawCard());
                    break;
            }
        }

        private void playDiscardCardTurn(ref CardPile discardPile)
        {
            Console.WriteLine(cardsToString());
            Console.Write("Which card would you like to discard: ");

            int indexOfCard = cardToDiscardInput();
            Card cardToDiscard = cardDisplayMap[indexOfCard];

            removeCard(cardToDiscard);
            discardPile.putCard(cardToDiscard);

            Console.WriteLine();
            Console.WriteLine(suitValuesToString());
        }

        private int cardToDiscardInput()
        {
            int inputAsInt;
            ConsoleKeyInfo userSelection;

            do
            {
                userSelection = Console.ReadKey();
                inputAsInt = Convert.ToInt32(Char.GetNumericValue(userSelection.KeyChar));
            } while (inputAsInt < 0 || inputAsInt >= 4);

            return inputAsInt;
        }

        private char drawCardInput()
        {
            char userSelection;

            do
            {
                userSelection = Console.ReadKey().KeyChar;
            } while (userSelection != 'd' && userSelection != 'p');

            return userSelection;
        }

    }
}
