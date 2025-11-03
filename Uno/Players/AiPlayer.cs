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
        GameRender renderGame = new GameRender();
        public AiPlayer(string name, IStrategy strategy, Deck deck, GameState state) : base(name, strategy, deck, state) { }
        public override UnoCard playCard(PlayerHand hand, UnoCard topCard)
        {
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
                    chooseColor(stackable);
                    playlogic(hand, stackable);
                }
                renderGame.RenderComment($"{Name} draws {state.CardsToDraw} cards.", 0);
                Thread.Sleep(3000);
                drawPenaltyCards("d");
                return null;
            }
            while (drawCount < 3)
            {
                var chosenCard = strategy.cardToPlay(hand, tempTopCard);
                if (chosenCard != null)
                {
                    chooseColor(chosenCard);
                    playlogic(hand, chosenCard);

                    if (hand.Cards.Count == 1 && !HasCalledUno)
                    {
                        CallUno();
                    }

                    return chosenCard;
                }
                DrawCard();
                renderGame.RenderComment($"{Name} drew card!", 0);
                Thread.Sleep(3000);
            }
            ResetUnoCall();
            renderGame.RenderComment($"{Name} drew 3 cards but could not play!", 0);
            Thread.Sleep(3000);
            return null;
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
            hand.RemoveCard(card);
            Deck.discard.Add(card);
            renderGame.RenderComment($"{Name} played {card}!", 0);
            Thread.Sleep(3000);
        }
    }
}
