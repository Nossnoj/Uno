using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno.Effects
{
    internal class DrawFourEffect : ICardEffect<PlusFourCard>
    {
        public void AddEffect(PlusFourCard card, GameState state)
        {
            GameRender renderGame = new GameRender();
            state.CardsToDraw += 4;
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
                if(int.TryParse(color, out _))
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
        }
    }
    //potentiellt skrota draw2 och draw4 och ersätta med en drawcards klass som tar in ett antal?
}
