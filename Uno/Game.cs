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
            playerList.AddRange(new[] { Player1, Player2, Player3, Player4 });
            StartGame();

        }
        public void StartGame()
        {
            topCard = deck.drawCard();
            topCard.Play(state);
            UnoColor color = state.CurrentColor;
            RenderColor(color);
            Console.WriteLine($"Top card: {topCard}");
            RenderHand();

        }
        public void RenderHand()
        {
            var player = playerList[0];
            foreach (var card in player.Hand)
            {
                RenderColor(card.color);
                Console.Write($"{card}, ");
            }
            UnoColor color = state.CurrentColor;
        }
        public void RenderColor(UnoColor color)
        {
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
                //lägg till att göra regnbågsfärg för wildcards
            }
        }


    }
}
