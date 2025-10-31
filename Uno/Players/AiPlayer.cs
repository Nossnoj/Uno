using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Player;
using Uno.Cards;

namespace Uno.Players
{
    internal class AiPlayer : Player
    {
        public AiPlayer(string name, IStrategy strategy) : base(name, strategy) { }
        public override void playCard(UnoCard card)
        {

        }
    }
}
