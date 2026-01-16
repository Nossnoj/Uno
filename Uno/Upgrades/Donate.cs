using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Uno.Upgrades
{
    internal class Donate : IUpgrade
    {
        public void AddUpgrade(GameState state)
        {
            var player = state.CurrentPlayer;

            if (state.UpgradeChosen)
            {
                int aiCardIndex = state.ChosenCardIndex;
                int aiTargetIndex = state.ChosenPlayerIndex;

                if(aiCardIndex < 0 || aiCardIndex >= player.Hand.Cards.Count)
                {
                    return;
                }

                var aiCard = player.Hand.Cards[aiCardIndex];
                player.Hand.RemoveCard(aiCard);
                state.Players[aiTargetIndex].Hand.AddCard(aiCard);

                state.UpgradeChosen = false;
                return;
            }
            
            Console.WriteLine("Choose card index to donate:");
            int cardIndex = int.Parse(Console.ReadLine()) - 1;

            if (cardIndex < 0 || cardIndex >= player.Hand.Cards.Count)
                return;

            var card = player.Hand.Cards[cardIndex];

            Console.WriteLine("Choose player index:");
            for (int i = 0; i < state.Players.Count; i++)
                Console.WriteLine($"{i}: {state.Players[i].Name}");

            int targetIndex = int.Parse(Console.ReadLine());

            if (targetIndex < 0 || state.Players[targetIndex] == player)
                return;

            player.Hand.RemoveCard(card);
            state.Players[targetIndex].Hand.AddCard(card);
        }
    }
}
