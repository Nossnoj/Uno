using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Effects
{
    internal interface ICardEffect
    {
        void AddEffect(GameState state);
    }
}
