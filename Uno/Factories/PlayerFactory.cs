using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Factories;
using Uno.Players;

namespace Uno.Factories
{
    internal interface IPlayerFactory
    {
        //KRAV 4
        //1: Factory Method Pattern
        //2: Vi har en abstrakt klass PlayerFactory och två konkreta subtyper; HumanPlayerFactory och AIPlayerFactory. Vi använder dessa för att skapa spelare i gameklassen.
        //3: Syftet med våran detta är att när vi skapar spelare så behöver vi inte veta hur. Game vet bara att det finns en spelare och behöver inte bry sig vilken typ eller hur den ska skapas.
        //Vi separerar skapandet och användningen av objektet. Detta ger oss möjlighet att lägga till flera typer av spelare utan att ändra någon logik. 
        public Player createPlayer(string name, Deck deck, GameState state);
    }
}
