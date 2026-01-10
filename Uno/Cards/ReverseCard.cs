using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Upgrades;

namespace Uno.Cards
{
    internal class ReverseCard : UnoCard
    {
        public ReverseCard(UnoColor color, IUpgrade upgrade)
            : base(color, "Reverse", upgrade) { }


        public override void Play(GameState state)
        {
            base.Play(state);   
            state.ReverseDirection = !state.ReverseDirection;
        }
    }
}
