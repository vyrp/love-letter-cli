using System;
using System.Linq;

namespace LoveLetter.Cards
{
    internal sealed class Guard : Card
    {
        public override string Name => nameof(Guard);

        public override byte Number => 1;

        public override void Play(Game game, Player currentPlayer)
        {
            Console.WriteLine($"Playing {Name}...");
            Player targetPlayer = ChooseAnotherPlayer(game, currentPlayer);
            byte namedCard = NameANonGuardCard();

            if (targetPlayer.Hand.Number == namedCard)
            {
                Console.WriteLine($"Correct! Player {targetPlayer.Name} is out of the round.");
                game.KnockOut(targetPlayer);
            }
            else
            {
                Console.WriteLine($"Player {targetPlayer.Name} doesn't have that card.");
            }

            Console.ReadLine();
        }

        private static Player ChooseAnotherPlayer(Game game, Player currentPlayer)
        {
            Console.WriteLine("Choose another player:");
            while (true)
            {
                Console.Write("> ");
                if (!char.TryParse(Console.ReadLine(), out char selection))
                {
                    continue;
                }

                selection = char.ToUpperInvariant(selection);

                if (selection == currentPlayer.Name)
                {
                    continue;
                }

                if (game.Players.FirstOrDefault(player => player.Name == selection) is Player chosenPlayer)
                {
                    return chosenPlayer;
                }
            }
        }

        private static byte NameANonGuardCard()
        {
            Console.WriteLine("Name a non-guard card (0,2-9):");
            while (true)
            {
                Console.Write("> ");
                if (!byte.TryParse(Console.ReadLine(), out byte selection))
                {
                    continue;
                }

                if (selection == Card.Guard.Number)
                {
                    continue;
                }

                return selection;
            }
        }
    }
}
