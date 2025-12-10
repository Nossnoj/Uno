using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno.Effects
{
    internal interface ICardEffect<TCard> where TCard : UnoCard
    {
        void AddEffect(TCard card, GameState state);
    }
}
