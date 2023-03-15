using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LoveLetter
{
    public sealed class Game
    {
        private readonly List<Card> discardPile;
        private int activePlayerIdx;
        private int activePlayers;

        private Game(Deck deck, Player[] players)
        {
            Deck = deck;
            Players = players;

            discardPile = new List<Card>();
            activePlayerIdx = 0;
            activePlayers = players.Length;
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

            while (Deck.Count > 0 && activePlayers >= 2)
            {
                PlayTurn();
            }

            PrintWinner();
        }

        public void KnockOut(Player targetPlayer)
        {
            discardPile.Add(targetPlayer.Hand);
            targetPlayer.HasBeenKnockedOut = true;
            activePlayers--;
        }

        public Player ChooseNonActivePlayer()
        {
            char currentPlayerName = Players[activePlayerIdx].Name;

            Console.WriteLine("Choose another player:");
            while (true)
            {
                Console.Write("> ");
                if (!char.TryParse(Console.ReadLine(), out char selection))
                {
                    continue;
                }

                selection = char.ToUpperInvariant(selection);

                if (selection == currentPlayerName)
                {
                    continue;
                }

                if (Players.FirstOrDefault(player => player.Name == selection) is not Player chosenPlayer)
                {
                    continue;
                }

                if (chosenPlayer.HasBeenKnockedOut)
                {
                    continue;
                }

                return chosenPlayer;
            }
        }

        private void PlayTurn()
        {
            Card newCard = Deck.Draw();
            PrintState();

            Players[activePlayerIdx].PlayTurn(this, newCard);

            do
            {
                activePlayerIdx = (activePlayerIdx + 1) % Players.Length;
            }
            while (Players[activePlayerIdx].HasBeenKnockedOut);
        }

        private void PrintWinner()
        {
            PrintState();

            Console.WriteLine("  ~*~ Hands ~*~");
            Console.WriteLine();

            foreach (var player in Players)
            {
                if (!player.HasBeenKnockedOut)
                {
                    Console.WriteLine($"Player {player.Name}: {player.Hand.Number}");
                }
            }

            Console.WriteLine();

            Player winner = Players.Where(player => !player.HasBeenKnockedOut).MaxBy(player => player.Hand.Number)!;
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

            Console.Write("Discard pile:");
            foreach (Card card in discardPile)
            {
                Console.Write($" {card.Number}");
            }
            Console.WriteLine();

            Console.WriteLine();
        }
    }
}
