using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class PlusTwoCard : UnoCard
    {
        public PlusTwoCard(string color)
            : base(color, "+2", new DrawTwoEffect()) { }
    }
}
