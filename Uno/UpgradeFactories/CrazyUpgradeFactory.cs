
using Uno.Upgrades;

namespace Uno.UpgradeFactories
{
    internal class ChooseUpgradeFactory : IUpgradeFactory
    {
        private static readonly Random random = new Random();
        GameRender renderGame = new GameRender();
        private int donateOdds;
        private int swapOdds;

        public ChooseUpgradeFactory()
        {
            renderGame.RenderPrompt("Choose the odds of a card having a Donate upgrade:");
            donateOdds = ValidateChoice();
            Console.Clear();

            renderGame.RenderPrompt("Choose the odds of a card having a Swap upgrade:");
            swapOdds = ValidateChoice();
            Console.Clear();
        }

        public IUpgrade CreateUpgrade()
        {
            int rng = random.Next(0, 100);

            if(rng < donateOdds)
                return new Donate();

            if(rng < donateOdds + swapOdds)
                return new Swap();

            return new NoUpgrade();
        }

        private int ValidateChoice()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 0)
                    return choice;

                Console.WriteLine("Enter a valid number!");
            }
        }
    }
}
