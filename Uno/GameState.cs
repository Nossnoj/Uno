using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno
{
    internal class GameState 
    {
        public UnoColor CurrentColor { get; set; }
        public bool SkipNextPlayer { get; set; }
        public bool ReverseDirection { get; set; }
        public int CardsToDraw { get; set; }
        public bool ColorChosen { get; set; }

        public void ResetSkipEffect()
        {
            SkipNextPlayer = false;
        }

        public void ClearDrawEffect()
        {
            CardsToDraw = 0;
        }
    }
}
