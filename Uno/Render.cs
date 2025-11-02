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
            int i = 1;
            foreach (var card in hand)
            {
                if(card.color == UnoColor.None && (card.Symbol == "Wild" || card.Symbol == "Wild+4"))
                {
                    Console.Write($"{i}: ");
                    RenderRainbow(card.Symbol);
                    Console.WriteLine();
                }
                else
                {
                    RenderColor(card.color);
                    Console.WriteLine($"{i}: {card}, ");
                }
                i++;
            }
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
            }
        }

        private void RenderRainbow(string text)
        {
            ConsoleColor[] rainbowColors = new[]
            {
                ConsoleColor.Red,
                ConsoleColor.Yellow,
                ConsoleColor.Green,
                ConsoleColor.Blue
            };

            for (int i = 0; i < text.Length; i++)
            {
                Console.ForegroundColor = rainbowColors[i % rainbowColors.Length];
                Console.Write(text[i]);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
