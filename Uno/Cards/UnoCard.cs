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
    //2: Vi använder Bridge Pattern genom att dela upp korten i två hierarkier.
    //   Den ena är bara själva korten och dess effekt, den andra sidan är olika uppgraderingar.
    //3: Vi gör det för att det ska bli möjligt att skapa både vanliga kort och kort med uppgraderingar.
    //   Eftersom att varje subtyp från båda hierarkierna går att kombinera med varandra så innebär det att alla sorters kort kan få alla sorters uppgraderingar.
    //   Och det är det som är poängen!
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
