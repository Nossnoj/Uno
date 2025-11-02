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
            var tempTopCard = topCard;
            if (topCard.Symbol == "Wild+4")
            {
                tempTopCard = new PlusFourCard(state.CurrentColor);
            }
            else if (topCard.Symbol == "Wild")
            {
                tempTopCard = new ChooseColorCard(state.CurrentColor);
            }
            if (state.CardsToDraw > 0)
            {
                if (tempTopCard.Symbol == "+2" || tempTopCard.Symbol == "Wild+4" || state.CardsToDraw > 0)
                {
                    var stackable = hand.Cards.FirstOrDefault(c => c.Symbol == tempTopCard.Symbol);
                    if (stackable != null)
                    {
                        hand.RemoveCard(stackable);
                        Deck.discard.Add(stackable);
                        Console.Write($"{Name} played ");
                        render.RenderColor(stackable.color);
                        Console.WriteLine($"{stackable}");
                        Console.ForegroundColor = ConsoleColor.White;
                        return stackable;
                    }

                    drawPenaltyCards("d");
                    return null;
                }
            }
            var chosenCard = strategy.cardToPlay(hand, tempTopCard);
            if (chosenCard != null)
            {
                hand.RemoveCard(chosenCard);
                Deck.discard.Add(chosenCard);
                Console.Write($"{Name} played ");
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
                DrawCard();
                ResetUnoCall();
                return playCard(hand, topCard);
            }
        }
    }
}
