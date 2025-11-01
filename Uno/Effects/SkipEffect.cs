using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno.Effects
{
    internal class SkipEffect : ICardEffect<SkipCard>
    {
        public void AddEffect(SkipCard card, GameState state)
        {
            state.SkipNextPlayer = true;
        }
    }
}
