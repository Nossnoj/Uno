using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Upgrades;

namespace Uno.Cards
{
    internal class PlusTwoCard : UnoCard
    {
        public PlusTwoCard(UnoColor color, IUpgrade upgrade)
            : base(color, "+2", upgrade) { }


        public override void Play(GameState state)
        {
            base.Play(state);
            state.CardsToDraw += 2;
        }
    }
}
