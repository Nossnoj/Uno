using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Upgrades;

namespace Uno.Cards
{
    //KRAV 3:
    //1: Bridge Pattern
    //2: Vi använder Bridge Pattern genom att separera kortets abstraktion (UnoCard) från dess effekt (ICardEffect).
    //   Varje kort har en färg och symbol (abstraktion) men kan kopplas till olika effekter (konkreta implementationer).
    //3: Vi gör det för att det ska bli möjligt att skapa nya kort och effekter oberoende av varandra.
    internal abstract class UnoCard
    {
        public UnoColor Color { get; }
        public string Symbol { get; }

        public IUpgrade Upgrade;

        protected UnoCard(UnoColor color, string symbol, IUpgrade upgrade)
        {
            Color = color;
            Symbol = symbol;
            Upgrade = upgrade;
        }

        public bool CanPlayOn(UnoCard other)
        {
            if(Color == UnoColor.None) 
            {
                return true;
            }

            return this.Color == other.Color || this.Symbol == other.Symbol;
        }

        public virtual void Play(GameState state)
        {
            if(Color != UnoColor.None)
            {
                state.CurrentColor = Color;
            }
             
            Upgrade.AddUpgrade(state);
        }

        public override string ToString()
            => $"{Symbol}";
    }
}
