using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno
{
    internal class Deck
    {
        private List<UnoCard> cards;
        public List<UnoCard> discard;
        public Deck()
        {
            cards = new List<UnoCard>();
            populateDeck();
        }

        private void populateDeck()
        {
            string[] numberSymbols = { "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            UnoColor[] colors = { UnoColor.Red, UnoColor.Blue, UnoColor.Green, UnoColor.Yellow };
            foreach(var color in colors)
            {
                //Lägger till nummerkort
                foreach(var symbol in numberSymbols)
                {
                    for(int i = 0; i < 2; i++)
                        cards.Add(new NumberCard(color, symbol));
                    
                } 
                cards.Add(new NumberCard(color, "0"));
                for (int i = 0; i < 2; i++)
                {
                    cards.Add(new SkipCard(color));
                    cards.Add(new ReverseCard(color));
                    cards.Add(new PlusTwoCard(color));
                }
                
            }
            for (int i = 0; i < 4; i++)
            {
                cards.Add(new ChooseColorCard());
                cards.Add(new PlusFourCard());
            }
            Shuffle(cards);
        }
        public UnoCard drawCard()
        {
            if (cards.Count == 0)
            {
                cards = discard.ToList();
                discard.Clear();
                Shuffle(cards);
            }
            UnoCard drawnCard = cards[0];
            cards.RemoveAt(0);
            //discard.Add(drawnCard);
            return drawnCard;
        }
        public void Shuffle(List<UnoCard> deck)
        {
            Random rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                UnoCard temp = deck[n];
                cards[n] = deck[k];
                cards[k] = temp;
            }
        }
    }
}
