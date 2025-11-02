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
        public bool HasCalledUno { get; set; }

        public Player(string name, IStrategy strategy, Deck deck)
        {
            Name = name;
            this.strategy = strategy;
            Hand = new PlayerHand();
            this.Deck = deck;
            makeHand();
        }

        private void makeHand()
        {
            for (int i = 0; i < 2; i++)
            {
                Hand.AddCard(Deck.drawCard());
            }
        }

        public void CallUno()
        {
            if(Hand.Cards.Count == 1)
            {
                HasCalledUno = true;
                Console.WriteLine($"{Name} calls UNO!");
            }
            else
            {
                Console.WriteLine("You can't call UNO right now!");
            }
        }

        public void ResetUnoCall() => HasCalledUno = false;
        private void DrawCard() => Hand.AddCard(Deck.drawCard());

        public abstract UnoCard playCard(PlayerHand hand, UnoCard topCard);
    }
}

