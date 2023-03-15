using System;
using System.Linq;

namespace LoveLetter
{
    public sealed class Game
    {
        private int activePlayerIdx;

        private Game(Deck deck, Player[] players)
        {
            Deck = deck;
            Players = players;
            activePlayerIdx = 0;
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
            PrintState();
            Console.WriteLine("Press any key to start.");
            Console.Write("> ");
            Console.ReadLine();

            while (Deck.Count > 0)
            {
                PlayTurn();
            }

            PrintWinner();
        }

        private void PlayTurn()
        {
            Card newCard = Deck.Draw();
            PrintState();

            Players[activePlayerIdx].PlayTurn(this, newCard);

            activePlayerIdx = (activePlayerIdx + 1) % Players.Length;
        }

        private void PrintWinner()
        {
            PrintState();

            Console.WriteLine("  ~*~ Hands ~*~");
            Console.WriteLine();

            foreach (var player in Players)
            {
                Console.WriteLine($"Player {player.Name}: {player.Hand.Number}");
            }

            Console.WriteLine();

            Player winner = Players.MaxBy(player => player.Hand.Number)!;
            Console.WriteLine($"Winner: {winner.Name}");
        }

        private void PrintState()
        {
            Console.Clear();
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
    }
}
