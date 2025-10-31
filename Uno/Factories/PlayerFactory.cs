using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Factories;
using Uno.Players;
{
    
}


namespace Uno.Factories
{
    internal abstract class PlayerFactory
    {
        public abstract Player createPlayer(string name, IStrategy strategy, Deck deck);
    }
}
