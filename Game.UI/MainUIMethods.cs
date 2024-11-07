namespace Game.UI
{
    public static class MainUIMethods
    {
        internal static string AskForPrompt()
        {
            (int left, int top) = Console.GetCursorPosition();
            Console.SetCursorPosition(Console.BufferWidth / 2, top);
            return Console.ReadLine();
        }

        private static int GetMiddleOfTheScreenForMessageSize(string message)
        {
            int middleOfScreen = Console.BufferWidth / 2 - (message.Length / 2);
            return middleOfScreen;
        }

        internal static void SetCursorAtMiddlePointForMessage(string message)
        {
            Console.SetCursorPosition(GetMiddleOfTheScreenForMessageSize(message), 0);
        }
    }
}
