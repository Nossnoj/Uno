using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
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
            render.RenderHand(hand);
            var tempTopCard = topCard;

            if (topCard.Symbol == "Wild+4")
                tempTopCard = new PlusFourCard(state.CurrentColor);
            else if (topCard.Symbol == "Wild")
                tempTopCard = new ChooseColorCard(state.CurrentColor);

            if (state.CardsToDraw > 0)
            {
                if (tempTopCard.Symbol == "+2" || tempTopCard.Symbol == "Wild+4")
                {
                    Console.WriteLine($"You must respond to a draw effect. " +
                        $"You can play a {tempTopCard.Symbol} stack, or type 'd' to draw {state.CardsToDraw} cards.");
                    string choice = Console.ReadLine().Trim().ToLower();

                    if (int.TryParse(choice, out int choiceIndex) && choiceIndex >= 1 && choiceIndex < hand.Cards.Count + 1)
                    {
                        choiceIndex -= 1;
                        UnoCard chosen = hand.Cards[choiceIndex];

                        if (chosen.Symbol != tempTopCard.Symbol)
                        {
                            Console.WriteLine("You can't play that card! Try again.");
                            return playCard(hand, tempTopCard);
                        }

                        hand.RemoveCard(chosen);
                        deck.discard.Add(chosen);
                        Console.Write($"{name} played ");
                        render.RenderColor(chosen.color);
                        Console.WriteLine($"{chosen}");
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
                
            Console.WriteLine("Select a card number to play, or type 'd' to draw a new card from the deck!");
            string position = Console.ReadLine();

            if (position.ToLower() == "d")
            {
                base.DrawCard();
                if(drawCount == 3)
                {
                    Console.WriteLine($"{name} drew 3 cards but coult not play. Turn ends!");
                    return null;
                }
                Console.WriteLine($"{name} drew a card!");
                return playCard(hand, tempTopCard);
            }

            if (int.TryParse(position, out int positionIndex) && positionIndex >= 1 && positionIndex < hand.Cards.Count + 1)
            {
                positionIndex -= 1;
                UnoCard chosenCard = hand.Cards[positionIndex];

                if (!chosenCard.CanPlayOn(tempTopCard))
                {
                    Console.WriteLine("You can't play that card! Try again.");
                    return playCard(hand, tempTopCard);
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
                        ResetUnoCall();
                    }
                }

                return chosenCard;   
                    
                }
            else
            {
                Console.WriteLine("Invalid input! Try again.");
                return playCard(hand, tempTopCard);
            }
        }
    }
}
