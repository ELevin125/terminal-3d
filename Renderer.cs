using Terminal_3D.SceneManagement;

namespace Terminal_3D.Rendering
{
    public class Renderer
    {
        private ConsoleManager ConsoleManager;
        public Renderer(int width, int height, float charWidth, float charHeight, Scene currentScene)
        {
            ConsoleManager = new ConsoleManager(width, height, charWidth, charHeight);
            ConsoleManager.ConfigureDisplay();
        }

        public void RenderFrame()
        {
            Console.SetCursorPosition(0, 0);

            ConsoleManager.DrawBorder('#');

            // Hold on last frame
            Console.ReadKey();
        }
    }
}
