using System;

public class InputManager
{
    private static InputManager instance;

    public event EventHandler<ConsoleKey> KeyPressed;

    private InputManager() { } // Private constructor to prevent instantiation

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new InputManager();
            }
            return instance;
        }
    }

    public void Listen()
    {
        if (Console.KeyAvailable)
        {
            var keyInfo = Console.ReadKey(intercept: true);
            // Raise the KeyPressed event with the pressed key
            KeyPressed?.Invoke(this, keyInfo.Key);
        }
    }
}
