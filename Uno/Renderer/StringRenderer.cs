
namespace Uno.Renderer
{
    internal class StringRenderer : IRenderer<string>
    {
        public void Render(string item)
        {
            Console.Write(item);
        }
    }
}
