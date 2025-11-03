using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;
using Uno.Players;

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
            //render.RenderHand(hand);
            var tempTopCard = topCard;
            GameRender renderGame = new GameRender();

            if (topCard.Symbol == "Wild+4")
                tempTopCard = new PlusFourCard(state.CurrentColor);
            else if (topCard.Symbol == "Wild")
                tempTopCard = new ChooseColorCard(state.CurrentColor);

            if (state.CardsToDraw > 0)
            {
                if (tempTopCard.Symbol == "+2" || tempTopCard.Symbol == "Wild+4")
                {
                    string drawResponse = $"You must respond to a draw effect. " +
                        $"You can play a {tempTopCard.Symbol} stack, or type 'd' to draw {state.CardsToDraw} cards.";
                    renderGame.RenderComment(drawResponse, 0);
                    string choice = Console.ReadLine().Trim().ToLower();

                    if (int.TryParse(choice, out int choiceIndex) && choiceIndex >= 1 && choiceIndex < hand.Cards.Count + 1)
                    {
                        choiceIndex -= 1;
                        UnoCard chosen = hand.Cards[choiceIndex];

                        if (chosen.Symbol != tempTopCard.Symbol)
                        {
                            string wrongCard = "You can't play that card! Try again.";
                            renderGame.RenderComment(wrongCard, 0);
                            return playCard(hand, tempTopCard);
                        }

                        hand.RemoveCard(chosen);
                        deck.discard.Add(chosen);
                        renderGame.RenderComment($"{Name} played {chosen}!", 0);
                        Console.ForegroundColor = ConsoleColor.White;
                        return chosen;
                    }
                    else
                    {
                        drawPenaltyCards(choice);
                        return null;
                    }
                }
            }
                
            /*string playPrompt ="Select a card number to play, or type 'd' to draw a new card from the deck!";
            renderGame.RenderComment(playPrompt, 35);*/
            string position = Console.ReadLine();

            if (position.ToLower() == "d")
            {
                base.DrawCard();
                if(drawCount == 3)
                {
                    string drewThreeCards = $"{name} drew 3 cards but coult not play. Turn ends!";
                    renderGame.RenderComment(drewThreeCards, 0);
                    Thread.Sleep(2000);
                    return null;
                }
                renderGame.RenderComment($"{name} drew a card!", 0);
                renderGame.RenderHand(hand);
                return playCard(hand, tempTopCard);
            }

            if (int.TryParse(position, out int positionIndex) && positionIndex >= 1 && positionIndex < hand.Cards.Count + 1)
            {
                positionIndex -= 1;
                UnoCard chosenCard = hand.Cards[positionIndex];

                if (!chosenCard.CanPlayOn(tempTopCard))
                {
                    string wrongCard = "You can't play that card! Try again.";
                    renderGame.RenderComment(wrongCard, 0);
                    return playCard(hand, tempTopCard);
                }

                hand.RemoveCard(chosenCard);
                deck.discard.Add(chosenCard);
                renderGame.RenderComment($"{Name} played {chosenCard}!", 0);
                Thread.Sleep(1000);
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
                        renderGame.RenderComment("You forgot to call UNO!", 0);
                        Thread.Sleep(3000);
                        renderGame.RenderComment("Drawing 2 penalty cards!", 0);
                        hand.AddCard(deck.drawCard());
                        hand.AddCard(deck.drawCard());
                        ResetUnoCall();
                    }
                }

                return chosenCard;   
                    
                }
            else
            {
                string invalidCard = "Invalid input! Try again.";
                renderGame.RenderComment(invalidCard, 0);
                return playCard(hand, tempTopCard);
            }
        }
    }
}
