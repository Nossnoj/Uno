using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal class PlusTwoCard : UnoCard<PlusTwoCard, DrawTwoEffect>
    {
        public PlusTwoCard(UnoColor color)
            : base(color, "+2", new DrawTwoEffect()) { }


        public void AddEffect(GameState state)
        {
            state.CardsToDraw += 2;
        }
    }
}
