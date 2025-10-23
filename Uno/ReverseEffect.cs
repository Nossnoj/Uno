using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class ReverseEffect : ICardEffect
    {
        public void AddEffect(GameState state)
        {
            state.ReverseDirection = !state.ReverseDirection;
        }
    }
}
