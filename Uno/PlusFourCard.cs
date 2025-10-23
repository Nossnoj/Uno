using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class PlusFourCard : UnoCard
    {
        public PlusFourCard()
            : base("None", "Wild+4", new DrawFourEffect()) { }
    }
}
