using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Effects
{
    internal class DrawFourEffect : ICardEffect //duplicerad problem?
    {
        public void AddEffect(GameState state)
        {
            state.CardsToDraw += 4;
            Console.Write("Choose a color: ");
            string color = Console.ReadLine(); //validera färg
            state.CurrentColor = color;
        }
    }
    //potentiellt skrota draw2 och draw4 och ersätta med en drawcards klass som tar in ett antal?
}
