using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                var stackable = hand.Cards.FirstOrDefault(c => c.Symbol == tempTopCard.Symbol);
                if (stackable != null)
                {
                    playlogic(hand, stackable);
                }
                Console.WriteLine($"{Name} draws {state.CardsToDraw} cards.");
                drawPenaltyCards("d");
                return null;
            }
            var chosenCard = strategy.cardToPlay(hand, tempTopCard);
            if (chosenCard != null)
            {
                playlogic(hand, chosenCard);

                if (hand.Cards.Count == 1 && !HasCalledUno)
                {
                    CallUno();
                }

                    return chosenCard;
                }
                DrawCard();
                ResetUnoCall();
                return playCard(hand, topCard);
            }
        }
        private void chooseColor(UnoCard card)
        {
            if (card.Symbol == "Wild+4" || card.Symbol == "Wild")
            {
                var colorChoice = Hand.Cards
                .Where(c => c.color != UnoColor.None)
                .GroupBy(c => c.color)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
                if (colorChoice == UnoColor.None)
                    colorChoice = UnoColor.Red;
                state.CurrentColor = colorChoice;
                state.ColorChosen = true;
            }
        }
        private void playlogic(PlayerHand hand, UnoCard card)
        {
            Render render = new Render();
            chooseColor(card);
            hand.RemoveCard(card);
            Deck.discard.Add(card);
            Console.Write($"{Name} played ");
            render.RenderColor(card.color);
            Console.WriteLine($"{card}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
