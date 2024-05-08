using Terminal_3D.Geometry;
using Terminal_3D.SceneManagement;

namespace Terminal_3D.Rendering
{
    public class Renderer
    {
        private ConsoleManager CM;
        public Renderer(int width, int height, float charWidth, float charHeight, Scene currentScene)
        {
            CM = new ConsoleManager(width, height, charWidth, charHeight);
            CM.ConfigureDisplay();
        }

        public void RenderFrame()
        {
            Console.SetCursorPosition(0, 0);

            DrawBorder('#');

            DrawLine2D(new Vector2(10, 10), new Vector2(20, 20));
            DrawLine2D(new Vector2(20, 20), new Vector2(30, 10));
            DrawLine2D(new Vector2(20, 20), new Vector2(20, 30));

            DrawLine2D(new Vector2(40, 10), new Vector2(65, 10));
            DrawLine2D(new Vector2(65, 10), new Vector2(65, 30));
            DrawLine2D(new Vector2(65, 30), new Vector2(40, 30));
            DrawLine2D(new Vector2(40, 30), new Vector2(40, 10));

            DrawLine2D(new Vector2(-10, 32), new Vector2(180, 50));


            // Hold on last frame
            Console.ReadKey();
        }

        private void DrawBorder(char c)
        {
            for (int y = 0; y <= CM.MaxHeightChars - 1; y++)
            {
                CM.DrawCharacter(0, y, c);
                CM.DrawCharacter(CM.MaxWidthChars - 1, y, c);
            }

            for (int x = 0; x < CM.MaxWidthChars - 1; x++)
            {
                CM.DrawCharacter(x, 0, c);
                CM.DrawCharacter(x, CM.MaxHeightChars - 1, c);
            }
        }

        private void DrawLine2D(Vector2 start, Vector2 end, char c = '#')
        {
            int dx = (int)Math.Abs(end.X - start.X);
            int dy = (int)Math.Abs(end.Y - start.Y);
            int step_x = start.X < end.X ? 1 : -1;
            int step_y = start.Y < end.Y ? 1 : -1;
            int err = dx - dy;

            int x = (int)start.X;
            int y = (int)start.Y;


            // TODO: implement a propper clipping algorithm, instead of just not drawing them

            // Continue with drawing as long as the end hasn't been reached
            while (x != end.X || y != end.Y)
            {
                if (x >= 0 && y >= 0 && x <= CM.MaxWidthChars - 1 && y <= CM.MaxHeightChars - 1)
                    CM.DrawCharacter(x, y, c);

                int err2 = 2 * err;
                if (err2 > -dy)
                {
                    err -= dy;
                    x += step_x;
                }
                if (err2 < dx)
                {
                    err += dx;
                    y += step_y;
                }
            }

            // Ensure the last point is drawn if it's on-screen
            if (x >= 0 && y >= 0 && x <= CM.MaxWidthChars - 1 && y <= CM.MaxHeightChars - 1)
                CM.DrawCharacter(x, y, c);
        }

    }
}
