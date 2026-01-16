
using Uno.Upgrades;

namespace Uno.UpgradeFactories
{
    internal class CrazyUpgradeFactory : IUpgradeFactory
    {
        private static readonly Random random = new Random();
        public IUpgrade CreateUpgrade()
        {
            int rng = random.Next(0, 108);
            switch (rng)
            {
                case <= 18:
                    return new Donate();
                case <= 36:
                    return new Swap();
                default:
                    return new NoUpgrade();
            }

        }
    }
}
