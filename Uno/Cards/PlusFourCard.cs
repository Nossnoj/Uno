using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal class PlusFourCard : UnoCard
    {
        public PlusFourCard()
            : base("None", "Wild+4", new DrawFourEffect()) { }
    }
}
