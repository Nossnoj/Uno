using Uno.Upgrades;

namespace Uno.UpgradeFactories
{
    internal class NormalUpgradeFactory : IUpgradeFactory
    {
        private static readonly Random random = new Random();
        public IUpgrade CreateUpgrade()
        {
            int rng = random.Next(0, 108);
            switch (rng)
            {
                case <= 8:
                    return new Donate();
                case <= 16:
                    return new Swap();
                default:
                    return new NoUpgrade();
            }

        }
    }
}
