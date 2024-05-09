using Terminal_3D.Geometry;
using Terminal_3D.SceneManagement;
using Terminal_3D.Core;

namespace Terminal_3D.Rendering
{
    public class Renderer
    {
        private ConsoleManager CM;
        private Scene WorkingScene;
        private Camera MainCamera;

        public Renderer(int width, int height, float charWidth, float charHeight, Scene currentScene)
        {
            CM = new ConsoleManager(width, height, charWidth, charHeight);
            CM.ConfigureDisplay();

            WorkingScene = currentScene;
            MainCamera = WorkingScene.MainCamera;
        }

        public void RenderFrame()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            DrawBorder('#');

            foreach (Mesh m in WorkingScene.AllMeshes)
            {
                foreach (Edge e in m.Edges)
                {
                    DrawLine3D(m.Vertices[e.V1].Position, m.Vertices[e.V2].Position);
                }
            }

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
            int endX = (int)end.X;
            int endY = (int)end.Y;

            // TODO: implement a propper clipping algorithm, instead of just not drawing them

            // Continue with drawing as long as the end hasn't been reached
            while (x != endX || y != endY)
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

        private Vector2 ToScreenSpace(Vector3 worldPos)
        {
            Vector2 screenCenter = new Vector2(CM.MaxWidthChars / 2, CM.MaxHeightChars / 2);
            Vector3 delta = new Vector3(worldPos.X - MainCamera.Position.X,
                                        worldPos.Y - MainCamera.Position.Y,
                                        worldPos.Z - MainCamera.Position.Z);

            Vector3 translated = new Vector3((float)(delta.X * Math.Cos(-MainCamera.Rotation.Y) + delta.Z * Math.Sin(-MainCamera.Rotation.Y)),
                                             0f,
                                             (float)(delta.Z * Math.Cos(MainCamera.Rotation.Y) - delta.X * Math.Sin(-MainCamera.Rotation.Y)));

            // Behind camera, don't draw
            if (translated.Z < 0) return null;

            return new Vector2((int)((translated.X / translated.Z) * MainCamera.screenDistance + screenCenter.X),
                               (int)((delta.Y / translated.Z) * MainCamera.screenDistance + screenCenter.Y));
        }

        public void DrawLine3D(Vector3 start, Vector3 end)
        {
            Vector2 startScrenSpace = ToScreenSpace(start);
            Vector2 endScreenSpace = ToScreenSpace(end);

            if (startScrenSpace == null || endScreenSpace == null)
                return;

            DrawLine2D(startScrenSpace, endScreenSpace, '#');
        }
    }
}
