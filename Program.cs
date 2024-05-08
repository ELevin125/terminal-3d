using System;

namespace ConsoleGame
{
    class Program
    {
        const int DISPLAY_WIDTH = 120;
        const int DISPLAY_HEIGHT = 30;

        static void Main(string[] args)
        {
            SetDisplaySize(DISPLAY_WIDTH, DISPLAY_HEIGHT);
            DrawBorder('#');

            DrawCharacter(10, 5, 'A');
            DrawCharacter(20, 10, '#');
            DrawCharacter(10, 10, '$');

            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
        }

        // Set the initial size and resolution of the display window
        private static void SetDisplaySize(int width, int height)
        {
            Console.SetCursorPosition(0, 0);
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }


        // Draw a character at a specific x, y coordinate
        private static void DrawCharacter(int x, int y, char c)
        {
            if (x < DISPLAY_WIDTH && y < DISPLAY_HEIGHT)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(c);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(x), $"Target coordinates ({x}, {y}) are out of the console bounds.");
            }
        }

        private static void DrawBorder(char c)
        {
            for (int y = 0; y < DISPLAY_HEIGHT; y++)
            {
                DrawCharacter(DISPLAY_WIDTH - 1, y, c);
                DrawCharacter(0, y, c);
            }
            
            for (int x = 0; x < DISPLAY_WIDTH; x++)
            {
                DrawCharacter(x, DISPLAY_HEIGHT - 1, c);
                DrawCharacter(x, 0, c);
            }
        }
    }
}
