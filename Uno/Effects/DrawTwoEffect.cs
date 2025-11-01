using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno.Effects
{
    internal class DrawTwoEffect : ICardEffect<PlusTwoCard>
    {
        public void AddEffect(PlusTwoCard card, GameState state)
        {
            state.CardsToDraw += 2;
        }
    }
}
