using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;
using Uno.Player;

namespace Uno.Player
{
    internal abstract class Player
    {
        private List<Cards.UnoCard> hand;
        public string Name { get; }
        private Deck Deck { get; }
        protected IStrategy strategy { get; }

        public Player(string name, IStrategy strategy)
        {
            Name = name;
            hand = new List<Cards.UnoCard>();
            this.strategy = strategy;
            makeHand();
        }

        private void makeHand()
        {
            for (int i = 0; i < 7; i++)
            {
                hand.Add(Deck.drawCard());
            }
        }
        private void DrawCard() => hand.Add(Deck.drawCard());

        public abstract void playCard(UnoCard card);
        
            // Logik för att uppdatera spelets tillstånd med det spelade kortet
            // Eventuellt ha logik för att välja vilket kort som ska spelas
            //hand.Remove(card);
        
    }
}
