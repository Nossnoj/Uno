using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno
{
    //Krav 2
    //1: Strategy Pattern
    //2: Vi använder Strategy Pattern genom interfacet IStrategy som definierar hur en spelare väljer kort.
    //   NormalStrategy gör så att spelaren väljer sitt första giltiga kort medan AggressiveStrategy prioriterar
    //   specialkort som +2, Reverse, Skip osv över nummerkort.
    //   Strategierna injiceras i Player klassen vilket gör att varje spelare får sitt egna beteendemönster.
    //3: Vi använder detta för att separera spelbeslutslogik från spelaren och möjliggöra olika beteenden. 
    //   Koden blir också mer flexibel och vi skulle kunna implementera fler strategier enkelt utan att behöva
    //   ändra spelets kärnlogik.
    internal interface IStrategy
    {
        UnoCard cardToPlay(PlayerHand hand, UnoCard topCard);
    }
}
