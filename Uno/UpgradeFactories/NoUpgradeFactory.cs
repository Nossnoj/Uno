using Uno.Upgrades;

namespace Uno.UpgradeFactories
{
    internal class NoUpgradeFactory : IUpgradeFactory
    {
        public IUpgrade CreateUpgrade()
        {
            return new NoUpgrade();
        }
    }
}
