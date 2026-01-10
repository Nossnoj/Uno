using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Players;

namespace Uno.Upgrades
{
    internal class Donate : IUpgrade
    {
        public void AddUpgrade(GameState state, Player owner)
        {
            var otherPlayers = state.Players
                .Where(p => p != owner)
                .ToList();

            Console.WriteLine("Choose a player to donate to:");
            for (int i = 0; i < otherPlayers.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {otherPlayers[i].Name}");
            }

            if (!int.TryParse(Console.ReadLine(), out int playerChoice) ||
                playerChoice < 1 || playerChoice > otherPlayers.Count)
            {
                Console.WriteLine("Invalid player choice.");
                return;
            }

            Player targetPlayer = otherPlayers[playerChoice - 1];

            Console.WriteLine("Choose a card to donate:");
            for (int i = 0; i < owner.Hand.Cards.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {owner.Hand.Cards[i]}");
            }

            if (!int.TryParse(Console.ReadLine(), out int cardChoice) ||
                cardChoice < 1 || cardChoice > owner.Hand.Cards.Count)
            {
                Console.WriteLine("Invalid card choice.");
                return;
            }

            var card = owner.Hand.Cards[cardChoice - 1];
            owner.Hand.RemoveCard(card);
            targetPlayer.Hand.AddCard(card);

            Console.WriteLine($"{owner.Name} donated {card} to {targetPlayer.Name}");
        }
    }
}
