using Uno.Upgrades;

namespace Uno.UpgradeFactories
{
    internal abstract class UpgradeFactory
    {
        public abstract IUpgrade CreateUpgrade();
    }
}
