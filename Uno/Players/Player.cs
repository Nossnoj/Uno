using Uno.Cards;
using Uno.Players;

namespace Uno
{
    internal abstract class Player
    {
        public PlayerHand Hand { get; set; } //ändrade till set också
        public string Name { get; set; }
        public Deck Deck { get; }
        public bool HasCalledUno { get; set; }
        public GameState state;
        protected int drawCount = 0;
        public IStrategy strategy;

        public Player(string name, Deck deck, GameState state)
        {
            Name = name;
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
            ResetUnoCall();
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

