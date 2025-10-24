using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Effects
{
    internal class SkipEffect : ICardEffect
    {
        public void AddEffect(GameState state)
        {
            state.SkipNextPlayer = true;
        }
    }
}
