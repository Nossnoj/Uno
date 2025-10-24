using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal class SkipCard : UnoCard
    {
        public SkipCard(string color)
            : base(color, "Skip", new SkipEffect()) { }
    }
}
