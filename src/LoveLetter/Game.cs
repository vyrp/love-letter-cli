using System;
using System.Linq;

namespace LoveLetter
{
    public sealed class Game
    {
        private Game(Deck deck, Player[] players)
        {
            Deck = deck;
            Players = players;
        }

        public Deck Deck { get; }

        public Player[] Players { get; }

        public static Game CreateNewGame(byte numberOfPlayers)
        {
            // TODO: 2-player game.
            if (numberOfPlayers < 3 || numberOfPlayers > 6)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(numberOfPlayers),
                    numberOfPlayers,
                    "Number of players must be between 3 and 6.");
            }

            Deck deck = Deck.CreateDefault();

            Player[] players = Enumerable.Range(0, numberOfPlayers)
                .Select(idx => new Player((char)('A' + idx), deck.Draw()))
                .ToArray();

            return new Game(deck, players);
        }

        public void Run()
        {
            Console.Clear();
            while (true)
            {
                PrintState();
                PlayTurn();
            }
        }

        private void PrintState()
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine("  ~*~ Love Letter ~*~");
            Console.WriteLine();

            foreach (Player player in Players)
            {
                player.Print();
            }

            Console.WriteLine();

            Deck.Print();
        }

        private void PlayTurn()
        {
            Console.Write("> ");
            Console.ReadLine();
        }
    }
}
