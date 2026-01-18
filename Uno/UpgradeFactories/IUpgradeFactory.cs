using Uno.Upgrades;

namespace Uno.UpgradeFactories
{
    //   KRAV #4:
    //1: Factory Method Pattern
    //2: Vi har ett interface som heter IUpgradeFactory som definierar metoden CreateUpgrade() samt tre stycken konkreta fabriker som heter NoUpgradeFactory, NormalUpgradeFactory och ChooseUpgradeFactory.
    //   Dessa fabriker skapar produkter i form av uppgraderingar (IUpgrade) och olika fabriker skapar olika typer av IUpgrade objekt med varierande sannolikhet och beteende.
    //   Fabriken injiceras i Deck klassen som använder fabriken för att skapa uppgraderingar utan att känna till deras konkreta typer.
    //3: Detta underlättar genom att separera logiken för hur uppgraderingar skapas från resten av spelet. Det gör det senare lättare att ändra svårighetsgrad, lägga till nya typer av uppgraderingar
    //   eller nya fabriker utan att behöva ändra koden i Deck eller övrig spellogik.
    internal interface IUpgradeFactory
    {
        public IUpgrade CreateUpgrade();
    }
}
