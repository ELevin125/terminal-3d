using System.Runtime.InteropServices;

namespace Terminal_3D.Core
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
        public readonly int MaxWidthChars;
        public readonly int MaxHeightChars;
        private readonly float AverageCharWidth;
        private readonly float AverageCharHeight;

        public ConsoleManager(int width, int height, float charWidth, float charHeight)
        {
            MaxWidthChars = width;
            MaxHeightChars = height;
            AverageCharWidth = charWidth;
            AverageCharHeight = charHeight;
        }

        public void ConfigureDisplay()
        {
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
                        (int)(MaxWidthChars * AverageCharWidth),
                        (int)(MaxHeightChars * AverageCharHeight),
                        true);

            Console.SetCursorPosition(0, 0);

        }

        public void DrawCharacter(int x, int y, char c)
        {
            if (x < MaxWidthChars && y < MaxHeightChars)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(c);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(x), $"Target coordinates ({x}, {y}) are out of the console bounds.");
            }
        }
    }
}
