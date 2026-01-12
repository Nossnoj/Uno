using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Upgrades;

namespace Uno.Cards
{
    internal class NumberCard : UnoCard
    {
        public int Number { get; }
        public NumberCard(UnoColor color, string number, IUpgrade upgrade)
            : base(color, number, upgrade)
        {
            Number = int.Parse(number);
        }

        public override void Play(GameState state)
        {
            base.Play(state);
        }
    }
}
