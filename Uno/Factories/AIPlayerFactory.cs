using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Factories;
using Uno.Players;

namespace Uno.Factories
{
    internal class AIPlayerFactory : IPlayerFactory
    {
        public Player createPlayer(string name, Deck deck, GameState state)
        {
            string newname;
            Random rand = new Random();
            if(rand.Next(0, 2) == 0)
            {
                newname = "Aggressive AI " + name;
                return new AiPlayer(newname, new AggressiveStrategy(), deck, state);
            }
            else
            {
                newname = "Normal AI " + name;
                return new AiPlayer(newname, new NormalStrategy(), deck, state);
            }

        }
    }
}
