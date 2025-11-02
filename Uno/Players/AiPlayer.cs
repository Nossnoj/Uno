using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Uno.Cards;
using Uno.Players;

namespace Uno.Players
{
    internal class AiPlayer : Player 
    {
        public AiPlayer(string name, IStrategy strategy, Deck deck, GameState state) : base(name, strategy, deck, state) { }
        public override UnoCard playCard(PlayerHand hand, UnoCard topCard)
        {
            Render render = new Render();
            string name = base.Name;
            var deck = base.Deck;
            IStrategy strategy = base.strategy;
            var chosenCard = strategy.cardToPlay(hand, topCard);
            if (chosenCard != null)
            {
                hand.RemoveCard(chosenCard);
                deck.discard.Add(chosenCard);
                Console.Write($"{name} played ");
                render.RenderColor(chosenCard.color);
                Console.WriteLine($"{chosenCard}");
                Console.ForegroundColor = ConsoleColor.White;

                if(hand.Cards.Count == 1 && !HasCalledUno)
                {
                    CallUno();
                }

                return chosenCard;
            }
            else
            {
                base.DrawCard();
                ResetUnoCall();
                return playCard(hand, topCard);
            }
        }
    }
}
