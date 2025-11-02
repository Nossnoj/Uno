using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Cards;

namespace Uno.Effects
{
    //Krav 1
    //1: Generics
    //2: Vi använder generisk typ ICardEffect<TCard> där TCard är en typ av UnoCard.
    //   Detta gör interfacet flexibelt och typsäkert då varje effekt vet exakt vilken korttyp den tillhör.
    //   T.ex SkipEffect implementerar ICardEffect<SkipCard> och ReverseEffect implementerar ICardEffect<ReverseCard>.
    //3: Vi använder det för att tydligt koppla varje effekt till rätt korttyp på ett typsäkert sätt.
    //   Utan detta hade man kunnat tilldela ett kort en effekt som den inte ska tillhöra.
    //   Exempelvis hade ett SkipCard kunnat skapas med en DrawTwoEffect vilket inte borde gå.
    internal interface ICardEffect<TCard> where TCard : UnoCard
    {
        void AddEffect(TCard card, GameState state);
    }
}
