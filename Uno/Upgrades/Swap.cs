using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Upgrades
{
    internal class Swap : IUpgrade
    {
        public void AddUpgrade(GameState state)
        {
            var player = state.CurrentPlayer;

            Console.WriteLine("Choose player to swap with:");
            for (int i = 0; i < state.Players.Count; i++)
                Console.WriteLine($"{i}: {state.Players[i].Name}");

            int targetIndex = int.Parse(Console.ReadLine());
            var target = state.Players[targetIndex];

            var temp = player.Hand.Cards.ToList();

            player.Hand.Clear();
            target.Hand.Clear();

            foreach (var c in temp)
                target.Hand.AddCard(c);
        }
    }
}
