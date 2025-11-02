using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Players;
using Uno.Cards;
using System.Numerics;

namespace Uno.Players
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(string name, IStrategy strategy, Deck deck, GameState state) : base(name, strategy, deck, state) { }
        public override UnoCard playCard(PlayerHand hand, UnoCard topCard)
        {
            var state = base.state;
            string name = base.Name;
            var deck = base.Deck;
            Render render = new Render();
            render.RenderHand(hand);
            Console.WriteLine("Select a card number to play, or type 'd' to draw a new card from the deck!");
            string position = Console.ReadLine();

            if (position.ToLower() == "d")
            {
                base.DrawCard();
                Console.WriteLine($"{name} drew a card!");
                return playCard(hand, topCard);
            }

            if (int.TryParse(position, out int positionIndex) && positionIndex >= 1 && positionIndex < hand.Cards.Count + 1)
            {
                positionIndex -= 1;
                UnoCard chosenCard = hand.Cards[positionIndex];

                if (!chosenCard.CanPlayOn(topCard))
                {
                    Console.WriteLine("You can't play that card! Try again.");
                    return playCard(hand, topCard);
                }

                hand.RemoveCard(chosenCard);
                deck.discard.Add(chosenCard);
                Console.Write($"{name} played ");
                render.RenderColor(chosenCard.color);
                Console.WriteLine($"{chosenCard}");
                Console.ForegroundColor = ConsoleColor.White;

                if (hand.Cards.Count == 1 && !HasCalledUno)
                {
                    string unoCall = Console.ReadLine().Trim().ToLower();

                    if(unoCall == "uno")
                    {
                        CallUno();
                    }
                    else
                    {
                        Console.WriteLine("You forgot to call UNO!");
                        Console.WriteLine("Drawing 2 penalty cards!");
                        hand.AddCard(deck.drawCard());
                        hand.AddCard(deck.drawCard());
                    }
                }

                return chosenCard;   
                    
                }
            else
            {
                Console.WriteLine("Invalid input! Try again.");
                return playCard(hand, topCard);
            }
        }
    }
}
