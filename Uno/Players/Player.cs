using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;
using Uno.Players;

namespace Uno.Players
{
    internal abstract class Player
    {
        public PlayerHand Hand { get; }
        public string Name { get; }
        private Deck Deck { get; }

        public Player(string name, Deck deck)
        {
            Name = name;
            Deck = deck;
            Hand = new PlayerHand();
            makeHand();
        }

        private void makeHand()
        {
            for (int i = 0; i < 7; i++)
            {
                Hand.AddCard(Deck.drawCard());
            }
        }
        private void DrawCard() => Hand.AddCard(Deck.drawCard());
        
        private void PlayCard(UnoCard card)
        {
            // Logik för att uppdatera spelets tillstånd med det spelade kortet
            // Eventuellt ha logik för att välja vilket kort som ska spelas
            Hand.RemoveCard(card);
        }
    }
}
