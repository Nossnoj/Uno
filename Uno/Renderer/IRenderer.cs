namespace Uno.Renderer
{

    // KRAV #1:
    //1: Generics
    //2: Vi har ett generiskt interface IRenderer<T> som definierar en metod Render(T item). Detta interface implementeras av olika renderer-klasser som UnoCardRenderer och StringRenderer.
    //   Dessa klasser i sin tur renderar olika objekt (strängar och spelare) på olika sätt. Vi använder oss av metoden RenderItem i Render klassen för att rendera olika typer av objekt utan att behöva veta deras konkreta typer i förväg.
    //3: Detta har en rad fördelar. Det gör koden mer flexibel, vi vet att oavsett hur vi använder RenderItem så kommer den att rendera objektet på rätt sätt.
    //   Vi kan även enkelt lägga till nya renderer klasser som implementerar IRenderer<T> och återanvända RenderItem metoden.
    //   Generics säkerställer också att vi får compiletime fel istället för runtime fel, eftersom att i RenderItem så måste renderar typen matcha T item som skickas in.

    internal interface IRenderer<T>
    {
        void Render(T item);
    }
}
