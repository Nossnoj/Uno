using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;
using Uno.Players;
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(string name, IStrategy strategy, Deck deck) : base(name, strategy, deck) { }
        public override void playCard(UnoCard card)
        {
           
            
        }

    }
}
