using System.Drawing;
using Uno.Cards;
using Uno.Upgrades;

namespace Uno.Renderer
{
    internal class UnoCardRenderer : IRenderer<UnoCard>
    {
        public void Render(UnoCard card)
        {
            string output = card.Symbol;
            switch (card.Upgrade)
            {
                case Swap:
                    output += " Swap";
                    break;
                case Donate:
                    output += " Donate";
                    break;
                default:
                    break;
            }
            UnoColor color = card.Color;
            switch (color)
            {
                case UnoColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(output);
                    break;
                case UnoColor.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(output);
                    break;
                case UnoColor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(output);
                    break;
                case UnoColor.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(output);
                    break;
                default:
                    RenderRainbow(card.Symbol);
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
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
