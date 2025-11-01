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
        public List<UnoCard> discard;
        public Deck()
        {
            cards = new List<UnoCard>();
        }
        public UnoCard drawCard()
        {
            if (cards.Count == 0)
            {
                cards = discard.ToList();
                discard.Clear();
                Shuffle(cards);
            }
            UnoCard drawnCard = cards[0];
            cards.RemoveAt(0);
            discard.Add(drawnCard);
            return drawnCard;
        }
        public void Shuffle(List<UnoCard> deck)
        {
            Random rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                UnoCard temp = deck[n];
                cards[n] = deck[k];
                cards[k] = temp;
            }
        }
    }
}
