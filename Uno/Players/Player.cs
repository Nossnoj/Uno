using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
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
        public GameState state;
        private int drawCount = 0;

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
        public void DrawCard()
        {
            if(drawCount == 3)
            {
                Console.WriteLine($"{Name} has already drawn 3 cards!" );
                return;
            }

            Hand.AddCard(Deck.drawCard());
            drawCount++;
        }

        public void ResetDrawCount() => drawCount = 0;

        public abstract UnoCard playCard(PlayerHand hand, UnoCard topCard);

        public void drawPenaltyCards(string choice)
        {
            if (choice == "d")
            {
                for (int i = 0; i < state.CardsToDraw; i++)
                {
                    Hand.AddCard(Deck.drawCard());
                }
                state.CardsToDraw = 0;
            }
         
        }
    }
}

