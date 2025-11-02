using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno
{
    internal class AggressiveStrategy : IStrategy
    {
        public UnoCard cardToPlay(PlayerHand hand, UnoCard topCard)
        {
            /*if(topCard.Symbol == "+2" || topCard.Symbol == "Wild+4")
            {
                var stackable = hand.Cards
                    .FirstOrDefault(card => card.Symbol == "+2" || card.Symbol == "Wild+4");
                if (stackable != null)
                    return stackable;
            }*/
            var wildCards = hand.Cards
                .FirstOrDefault(card => card.Symbol == "Wild" || card.Symbol == "Wild+4");

            if (wildCards != null)
                return wildCards;

            var powerCards = hand.Cards
                .FirstOrDefault(card => card.CanPlayOn(topCard) && card.Symbol != "number");

            if (powerCards != null)
                return powerCards;

            var playableCards = hand.Cards
                .FirstOrDefault(card => card.CanPlayOn(topCard));

            if (playableCards != null)
                return playableCards;

            return null;
        }
    }
}
