using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Upgrades;

namespace Uno.Cards
{
    internal class ChooseColorCard : UnoCard
    {
        public ChooseColorCard(IUpgrade upgrade)
            : base(UnoColor.None, "Wild", upgrade) { }

        public ChooseColorCard(UnoColor color, IUpgrade upgrade)
            : base(color, "Wild", upgrade) { }

        public override void Play(GameState state)
        {
            GameRender renderGame = new GameRender();
            if (state.ColorChosen)
            {
                state.ColorChosen = false;
                return;
            }
            while (true)
            {
                renderGame.RenderComment("                         ", 0);
                renderGame.RenderComment("Choose a color: ", 0);
                string color = Console.ReadLine().Trim();
                if (int.TryParse(color, out _))
                {
                    renderGame.RenderComment("Invalid input! Use a color name, not a number!", 0);
                    continue;
                }
                if (Enum.TryParse<UnoColor>(color, true, out var chosenColor) && chosenColor != UnoColor.None)
                {
                    state.CurrentColor = chosenColor;
                    break;
                }
                renderGame.RenderComment("Invalid color! Try again!", 0);

            }
            Upgrade.AddUpgrade(state);
        }
    }
}
