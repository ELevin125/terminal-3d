﻿using Terminal_3D.Geometry;
using Terminal_3D.SceneManagement;
using Terminal_3D.Core;
using System.Diagnostics;

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

        private void DrawLine2D(Vector2 start, Vector2 end, float distanceToStart = 0, float distanceToEnd = 0)
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

            // Calculate distance along the line
            float totalDistance = Vector2.Distance(start, end);
            float distanceToX = Vector2.Distance(start, new Vector2(x, y));


            // TODO: implement a propper clipping algorithm, instead of just not drawing them
            char c = ' ';
            // Continue with drawing as long as the end hasn't been reached
            while (x != endX || y != endY)
            {
                // Calculate the normalized distance to the current point
                distanceToX = Vector2.Distance(start, new Vector2(x, y));
                float distanceToCurrentNormalized = distanceToX / MathF.Max(totalDistance, 1);

                // Calculate what the distance to the camera would be at a certain point on the 2D line
                float normalizedValue = distanceToStart + (distanceToEnd - distanceToStart) * distanceToCurrentNormalized;

                c = GetGradientValue(normalizedValue);


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

            // //Ensure the last point is drawn if it's on-screen
            //if (x >= 0 && y >= 0 && x <= CM.MaxWidthChars - 1 && y <= CM.MaxHeightChars - 1)
            //    CM.DrawCharacter(x, y, c);
        }

        private char GetGradientValue(float distanceToCamera = 0, float nearestDistance = 200, float farthestDistance = 2000)
        {
            string gradient = "@%#*+=-:. ";
            int gradientIndex = 0;


            // Map the distance to the index in the gradient
            if (distanceToCamera <= nearestDistance)
                gradientIndex = 0;
            else if (distanceToCamera >= farthestDistance)
                gradientIndex = gradient.Length - 1;
            else
            {
                // Interpolate the gradient index between 0 and gradient.Length - 1
                float normalizedDistance = (distanceToCamera - nearestDistance) / MathF.Max(farthestDistance - nearestDistance, 1);
                gradientIndex = (int)MathF.Floor(normalizedDistance * (gradient.Length - 1));
            }

            return gradient[gradientIndex];
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

            float startDist = Vector3.Distance(MainCamera.Position, start);
            float endDist = Vector3.Distance(MainCamera.Position, end);

            DrawLine2D(startScrenSpace, endScreenSpace, startDist, endDist);
        }
    }
}
