using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Upgrades;

namespace Uno.Cards
{
    internal class SkipCard : UnoCard
    {
        public SkipCard(UnoColor color, IUpgrade upgrade)
            : base(color, "Skip", upgrade) { }

        public override void Play(GameState state)
        {
            base.Play(state);
            state.SkipNextPlayer = true;
        }
    }
}
