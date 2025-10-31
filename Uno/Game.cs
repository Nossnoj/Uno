using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;
using Uno.Factories;
using Uno.Players;

namespace Uno
{
    internal class Game
    {
        GameState state = new GameState();
        Deck deck;
        private List<Player> playerList = new();
        private UnoCard? topCard;
        public Game()
        {
            deck = new Deck();
            PlayerFactory humanPlayerFactory = new HumanPlayerFactory();
            PlayerFactory aiPlayerFactory = new AIPlayerFactory();
            Player Player1 = humanPlayerFactory.createPlayer("Player 1", new NormalStrategy(), deck);
            Player Player2 = aiPlayerFactory.createPlayer("AI 1", new NormalStrategy(), deck);
            Player Player3 = aiPlayerFactory.createPlayer("AI 2", new NormalStrategy(), deck);
            Player Player4 = aiPlayerFactory.createPlayer("AI 3", new NormalStrategy(), deck);
            
        }
        private void StartGame()
        {
           topCard = deck.drawCard();
           topCard.Play(state);
        }
        

    }
}
