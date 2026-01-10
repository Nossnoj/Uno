using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Cards
{
    internal class ReverseCard : UnoCard
    {
        public ReverseCard(UnoColor color)
            : base(color, "Reverse") { }


        public override void Play(GameState state)
        {
            base.Play(state);   
            state.ReverseDirection = !state.ReverseDirection;
        }
    }
}
