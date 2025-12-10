using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal class ChooseColorCard : UnoCard<ChooseColorCard, ChooseColorEffect>
    {
        public ChooseColorCard()
            : base(UnoColor.None, "Wild", new ChooseColorEffect()) { }
        public ChooseColorCard(UnoColor color)
            : base(color, "Wild", new ChooseColorEffect()) { }

        public override bool CanPlayOn(UnoCard other)
        {
            return true;
        }
    }
}
