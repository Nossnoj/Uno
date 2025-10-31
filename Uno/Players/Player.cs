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
        protected IStrategy strategy { get; }

        public Player(string name, IStrategy strategy, Deck Deck)
        {
            Name = name;
            this.strategy = strategy;
            Hand = new PlayerHand();
            this.Deck = Deck;
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

        public abstract void playCard(UnoCard card);
}

