using System;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int MAX_CONSOLE_WIDTH_CHARS = 120;
            int MAX_CONSOLE_HEIGHT_CHARS = 40;
            float AVERAGE_CHAR_WIDTH = 9.45f;
            float AVERAGE_CHAR_HEIGHT = 21.25f;

            ConsoleManager consoleManager = new ConsoleManager(MAX_CONSOLE_WIDTH_CHARS, MAX_CONSOLE_HEIGHT_CHARS, AVERAGE_CHAR_WIDTH, AVERAGE_CHAR_HEIGHT);
            consoleManager.ConfigureDisplay();
            consoleManager.DrawBorder('#');


            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
        }
    }
}
