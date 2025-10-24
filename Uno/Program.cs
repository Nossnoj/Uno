using System.Globalization;
using Uno;
using Uno.Cards;
using Uno.Effects;

namespace Uno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var card = new NumberCard("red", "5");
            var card1 = new SkipCard("blue");
            var card2 = new ReverseCard("yellow");
            var card3 = new PlusTwoCard("green");
            var card4 = new PlusFourCard();
            var card5 = new ChooseColorCard();
            Console.WriteLine();
        }
    }
}
