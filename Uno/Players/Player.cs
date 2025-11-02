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
        public Deck Deck { get; }
        protected IStrategy strategy { get; }
        public GameState state;    

        public Player(string name, IStrategy strategy, Deck deck, GameState state)
        {
            Name = name;
            this.strategy = strategy;
            Hand = new PlayerHand();
            this.Deck = deck;
            this.state = state;
            makeHand();
        }

        private void makeHand()
        {
            for (int i = 0; i < 7; i++)
            {
                Hand.AddCard(Deck.drawCard());
            }
        }
        public void DrawCard() => Hand.AddCard(Deck.drawCard());

        public abstract UnoCard playCard(PlayerHand hand, UnoCard topCard);
    }
}

