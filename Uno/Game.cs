using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private int currentPlayerIndex = 0;
        private int direction = 1;
        public Render render = new Render();
        public Game()
        {
            deck = new Deck();
            PlayerFactory humanPlayerFactory = new HumanPlayerFactory();
            PlayerFactory aiPlayerFactory = new AIPlayerFactory();
            Player Player1 = humanPlayerFactory.createPlayer("Player 1", new NormalStrategy(), deck, state);
            Player Player2 = aiPlayerFactory.createPlayer("AI 1", new NormalStrategy(), deck, state);
            Player Player3 = aiPlayerFactory.createPlayer("AI 2", new NormalStrategy(), deck, state);
            Player Player4 = aiPlayerFactory.createPlayer("AI 3", new NormalStrategy(), deck, state);
            playerList.AddRange(new[] { Player1, Player2, Player3, Player4 });
            StartGame();

        }
        public void StartGame()
        {
            var numbers = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            topCard = deck.drawCard();
            if (!numbers.Contains(topCard.Symbol))
            {
                deck.discard.Add(topCard);
                topCard = deck.drawCard();
            }
            topCard.Play(state);
            Console.ForegroundColor = ConsoleColor.White;
            Turns();
        }

        public void Turns()
        {
            while (true)
            {
                Console.Clear();
                UnoColor color = state.CurrentColor;
                Console.Write($"Top card:");
                render.RenderColor(color);
                Console.WriteLine($" {topCard}");
                var currentPlayer = playerList[currentPlayerIndex];
                Console.WriteLine($"{currentPlayer.Name}'s turn!");
                var chosenCard = currentPlayer.playCard(currentPlayer.Hand, topCard);
                topCard = chosenCard;
                topCard.Play(state);
                NextPlayer();
                //kalla på NextPlayer på rätt sätt, detta är enbart en temporär lösning
            }
        }

        public void NextPlayer()
        {
            if (state.ReverseDirection)
                direction *= -1;

            if (state.SkipNextPlayer)
            {
                currentPlayerIndex = (currentPlayerIndex + 2 * direction + playerList.Count) % playerList.Count;
            }
            else
            {
                currentPlayerIndex = (currentPlayerIndex + direction + playerList.Count) % playerList.Count;
            }

            state.ReverseDirection = false;
            state.SkipNextPlayer = false;

            playerList[currentPlayerIndex].ResetDrawCount();
        }
    }
}
