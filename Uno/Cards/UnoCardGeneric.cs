using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    internal class UnoCard<TCard, TEffect> : UnoCard
        where TCard : UnoCard<TCard, TEffect>
        where TEffect : ICardEffect<TCard>
    {
        protected readonly TEffect effect;

        protected UnoCard(UnoColor color, string symbol, TEffect effect)
            : base(color, symbol)
        {
            this.effect = effect;
        }

        public override void Play(GameState state)
        {
            if (Color != UnoColor.None)
                state.CurrentColor = Color;

            effect.AddEffect((TCard)this, state);
        }
    }
}
