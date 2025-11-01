using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;
using Uno;
using Uno.Players;

namespace Uno
{
    internal class Render
    {  
        public void RenderHand(PlayerHand hand)
        {
            int i = 0;
            foreach (var card in hand)
            {
                RenderColor(card.color);
                Console.WriteLine($"{i}: {card}, ");
                //Console.WriteLine();
                i++;
            }
            //UnoColor color = state.CurrentColor;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void RenderColor(UnoColor color)
        {
            switch (color)
            {
                case UnoColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case UnoColor.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case UnoColor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case UnoColor.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ResetColor();
                    break;
                    //lägg till att göra regnbågsfärg för wildcards
            }
        }

    }
}
