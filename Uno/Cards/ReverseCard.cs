using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal class ReverseCard : UnoCard<ReverseCard, ReverseEffect>
    {
        public ReverseCard(UnoColor color)
            : base(color, "Reverse", new ReverseEffect()) { }


        public void AddEffect(GameState state)
        {
            state.ReverseDirection = !state.ReverseDirection;
        }
    }
}
