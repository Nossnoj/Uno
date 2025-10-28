using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno
{
    internal class Game
    {
        GameState state = new GameState();
        Deck deck;
        UnoCard topCard;
        public Game()
        {
            deck = new Deck();
        }
        private void StartGame()
        {
           topCard = deck.drawCard();
        }

    }
}
