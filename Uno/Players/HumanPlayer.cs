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
        public HumanPlayer(string name, IStrategy strategy, Deck deck) : base(name, strategy, deck) { }
        public override UnoCard playCard(PlayerHand hand, UnoCard topCard)
        {
            string name = base.Name;
            var deck = base.Deck;
            Render render = new Render();
            render.RenderHand(hand);
            string position = Console.ReadLine();
            if (int.TryParse(position, out int positionIndex) && positionIndex >= 0 && positionIndex < hand.Cards.Count)
            {
                positionIndex -= 1;
                UnoCard chosenCard = hand.Cards[positionIndex];
                if (chosenCard.CanPlayOn(topCard))
                {
                    hand.RemoveCard(chosenCard);
                    deck.discard.Add(chosenCard);
                    Console.WriteLine($"{name} played {chosenCard}");
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
                hand.AddCard(deck.drawCard());
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
