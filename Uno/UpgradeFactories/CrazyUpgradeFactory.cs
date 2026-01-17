
using Uno.Upgrades;

namespace Uno.UpgradeFactories
{
    internal class CrazyUpgradeFactory : IUpgradeFactory
    {
        private static readonly Random random = new Random();
        private int donateAmount;
        private int swapAmount;

        public CrazyUpgradeFactory()
        {
            Console.WriteLine("Choose how many Donate upgrades you want:");
            donateAmount = ValidateChoice();

            Console.WriteLine("Choose how many Swap upgrades you want:");
            swapAmount = ValidateChoice();
        }

        public IUpgrade CreateUpgrade()
        {
            int rng = random.Next(0, 108);

            if(rng <= donateAmount)
                return new Donate();

            else if(rng <= swapAmount)
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
