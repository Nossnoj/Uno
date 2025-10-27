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
            string[] allowedColors = { "Red", "Blue", "Green", "Yellow" };

            while (true)
            {
                Console.Write("Choose a color: ");
                string color = Console.ReadLine().Trim();
                if (allowedColors.Contains(color, StringComparer.OrdinalIgnoreCase))
                {
                    state.CurrentColor = color;
                    break;
                }
                Console.WriteLine("Invalid color! Try again!");
            }
        }
    }
}
