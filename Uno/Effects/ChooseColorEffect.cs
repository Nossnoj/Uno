using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Effects
{
    internal class ChooseColorEffect : ICardEffect //duplicerad problem?
    {
        public void AddEffect(GameState state)
        {
            while (true)
            {
                Console.Write("Choose a color: ");
                string color = Console.ReadLine().Trim();
                if(Enum.TryParse<UnoColor>(color, true, out var chosenColor) && chosenColor != UnoColor.None)
                {
                    state.CurrentColor = chosenColor;
                    break;
                }
                Console.WriteLine("Invalid color! Try again!");
            }
        }
    }
}
