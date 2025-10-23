using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class ChooseColorCard : UnoCard
    {
        public ChooseColorCard()
            : base("None", "Wild", new ChooseColorEffect()) { }
    }
}
