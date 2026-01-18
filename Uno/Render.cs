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
                    Console.Write($" {i}: ");
                    RenderItem<UnoCard>(new UnoCardRenderer(), card);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($" {i}: ");
                    RenderItem<UnoCard>(new UnoCardRenderer(), card); ;
                }
                i++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        
    }
}
