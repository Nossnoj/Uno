using Uno.Upgrades;

namespace Uno.UpgradeFactories
{
    internal class NoUpgradeFactory : UpgradeFactory
    {
        public override IUpgrade CreateUpgrade()
        {
            return new NoUpgrade();
        }
    }
}
