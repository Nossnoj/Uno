using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal class SkipCard : UnoCard<SkipCard, SkipEffect>
    {
        public SkipCard(UnoColor color)
            : base(color, "Skip", new SkipEffect()) { }

        public override bool CanPlayOn(UnoCard other) //kan spelas på alla nummerkort oavsett färg
        {
            return other is NumberCard || other.color == this.color;
        }
    }
}
