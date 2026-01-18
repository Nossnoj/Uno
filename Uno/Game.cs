using Uno.Cards;
using Uno.Players;
using Uno.UpgradeFactories;
using Uno.Upgrades;
using Uno.Renderer;
namespace Uno
{
    internal class Game
    {
        private GameState state;
        private Deck deck;
        private UnoCard? topCard;
        private int currentPlayerIndex = 0;
        private int direction = 1;
        public Render render = new Render();
        public GameRender gameRender = new GameRender();
        public Game()
        {
            this.state = new GameState();
            
            IUpgradeFactory factory = ChooseDifficulty();
            deck = new Deck(factory);
            createPlayers();
        }

        private IUpgradeFactory ChooseDifficulty()
        {
            string prompt =
            "Choose a gamemode by typing 1, 2 or 3:\n" +
            "1: No upgrade mode\n" +
            "2: Normal upgrade mode (9 swap upgrades and 9 donate upgrades)\n" +
            "3: Choose your own amount of upgrades\n";
            gameRender.RenderPrompt(prompt);
            string input = Console.ReadLine();
            Console.Clear();


            switch (input)
            {
                case "1":
                    return new NoUpgradeFactory();

                case "2":
                    return new NormalUpgradeFactory();

                case "3":
                    return new ChooseUpgradeFactory();

                default:
                    Console.WriteLine("Invalid choice, defaulting to Normal");
                    return new NormalUpgradeFactory();
            }
        }

        private void createPlayers()
        {
            Player humanPlayer = new HumanPlayer("player", deck, state);
            state.Players.Add(humanPlayer);
            for (int i = 0; i < 3; i++)
            {
                string aiName = $"Player {i + 1}";
                Player AIPlayer = new AiPlayer(aiName, deck, state);
                state.Players.Add(AIPlayer);
            }
        }
        public void StartGame()
        {
            var numbers = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            do
            {
                topCard = deck.drawCard();
            }
            while (!numbers.Contains(topCard.Symbol) || topCard.Upgrade is not NoUpgrade);
            deck.discard.Add(topCard);
            var currentPlayer = state.Players[currentPlayerIndex];
            state.CurrentPlayer = currentPlayer;
            topCard.Play(state);
            Console.ForegroundColor = ConsoleColor.White;
            Turns();
        }

        private void Turns()
        {
            while (true)
            {
                UnoColor color = state.CurrentColor;
                gameRender.RenderHands(state.Players);
                gameRender.RenderTopCard(topCard, state);
                var currentPlayer = state.Players[currentPlayerIndex];
                string s = $"{currentPlayer.Name}'s turn! ";
                gameRender.RenderComment(s, 0);
                UnoCard? chosenCard = currentPlayer.playCard(currentPlayer.Hand, topCard);
                if (chosenCard == null)
                {
                    GameWin(currentPlayer);
                    NextPlayer();
                    continue;
                }
                topCard = chosenCard;
                state.CurrentPlayer = currentPlayer;
                topCard.Play(state);
                GameWin(currentPlayer);
                Thread.Sleep(2000);
                NextPlayer();
            }
        }

        private void NextPlayer()
        {
            if (state.ReverseDirection)
                direction *= -1;

            if (state.SkipNextPlayer)
            {
                currentPlayerIndex = (currentPlayerIndex + 2 * direction + state.Players.Count) % state.Players.Count;
            }
            else
            {
                currentPlayerIndex = (currentPlayerIndex + direction + state.Players.Count) % state.Players.Count;
            }

            state.ReverseDirection = false;
            state.SkipNextPlayer = false;

            state.Players[currentPlayerIndex].ResetDrawCount();
        }
        private void GameWin(Player player)
        {
            var hand = player.Hand;
            var name = player.Name;
            if (hand.Cards.Count == 0)
            {
                string s = $"{name} has won!";
                gameRender.RenderComment(s,10);
                Environment.Exit(0);
            }
        }
    }
}
