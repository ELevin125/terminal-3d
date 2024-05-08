using Terminal_3D.Geometry;
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

            DrawLine2D(new Vector2(10, 10), new Vector2(20, 20));
            DrawLine2D(new Vector2(20, 20), new Vector2(30, 10));

            // Hold on last frame
            Console.ReadKey();
        }

        private void DrawLine2D(Vector2 start, Vector2 end, char c = '#')
        {
            int dx = (int)Math.Abs(end.X - start.X);
            int dy = (int)Math.Abs(end.Y - start.Y);
            int sx = start.X < end.X ? 1 : -1;
            int sy = start.Y < end.Y ? 1 : -1;
            int err = dx - dy;

            Vector2 place = start;
            

            while (place.X != end.X || place.Y != end.Y)
            {
                ConsoleManager.DrawCharacter((int)place.X, (int)place.Y, c);
                int err2 = 2 * err;
                if (err2 > -dy)
                {
                    err -= dy;
                    place.X += sx;
                }
                if (err2 < dx)
                {
                    err += dx;
                    place.Y += sy;
                }
            }
        }
    }
}
