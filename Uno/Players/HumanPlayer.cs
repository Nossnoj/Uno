using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;
using Uno.Players;

namespace Uno.Players
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(string name, IStrategy strategy) : base(name, strategy) { }
        public override void playCard(UnoCard card)
        {
           
            
        }

    }
}
