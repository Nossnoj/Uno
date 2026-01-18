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
        public void AddUpgrade(GameState state)
        {
            GameRender gameRender = new GameRender();
            var currentPlayer = state.CurrentPlayer;

            if (state.UpgradeChosen)
            {
                int aiTargetIndex = state.ChosenPlayerIndex;
                var aiTargetPlayer = state.Players[aiTargetIndex];

                var aiCurrentCards = currentPlayer.Hand.Cards.ToList();
                var aiTargetCards = aiTargetPlayer.Hand.Cards.ToList();

                currentPlayer.Hand.Clear();
                aiTargetPlayer.Hand.Clear();

                foreach(var c in aiTargetCards)
                    currentPlayer.Hand.AddCard(c);

                foreach (var c in aiCurrentCards)
                    aiTargetPlayer.Hand.AddCard(c);

                state.UpgradeChosen = false;
                return;
            }

            string choices = string.Empty;
            for (int i = 0; i < state.Players.Count; i++)
            {
                if (state.Players[i] != currentPlayer)
                {
                    choices += $"{i}: {state.Players[i].Name} ({state.Players[i].Hand.Cards.Count} cards)\n";
                    //Problemet är att när vi gör en ny rad så skrivs det inte i mitten utan på sidan!!! fixat tror jag :)
                }
            }
            gameRender.RenderUpgrade("Choose player to swap with:", choices);

            int targetIndex;
            while (!int.TryParse(Console.ReadLine(), out targetIndex)
                   || targetIndex < 0
                   || targetIndex >= state.Players.Count 
                   || state.Players[targetIndex] == currentPlayer)
            {
                gameRender.RenderComment("Invalid choice, try again.", 0);
            }

            var targetPlayer = state.Players[targetIndex];


            var currentCards = currentPlayer.Hand.Cards.ToList();
            var targetCards = targetPlayer.Hand.Cards.ToList();

            currentPlayer.Hand.Clear();
            targetPlayer.Hand.Clear();
           

            foreach (var c in targetCards)
                currentPlayer.Hand.AddCard(c);

            foreach (var c in currentCards)
                targetPlayer.Hand.AddCard(c);

            gameRender.RenderComment($"{currentPlayer.Name} swapped hands with {targetPlayer.Name}!", 0);
        }
    }
}
