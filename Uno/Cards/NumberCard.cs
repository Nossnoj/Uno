using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Cards
{
    internal class NumberCard : UnoCard
    {
        public int Number { get; }
        public NumberCard(UnoColor color, string number)
            : base(color, number)
        {
            Number = int.Parse(number);
        }


        public override void Play(GameState state)
        {
            //behövs ens?
        }
    }
}
