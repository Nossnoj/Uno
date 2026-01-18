using Uno.Cards;
using Uno.Players;
using Uno.UpgradeFactories;
using Uno.Upgrades;
using Uno.UpgradeFactories;

namespace Uno
{
    internal class Game
    {
        private GameState state;// = new GameState();
        private Deck deck;
        private List<Player> playerList = new();
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
            //byt alternativen och lägg rendera dom i rätt med motorn
            Console.WriteLine("Choose a difficulty by typing 1, 2 or 3: ");
            Console.WriteLine("1: Easy");
            Console.WriteLine("2: Medium");
            Console.WriteLine("3: Hard");
            string input = Console.ReadLine();

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
            //playerList.Add(humanPlayer);
            for (int i = 0; i < 3; i++)
            {
                string aiName = $"Player {i + 1}";
                Player AIPlayer = new AiPlayer(aiName, deck, state);
                state.Players.Add(AIPlayer);
            }
            //state.Players = playerList;
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
            //state.Players = playerList; //? //
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
                string s = $"{currentPlayer.Name}'s turn!";
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
