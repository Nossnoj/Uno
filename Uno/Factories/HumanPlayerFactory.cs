using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Factories;
using Uno.Players;


namespace Uno.Factories
{
    internal class HumanPlayerFactory : IPlayerFactory
    {
        public Player createPlayer(string name, Deck deck, GameState state)
        {
            Console.WriteLine("Write your name!");
            name = Console.ReadLine();

            return new HumanPlayer(name, new NormalStrategy(), deck, state);
        }
    }
}
