using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Players;
using Uno.Cards;
{
    internal class AiPlayer : Players
    {
        public AiPlayer(string name, IStrategy strategy) : base(name, strategy) { }
        public override void playCard(UnoCard card)
        {

        }
    }
}
