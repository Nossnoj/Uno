
using Uno.Upgrades;

namespace Uno.UpgradeFactories
{
    internal class CrazyUpgradeFactory : IUpgradeFactory
    {
        private static readonly Random random = new Random();
        public IUpgrade CreateUpgrade()
        {
            /*Console.WriteLine("Choose how many upgrades you want");
            Console.WriteLine("Swap");
            int swapaAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("Donate");
            int donateAmount = int.Parse(Console.ReadLine());*/
            int rng = random.Next(0, 108);
            if(rng <= 18)
            {
                return new Donate();
            }
            else if (rng <= 76)
            {
                return new Swap();
            }
            else
            {
                return new NoUpgrade();
            }
        }
    }
}
