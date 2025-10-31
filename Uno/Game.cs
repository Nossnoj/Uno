using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;
using Uno.Players;

namespace Uno
{
    internal class Game
    {
        private GameState state = new GameState();
        private Deck deck;
        private List<Player> playerList = new();
        private UnoCard? topCard; //null innan spelet börjar
        public Game()
        {
            deck = new Deck();

            //skapa spelare här
        }
        public void StartGame()
        {
            topCard = deck.drawCard();
            topCard.Play(state);

            Console.WriteLine($"{topCard}");
        }

    }
}
