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
            string position = Console.ReadLine();
            if (int.TryParse(position, out int positionIndex) && positionIndex >= 1 && positionIndex < hand.Cards.Count+1)
            {
                positionIndex -= 1;
                UnoCard chosenCard = hand.Cards[positionIndex];
                if (chosenCard.CanPlayOn(topCard))
                {
                    hand.RemoveCard(chosenCard);
                    deck.discard.Add(chosenCard);
                    Console.Write($"{name} played ");
                    render.RenderColor(chosenCard.color);
                    Console.WriteLine($"{chosenCard}");
                    Console.ForegroundColor = ConsoleColor.White;
                    return chosenCard;
                }
                else
                {
                    Console.WriteLine("You can't play that card! Try again.");
                    return playCard(hand, topCard);
                }
            }
            else if (position.ToLower() == "d")
            {
                base.DrawCard();
                return playCard(hand, topCard);
            }
            else
            {
                Console.WriteLine("Invalid input! Try again.");
                return playCard(hand, topCard);
            }
        }

    }
}
