using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal class PlusFourCard : UnoCard<PlusFourCard, DrawFourEffect>
    {
        public PlusFourCard()
            : base(UnoColor.None, "Wild+4", new DrawFourEffect()) { }
        public PlusFourCard(UnoColor color)
            : base(color, "Wild+4", new DrawFourEffect()) { }

        public override bool CanPlayOn(UnoCard other)
        {
            return other.color == UnoColor.None || other.color == UnoColor.Red;
        }
    }
}
