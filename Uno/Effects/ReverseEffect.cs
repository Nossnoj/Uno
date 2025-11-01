using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno.Effects
{
    internal class ReverseEffect : ICardEffect<ReverseCard>
    {
        public void AddEffect(ReverseCard card, GameState state)
        {
            state.ReverseDirection = !state.ReverseDirection;
        }
    }
}
