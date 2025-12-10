using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    //Krav 1
    //1: Generics
    //2: Vi använder generiska typer UnoCard<TCard, TEffect> och ICardEffect<TCard> för att varje kort ska vara kopplat till sin specifika effekt.
    //   Detta medför flexibilitet och typsäkerhet då varje effekt vet exakt vilken korttyp den tillhör.
    //   T.ex SkipEffect implementerar ICardEffect<SkipCard> och ReverseEffect implementerar ICardEffect<ReverseCard>.
    //3: Detta gör att varje kort alltid konstrueras med rätt subtyp och korrekt effekt.
    //   Utan detta hade man kunnat skapa felaktiga kombinationer som inte borde gå att skapa.
    //   Exempelvis hade ett SkipCard kunnat skapas med en DrawTwoEffect vilket inte borde gå.
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
