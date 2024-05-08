
namespace Terminal_3D.Rendering
{
    public class Renderer
    {
        public Renderer(int width, int height, float charWidth, float charHeight)
        {
            ConsoleManager consoleManager = new ConsoleManager(width, height, charWidth, charHeight);
            consoleManager.ConfigureDisplay();
            consoleManager.DrawBorder('#');


            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
        }
    }
}
