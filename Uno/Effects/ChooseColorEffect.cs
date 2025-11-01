using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno.Effects
{
    internal class ChooseColorEffect : ICardEffect<ChooseColorCard>
    {
        public void AddEffect(ChooseColorCard card, GameState state)
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
