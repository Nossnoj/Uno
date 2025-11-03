using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Effects;

namespace Uno.Cards
{
    //KRAV 3:
    //1: Bridge Pattern
    //2: Vi använder Bridge Pattern genom att separera kortets abstraktion (UnoCard) från dess effekt (ICardEffect).
    //   Varje kort har en färg och symbol (abstraktion) men kan kopplas till olika effekter (konkreta implementationer).
    //3: Vi gör det för att det ska bli möjligt att skapa nya kort och effekter oberoende av varandra.
    internal abstract class UnoCard
    {
        protected UnoColor Color { get; }
        public UnoColor color => Color;
        public string Symbol { get; }
        private object effect;

        protected UnoCard(UnoColor color, string symbol, object effect)
        {
            Color = color;
            Symbol = symbol;
            this.effect = effect;
        }

        public bool CanPlayOn(UnoCard other)
        {
            if(Color == UnoColor.None) 
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

            dynamic dynamicEffect = effect;
            dynamicEffect.AddEffect((dynamic)this, state);
        }

        public override string ToString()
            => $"{Symbol}";
    }
}
