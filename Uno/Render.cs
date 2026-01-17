using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno;
using Uno.Cards;
using Uno.Players;
using Uno.Renderer;

namespace Uno
{
    internal class Render
    {

        public void RenderItem<T> (IRenderer<T> renderer, T item)
        {
            renderer.Render(item);
        }
        public void RenderHand(PlayerHand hand)
        {
            int i = 1;
            foreach (var card in hand)
            {
                if(card.Color == UnoColor.None && (card.Symbol == "Wild" || card.Symbol == "Wild+4"))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{i}: ");
                    RenderRainbow(card.Symbol);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{i}: ");
                    RenderColor(card.Color);
                    Console.Write($"{card}, ");
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
            Console.Write(" ");

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
