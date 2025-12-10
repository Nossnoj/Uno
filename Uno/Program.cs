using System.Globalization;
using System.Text;
using Uno;
using Uno.Cards;
using Uno.Effects;
using Uno.Factories;

namespace Uno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPlayerFactory humanPlayerFactory = new HumanPlayerFactory();
            IPlayerFactory AIPlayerFactory = new AIPlayerFactory();
            var game = new Game(humanPlayerFactory, AIPlayerFactory);
            var state = new GameState();
        }
    }
}
