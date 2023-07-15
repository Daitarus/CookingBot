namespace LibraryBot
{
    internal static class MainServerCycle
    {
        public static void StopCondition()
        {
            Console.WriteLine("Bot was started...");
            string? answer = null;
            do
            {
                Console.WriteLine("If you want stopped bot, enter \'exit\' or \'e\'");
                answer = Console.ReadLine();
            } while (ValidationOfEnteredData(answer));
        }
        private static bool ValidationOfEnteredData(string? answer)
        {
            if (!string.IsNullOrEmpty(answer))
            {
                answer = answer.ToLower();
                if (!answer.Equals("e") && !answer.Equals("exit"))
                    return true;
            }
            return false;
        }
    }
}
