using System.Globalization;
using Uno;

namespace Uno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Han tar en nuuuuus");
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
