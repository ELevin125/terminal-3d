using Terminal_3D.Geometry;
using Terminal_3D.SceneManagement;
using Terminal_3D.Core;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;

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
            Console.SetCursorPosition(0, 0);

            DrawBorder('#');

            //DrawLine2D(new Vector2(10, 10), new Vector2(20, 20));
            //DrawLine2D(new Vector2(20, 20), new Vector2(30, 10));
            //DrawLine2D(new Vector2(20, 20), new Vector2(20, 30));

            //DrawLine2D(new Vector2(40, 10), new Vector2(65, 10));
            //DrawLine2D(new Vector2(65, 10), new Vector2(65, 30));
            //DrawLine2D(new Vector2(65, 30), new Vector2(40, 30));
            //DrawLine2D(new Vector2(40, 30), new Vector2(40, 10));

            //DrawLine2D(new Vector2(-10, 32), new Vector2(180, 50));

            //DrawLine3D(new Vector3(50, 0, 20000), new Vector3(1000, 200, 2000));
            DrawCube(new Vector3(0f, 0f, 200f), new Vector3(20f, 10f, 100f));
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

            int screenDistance = 400;

            return new Vector2((int)((translated.X / translated.Z) * screenDistance + screenCenter.X),
                               (int)((delta.Y / translated.Z) * screenDistance + screenCenter.Y));
        }

        public void DrawLine3D(Vector3 start, Vector3 end)
        {
            Debug.WriteLine("---");
            Debug.WriteLine(start.ToString() + " " + end.ToString());

            Vector2 startScrenSpace = ToScreenSpace(start);
            Vector2 endScreenSpace = ToScreenSpace(end);
            Debug.WriteLine(startScrenSpace.ToString() + " " + endScreenSpace.ToString());

            if (startScrenSpace == null || endScreenSpace == null)
                return;

            DrawLine2D(startScrenSpace, endScreenSpace, '#');
        }

        private void DrawPlain(Vector3 position, Vector3 scale)
        {
            Vector3 bottomLeft = new Vector3(position.X, position.Y, position.Z);
            Vector3 bottomRight = new Vector3(position.X + scale.X, position.Y, position.Z);
            Vector3 topLeft = new Vector3(position.X, position.Y, position.Z + scale.Z);
            Vector3 topRight = new Vector3(position.X + scale.X, position.Y, position.Z + scale.Z);



            // Draw lines connecting the four corners to form the floor
            DrawLine3D(bottomLeft, bottomRight);
            DrawLine3D(bottomRight, topRight);
            DrawLine3D(topRight, topLeft);
            DrawLine3D(topLeft, bottomLeft);
        }

        private void DrawCube(Vector3 position, Vector3 scale)
        {
            // Draw the bottom face of the prism
            DrawPlain(position, new Vector3(scale.X, 0, scale.X));

            // Draw the top face of the prism
            DrawPlain(new Vector3(position.X, position.Y + scale.Y, position.Z),
                           new Vector3(scale.X, 0, scale.Z));

            // Draw the four vertical edges of the prism
            // Using this.drawPlain again would double draw horizontal edges
            DrawLine3D(position,
                            new Vector3(position.X, position.Y + scale.Y, position.Z));
            DrawLine3D(new Vector3(position.X + scale.X, position.Y, position.Z),
                            new Vector3(position.X + scale.X, position.Y + scale.Y, position.Z));
            DrawLine3D(new Vector3(position.X + scale.X, position.Y, position.Z + scale.Z),
                            new Vector3(position.X + scale.X, position.Y + scale.Y, position.Z + scale.Z));
            DrawLine3D(new Vector3(position.X, position.Y, position.Z + scale.Z),
                            new Vector3(position.X, position.Y + scale.Y, position.Z + scale.Z));
        }



    }
}
