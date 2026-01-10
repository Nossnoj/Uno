using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Cards
{
    internal class PlusTwoCard : UnoCard
    {
        public PlusTwoCard(UnoColor color)
            : base(color, "+2") { }


        public override void Play(GameState state)
        {
            base.Play(state);
            state.CardsToDraw += 2;
        }
    }
}
