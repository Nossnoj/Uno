using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Players;

namespace Uno.Upgrades
{
    internal interface IUpgrade
    {
        void AddUpgrade(GameState state, Player player);
    }
}
