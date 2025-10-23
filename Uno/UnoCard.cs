using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal abstract class UnoCard
    {
        protected string Color { get; }
        public string Symbol { get; }
        private ICardEffect Effect;

        protected UnoCard(string color, string symbol, ICardEffect effect)
        {
            Color = color;
            Symbol = symbol;
            Effect = effect;
        }
    }
}
