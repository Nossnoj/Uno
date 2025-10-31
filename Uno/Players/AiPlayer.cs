using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Players;
using Uno.Cards;

namespace Uno.Players
{
    internal class AiPlayer : Player
    {
        public AiPlayer(string name, IStrategy strategy, Deck deck) : base(name, strategy, deck) { }
        public override void playCard(UnoCard card)
        {

        }
    }
}
