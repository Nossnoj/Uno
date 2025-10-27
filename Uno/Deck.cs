using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno
{
    internal class Deck
    {
        private List<UnoCard> cards;
        public Deck()
        {
            cards = new List<UnoCard>();
        }
        public UnoCard DrawCard()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("The deck is empty.");
            }
            UnoCard drawnCard = cards[0];
            cards.RemoveAt(0);
            return drawnCard;
        }
        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                UnoCard temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
        }
    }
}
