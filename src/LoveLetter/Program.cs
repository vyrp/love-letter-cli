using System;

namespace LoveLetter
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 1 || byte.TryParse(args[0], out byte numberOfPlayers))
            {
                Console.WriteLine("Usage:");
                Console.WriteLine(@"    .\LoveLetter.exe <number-of-players>");
                return 1;
            }

            var game = Game.CreateNewGame(numberOfPlayers);

            game.Run();

            return 0;
        }
    }
}