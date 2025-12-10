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

        public override bool CanPlayOn(UnoCard other)
        {
            return other.color == this.color || other is PlusTwoCard;
        }
    }
}
