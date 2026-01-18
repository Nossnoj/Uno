using Uno.Cards;
using Uno.UpgradeFactories;
using Uno.Upgrades;

namespace Uno
{
    internal class Deck
    {
        private List<UnoCard> cards;
        public List<UnoCard> discard;
        public IUpgradeFactory Factory { get; set; }
        public Deck(IUpgradeFactory factory)
        {
            Factory = factory;
            cards = new List<UnoCard>();
            discard = new List<UnoCard>();
            populateDeck();
        }

        private void populateDeck()
        {
            IUpgrade upgrade = Factory.CreateUpgrade();
            IUpgrade[] upgradeArray = new IUpgrade[108];
            for (int i = 0; i < 108; i++)
                upgradeArray[i] = Factory.CreateUpgrade();
            string[] numberSymbols = { "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            UnoColor[] colors = { UnoColor.Red, UnoColor.Blue, UnoColor.Green, UnoColor.Yellow };
            foreach(var color in colors)
            {
                //Lägger till nummerkort
                foreach(var symbol in numberSymbols)
                {
                    for(int i = 0; i < 2; i++)
                        cards.Add(new NumberCard(color, symbol, upgrade));
                    
                } 
                cards.Add(new NumberCard(color, "0", upgrade));
                for (int i = 0; i < 2; i++)
                {
                    cards.Add(new SkipCard(color, upgrade));
                    cards.Add(new ReverseCard(color, upgrade));
                    cards.Add(new PlusTwoCard(color, upgrade));
                }
                
            }
            for (int i = 0; i < 4; i++)
            {
                cards.Add(new ChooseColorCard(upgrade));
                cards.Add(new PlusFourCard(upgrade));
            }
            int x = 0;
            Shuffle(cards);
            foreach (var card in cards)
            {
                card.Upgrade = upgradeArray[x];
                x++;
            }
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
