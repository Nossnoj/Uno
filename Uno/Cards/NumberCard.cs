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

        public override bool CanPlayOn(UnoCard other)
        {
            if(other is NumberCard n)
            {
                int topNumber = n.Number;

                if(Number == 0)
                {
                    return true;
                }
                else if ((Number > topNumber && this.color == other.color) || (Number == topNumber))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return base.CanPlayOn(other);
        }
    }
}
