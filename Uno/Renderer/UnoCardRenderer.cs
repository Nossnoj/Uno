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
            //test
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
            Console.Write(output);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
