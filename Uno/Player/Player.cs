using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;
using Uno.Player;

namespace Uno.Player
{
    internal class Player
    {
        private List<Cards.UnoCard> hand;
        public string Name { get; }
        private Deck Deck { get; }

        public Player(string name, Deck deck)
        {
            Name = name;
            hand = new List<Cards.UnoCard>();
            makeHand();
        }

        private void makeHand()
        {
            for (int i = 0; i < 7; i++)
            {
                hand.Add(Deck.DrawCard());
            }
        }
        private void DrawCard() => hand.Add(Deck.DrawCard());
        
        private void PlayCard(Cards.UnoCard card)
        {
            // Logik för att uppdatera spelets tillstånd med det spelade kortet
            // Eventuellt ha logik för att välja vilket kort som ska spelas
            hand.Remove(card);
        }
    }
}
