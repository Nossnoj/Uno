using Uno.Upgrades;

namespace Uno.UpgradeFactories
{
    internal class NormalUpgradeFactory : IUpgradeFactory
    {
        private static readonly Random random = new Random();

        public NormalUpgradeFactory()
        {
            ResetUpgrades();
        }

        private List<IUpgrade> remainingUpgrades;

        public IUpgrade CreateUpgrade()
        {
            if (remainingUpgrades.Count == 0)
            {
                ResetUpgrades();
            }
            int index = random.Next(remainingUpgrades.Count);
            IUpgrade upgrade = remainingUpgrades[index];
            remainingUpgrades.RemoveAt(index);

            return upgrade;
        }
        public void ResetUpgrades()
        {
            remainingUpgrades = new List<IUpgrade>();

            remainingUpgrades.Add(new Donate());
            remainingUpgrades.Add(new Swap());

            for (int i = 0; i < 10; i++)
            {
                remainingUpgrades.Add(new NoUpgrade());
            }
        }
    }
}
