using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno
{
    internal interface IStrategy
    {
        UnoCard cardToPlay(PlayerHand hand, UnoCard topCard);
    }
}
