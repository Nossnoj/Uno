using Uno.Upgrades;

namespace Uno.UpgradeFactories
{
    internal interface IUpgradeFactory 
    {
        public IUpgrade CreateUpgrade();
    }
}
