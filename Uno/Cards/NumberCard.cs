using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal class NumberCard : UnoCard<NumberCard, NoEffect>
    {
        public int Number { get; }
        public NumberCard(UnoColor color, string number)
            : base(color, number, new NoEffect())
        {
            Number = int.Parse(number);
        }


        public void AddEffect(GameState state)
        {

        }
    }
}
