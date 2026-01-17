using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Uno.Cards;
using Uno.Players;
using Uno.Renderer;

namespace Uno
{
    internal class GameRender
    {
        string comment;
        Render render = new Render();
        public void RenderHands(List<Player> playerList)
        {
            Console.Clear();
            int centerX = Console.WindowWidth / 2;
            Console.SetCursorPosition(centerX - 3, 1);

            for (int p = 0; p < playerList.Count; p++)
            {
                var player = playerList[p];
                int cardCount = player.Hand.Cards.Count;
                //Render render = new Render();
                string cards = string.Join(" ", Enumerable.Repeat("■", cardCount));

                switch (p)
                {
                    case 2: 
                        Console.SetCursorPosition(centerX - cards.Length / 2 - 2, 2);
                        Console.Write(cards);
                        Console.SetCursorPosition(centerX - player.Name.Length / 2 - 1, 3);
                        Console.Write(player.Name);
                        break;

                    case 1: 
                        for (int i = 0; i < cardCount; i++)
                        {
                            Console.SetCursorPosition(2, 18 + i);
                            Console.Write("■");
                        }
                        Console.SetCursorPosition(2, 18 + cardCount + 1);
                        Console.Write(player.Name);
                        break;

                    case 3: 
                        for (int i = 0; i < cardCount; i++)
                        {
                            Console.SetCursorPosition(Console.WindowWidth - 4, 18 + i);
                            Console.Write("■");
                        }
                        Console.SetCursorPosition(Console.WindowWidth - 3 - player.Name.Length, 18 + cardCount + 1);
                        Console.Write(player.Name);
                        break;

                    case 0: 
                        RenderHand(player.Hand);
                        break;
                }
            }
        }
        public void RenderHand(PlayerHand hand)
        {
            int cardCount = hand.Cards.Count;
            int centerX = Console.WindowWidth / 2;
            int handY = Console.WindowHeight - 3;
            Console.SetCursorPosition(0, handY - 7);
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.SetCursorPosition(centerX, handY - 2);
            
            Console.SetCursorPosition(centerX - cardCount / 2 - 20, handY);
            render.RenderHand(hand);
            if(comment != null)
                Console.SetCursorPosition(Math.Max(0, (Console.WindowWidth-comment.Length) / 2), Console.WindowHeight - 6);

        }
        public void RenderTopCard(UnoCard topCard, GameState state)
        {
            int centerX = Console.WindowWidth / 2;
            Console.SetCursorPosition(centerX - 7, Console.WindowHeight / 2-11);
            Console.Write("Top Card:");
            Console.SetCursorPosition(centerX - 3, Console.WindowHeight / 2-10);
            render.RenderItem<UnoCard>(new UnoCardRenderer(), topCard);
            /*if (topCard.Color == UnoColor.None)
            {
                UnoColor color = state.CurrentColor;
                render.RenderColor(color);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                render.RenderColor(topCard.Color);
            }
            Console.Write($"{topCard}");
            Console.ForegroundColor = ConsoleColor.White;*/
        }
        public void RenderComment(string comment, int i)
        {
            this.comment = comment;
            int commentRow = Console.WindowHeight - 5; 
            int posX = Math.Max(0, (Console.WindowWidth - comment.Length) / 2);

            Console.SetCursorPosition(0, commentRow-7);
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.SetCursorPosition(posX, commentRow - 2);

            render.RenderItem<string>(new StringRenderer(), comment);
        }

    }
}
