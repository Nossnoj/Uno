using System.Globalization;
using System.Text;
using Uno;
using Uno.Cards;

namespace Uno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            //var state = new GameState();
            game.StartGame();
        }
    }
}
