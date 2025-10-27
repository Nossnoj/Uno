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
            /*
            var card = new NumberCard("red", "5");
            var card1 = new SkipCard("blue");
            var card2 = new ReverseCard("yellow");
            var card3 = new PlusTwoCard("green");
            var card4 = new PlusFourCard();
            var card5 = new ChooseColorCard();
            */

            var testCard1 = new NumberCard("red", "1");
            var testCard2 = new NumberCard("Red", "6");
            var testCard3 = new NumberCard("blue", "1");
            var testCard4 = new NumberCard("green", "2");
            var testCard5 = new ReverseCard("green");
            var testCard6 = new ReverseCard("blue");
            var testCard7 = new PlusFourCard();
            var testCard8 = new SkipCard("red");
            var testCard9 = new ChooseColorCard();

            bool result1 = testCard2.CanPlayOn(testCard1); //BLIR FALSE EFTERSOM red != Red
            bool result2 = testCard3.CanPlayOn(testCard1);
            bool result3 = testCard4.CanPlayOn(testCard1);
            bool result4 = testCard5.CanPlayOn(testCard4);
            bool result5 = testCard6.CanPlayOn(testCard5);

            var state = new GameState();
            testCard8.Play(state);
            Console.WriteLine();
        }
    }
}
