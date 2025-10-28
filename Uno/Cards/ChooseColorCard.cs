﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal class ChooseColorCard : UnoCard
    {
        public ChooseColorCard()
            : base(UnoColor.None, "Wild", new ChooseColorEffect()) { }
    }
}
