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
        private GameState state = new GameState();
        private Deck deck;
        private List<Player> playerList = new();
        private UnoCard? topCard; //null innan spelet börjar
        public Game()
        {
            deck = new Deck();
            PlayerFactory humanPlayerFactory = new HumanPlayerFactory();
            PlayerFactory aiPlayerFactory = new AIPlayerFactory();
            Player Player1 = humanPlayerFactory.createPlayer("Player 1", new NormalStrategy(), deck);
            Player Player2 = aiPlayerFactory.createPlayer("AI 1", new NormalStrategy(), deck);
            Player Player3 = aiPlayerFactory.createPlayer("AI 2", new NormalStrategy(), deck);
            Player Player4 = aiPlayerFactory.createPlayer("AI 3", new NormalStrategy(), deck);
            StartGame();

        }
        public void StartGame()
        {
            topCard = deck.drawCard();
            topCard.Play(state);

            Console.WriteLine($"{topCard}");
            
        }
        public void Render()
        {
            UnoColor color = state.CurrentColor;
            switch (color)
            {   
                case UnoColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case UnoColor.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case UnoColor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case UnoColor.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine($"Top card: {topCard}");
            Console.WriteLine($"Current color: {state.CurrentColor}");
        }
        

    }
}
