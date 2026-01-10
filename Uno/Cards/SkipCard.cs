using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Cards
{
    internal class SkipCard : UnoCard
    {
        public SkipCard(UnoColor color)
            : base(color, "Skip") { }

        public override void Play(GameState state)
        {
            base.Play(state);
            state.SkipNextPlayer = true;
        }
    }
}
