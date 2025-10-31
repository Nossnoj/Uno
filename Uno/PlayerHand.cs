using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno
{
    //Krav 5
    //1: Enumerable & Enumerator
    //2: 
    internal class PlayerHand : IEnumerable<UnoCard>
    {
        private List<UnoCard> cards = new();

        public void AddCard(UnoCard card) => cards.Add(card);
        public void RemoveCard(UnoCard card) => cards.Remove(card);
        public IEnumerator<UnoCard> GetEnumerator()
        {
            return cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
