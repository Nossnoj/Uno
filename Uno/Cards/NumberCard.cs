using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal class NumberCard : UnoCard
    {
        public NumberCard(string color, string number)
            : base(color, number, new NoEffect()) { }
    }
}
