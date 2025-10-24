using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal class ReverseCard : UnoCard
    {
        public ReverseCard(string color)
            : base(color, "Reverse", new ReverseEffect()) { }
    }
}
