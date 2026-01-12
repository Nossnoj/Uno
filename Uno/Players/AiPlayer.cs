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
using Uno.Upgrades;

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
                tempTopCard = new PlusFourCard(state.CurrentColor, new NoUpgrade());
            }
            else if (topCard.Symbol == "Wild")
            {
                tempTopCard = new ChooseColorCard(state.CurrentColor, new NoUpgrade());
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
                //KRAV 6:
                //1: LINQ
                //2: Med LINQ kan vi ta listan med kort ur handen och , filtrera bort färglösa kort (Wild Cards), gruppera de kvarstående korten efter färg,
                // sortera grupperna i fallande ordning där de grupper med flest kort hamnar överst. Därefter tar vi ut enbart färgen från korten och sist väljer vi det översta objektets färg. 
                //3:  Utan LINQ så skulle vi behöva en foreach-loop som tar varje kort ur handen, därefter en if-sats som kollar om kortet har en färg, sen en if sats som kollar vilken färg ett kort har
                // sedan hade vi ökat en integer för varje kort per färg, sist hade vi tagit den integern med högst siffra och tilldelat state.currentColor den färgen som var kopplad till integern.
                // Detta hade inte bara varit längre men även svårare att läsa. 
                var colorChoice = Hand.Cards
                .Where(c => c.Color != UnoColor.None)
                .GroupBy(c => c.Color)
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
