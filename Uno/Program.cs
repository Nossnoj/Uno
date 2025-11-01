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
            
            var testCard1 = new NumberCard(UnoColor.Red, "1");
            var testCard2 = new NumberCard(UnoColor.Red, "6");
            var testCard3 = new NumberCard(UnoColor.Blue, "1");
            var testCard4 = new NumberCard(UnoColor.Green, "2");
            var testCard5 = new ReverseCard(UnoColor.Green);
            var testCard6 = new ReverseCard(UnoColor.Blue);
            var testCard7 = new PlusFourCard();
            var testCard8 = new SkipCard(UnoColor.Red);
            var testCard9 = new ChooseColorCard();
            var testCard10 = new NumberCard(UnoColor.Red, "9");

            bool result1 = testCard2.CanPlayOn(testCard1); 
            bool result2 = testCard3.CanPlayOn(testCard1);
            bool result3 = testCard4.CanPlayOn(testCard1);
            bool result4 = testCard5.CanPlayOn(testCard4);
            bool result5 = testCard6.CanPlayOn(testCard5);

            
            var state = new GameState();
            Game game = new Game();
            testCard1.Play(state);
            game.NextPlayer();
            testCard2.Play(state);
            game.NextPlayer();
            testCard5.Play(state);
            game.NextPlayer();
            testCard10.Play(state);
            game.NextPlayer();

            

            Console.WriteLine();
        }
    }
}
