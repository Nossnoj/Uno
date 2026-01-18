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
            GameRender gameRender = new GameRender();
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
            
            gameRender.RenderComment("Choose card index to donate:", 0);
            int cardIndex = int.Parse(Console.ReadLine()) - 1;
            string choices = string.Empty;

            if (cardIndex < 0 || cardIndex >= player.Hand.Cards.Count)
                return;

            var card = player.Hand.Cards[cardIndex];

            for (int i = 0; i < state.Players.Count; i++)
                choices += $"{i}: {state.Players[i].Name}\n";

            gameRender.RenderUpgrade("Choose player index:", choices);


            int targetIndex = int.Parse(Console.ReadLine());

            if (targetIndex < 0 || state.Players[targetIndex] == player)
                return;

            player.Hand.RemoveCard(card);
            state.Players[targetIndex].Hand.AddCard(card);
        }
    }
}
