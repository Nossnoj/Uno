using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno
{
    internal class NormalStrategy : IStrategy
    {
        public UnoCard cardToPlay(PlayerHand hand, UnoCard topCard)
        {
            var playableCards = hand.Cards
                .FirstOrDefault(card => card.CanPlayOn(topCard));

            if (playableCards != null)
                return playableCards;

            return null;

            //kanske lägga till lite mer logik här senare
            //lägga till så att om man har flera av liknande kort så kan man lägga ner dem
        }
    }
}
