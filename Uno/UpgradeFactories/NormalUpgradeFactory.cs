using Uno.Upgrades;

namespace Uno.UpgradeFactories
{
    internal class NormalUpgradeFactory : UpgradeFactory
    {
        private static readonly Random random = new Random();
        public override IUpgrade CreateUpgrade()
        {
            int rng = random.Next(0, 108);
            switch(rng)
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
