using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal abstract class UnoCard
    {
        protected UnoColor Color { get; }
        public string Symbol { get; }
        private ICardEffect Effect;

        protected UnoCard(UnoColor color, string symbol, ICardEffect effect)
        {
            Color = color;
            Symbol = symbol;
            Effect = effect;
        }

        public bool CanPlayOn(UnoCard other)
        {
            if(Color == UnoColor.None) //dvs ifall ett kort antingen är +4 eller ChooseColorCard
            {
                return true;
            }

            return this.Color == other.Color || this.Symbol == other.Symbol;
        }

        public void Play(GameState state)
        {
            if(Color != UnoColor.None)
            {
                state.CurrentColor = Color;
            }
            Effect.AddEffect(state);
        }

        public override string ToString()
            => $"{Color} {Symbol}";
    }
}
