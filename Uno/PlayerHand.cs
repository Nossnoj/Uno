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
    //2: Vi implementerar IEnumerable<UnoCard> i PlayerHand för att göra spelarens hand itererbar,
    //   så att vi kan använda foreach direkt i handen.
    //3: Vi använder det för att separera ansvaret. Player behöver inte veta hur handen lagrar korten.
    //   PlayerHand blir mer som en abstraktion som representerar en spelares hand i spelet som gör koden lättare att utöka utan att ändra spelets logik.
    internal class PlayerHand : IEnumerable<UnoCard>
    {
        private List<UnoCard> cards = new();
        public IReadOnlyList<UnoCard> Cards => cards; 

        public void AddCard(UnoCard card) => cards.Add(card);
        public void RemoveCard(UnoCard card) => cards.Remove(card);

        public void Clear() => cards.Clear();
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
