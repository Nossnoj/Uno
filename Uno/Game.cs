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
        private UnoCard? topCard; //null innan spelet börjar
        private int currentPlayerIndex = 0;
        private int direction = 1;
        public Game()
        {
            deck = new Deck();
            PlayerFactory humanPlayerFactory = new HumanPlayerFactory();
            PlayerFactory aiPlayerFactory = new AIPlayerFactory();
            Player Player1 = humanPlayerFactory.createPlayer("Player 1", new NormalStrategy(), deck);
            Player Player2 = aiPlayerFactory.createPlayer("AI 1", new NormalStrategy(), deck);
            Player Player3 = aiPlayerFactory.createPlayer("AI 2", new NormalStrategy(), deck);
            Player Player4 = aiPlayerFactory.createPlayer("AI 3", new NormalStrategy(), deck);
            playerList.AddRange(new[] { Player1, Player2, Player3, Player4});
        }
        public void StartGame()
        {
            topCard = deck.drawCard();
            topCard.Play(state);

            Console.WriteLine($"{topCard}");
        }

        public void Turns()
        {
            while (true)
            {
                var currentPlayer = playerList[currentPlayerIndex];
                Console.WriteLine($"{currentPlayer.Name}'s turn!");


            }

            //kalla på NextPlayer
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
        }
    }
}
