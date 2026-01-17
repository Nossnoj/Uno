using Uno.Players;

namespace Uno.Renderer
{
    internal class PlayerRenderer : IRenderer<Player>
    {
        public void Render(Player player)
        {
            Console.WriteLine($"{player.Name}");
        }
    }
}
