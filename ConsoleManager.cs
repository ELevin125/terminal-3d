using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Terminal_3D.Rendering
{
    public class ConsoleManager
    {
        struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        // Define constants for the maximum width and height of the console window in characters
        private int consoleWidthChars;
        private int consoleHeightChars;
        private float averageCharWidth;
        private float averageCharHeight;

        public ConsoleManager(int width, int height, float charWidth, float charHeight)
        {
            consoleWidthChars = width;
            consoleHeightChars = height;
            averageCharWidth = charWidth;
            averageCharHeight = charHeight;
        }

        public void ConfigureDisplay()
        {
            // Import the necessary functions from user32.dll
            [DllImport("user32.dll")]
            static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll")]
            static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
            [DllImport("user32.dll")]
            static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

            // Get the handle of the console window
            IntPtr consoleWindowHandle = GetForegroundWindow();
            Rect screenRect;
            GetWindowRect(consoleWindowHandle, out screenRect);
            // Resize and reposition the console window to fill the screen
            MoveWindow( consoleWindowHandle, 
                        screenRect.Left / 2,
                        screenRect.Top / 2,
                        (int)(consoleWidthChars * averageCharWidth),
                        (int)(consoleHeightChars * averageCharHeight),
                        true);

            Console.SetCursorPosition(0, 0);

            //Console.SetBufferSize((int)(consoleWidthChars * averageCharWidth), (int)(consoleHeightChars * averageCharHeight));
        }

        public void DrawCharacter(int x, int y, char c)
        {
            if (x < consoleWidthChars && y < consoleHeightChars)
            {
                Debug.WriteLine(x);
                Debug.WriteLine(y);
                Console.SetCursorPosition(x, y);
                Console.Write(c);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(x), $"Target coordinates ({x}, {y}) are out of the console bounds.");
            }
        }

        public void DrawBorder(char c)
        {
            for (int y = 0; y <= consoleHeightChars - 1; y++)
            {
                DrawCharacter(0, y, c);
                DrawCharacter(consoleWidthChars - 1, y, c);
            }

            for (int x = 0; x < consoleWidthChars; x++)
            {
                DrawCharacter(x, 0, c);
                DrawCharacter(x, consoleHeightChars - 1, c);
            }
        }
    }
}
