using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Players;

namespace Uno.Upgrades
{
    internal class Swap : IUpgrade
    {
        public void AddUpgrade(GameState state, Player owner)
        {
            var otherPlayers = state.Players
                .Where(p => p != owner)
                .ToList();

            Console.WriteLine("Choose a player to swap hands with:");
            for (int i = 0; i < otherPlayers.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {otherPlayers[i].Name}");
            }

            if (!int.TryParse(Console.ReadLine(), out int choice) ||
                choice < 1 || choice > otherPlayers.Count)
            {
                Console.WriteLine("Invalid player choice.");
                return;
            }

            Player targetPlayer = otherPlayers[choice - 1];

            var tempCards = owner.Hand.Cards.ToList();

            owner.Hand.Cards.ToList().ForEach(c => owner.Hand.RemoveCard(c));
            targetPlayer.Hand.Cards.ToList().ForEach(c => targetPlayer.Hand.RemoveCard(c));

            foreach (var card in targetPlayer.Hand.Cards.ToList())
                owner.Hand.AddCard(card);

            foreach (var card in tempCards)
                targetPlayer.Hand.AddCard(card);

            Console.WriteLine($"{owner.Name} swapped hands with {targetPlayer.Name}");
        }
    }
}
