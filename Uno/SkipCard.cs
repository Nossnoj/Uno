using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class SkipCard : UnoCard
    {
        public SkipCard(string color)
            : base(color, "Skip", new SkipEffect()) { }
    }
}
