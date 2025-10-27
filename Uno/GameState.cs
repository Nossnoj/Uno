using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno
{
    internal class GameState //controls the current state of the game - NOT the game itself. GameState stores the rules effects after each card is played
    {
        public string CurrentColor { get; set; }
        public bool SkipNextPlayer { get; set; }
        public bool ReverseDirection { get; set; }
        public int CardsToDraw { get; set; }

        public void ResetEffects()
        {
            SkipNextPlayer = false;
            //inte resetta CardsToDraw ifall +2 läggs på +2
        }
    }
}
