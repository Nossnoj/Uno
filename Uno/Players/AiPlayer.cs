using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Uno.Cards;
using Uno.Players;

namespace Uno.Players
{
    internal class AiPlayer : Player 
    {
        public AiPlayer(string name, IStrategy strategy, Deck deck) : base(name, strategy, deck) { }
        public override UnoCard playCard(PlayerHand hand, UnoCard topCard)
        {
            string name = base.Name;
            var deck = base.Deck;
            IStrategy strategy = base.strategy;
            var chosenCard = strategy.cardToPlay(hand, topCard);
            if (chosenCard != null)
            {
                hand.RemoveCard(chosenCard);
                deck.discard.Add(chosenCard);
                Console.WriteLine($"{name} played {chosenCard}");
                return chosenCard;
            }
            else
            {
                hand.AddCard(deck.drawCard());
                return playCard(hand, topCard);
            }
        }
    } //ska automatiskt säga UNO vid 1 kort
}
