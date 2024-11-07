namespace Game.UI
{
    public static class PlayerCreationUI
    {
        public static string PromptPlayerName()
        {
            string message = "QUAL É O SEU NOME?";
            MainUIMethods.SetCursorAtMiddlePointForMessage(message);
            Console.WriteLine(message);

            string name = MainUIMethods.AskForPrompt();
            return name;
        }
    }
}
