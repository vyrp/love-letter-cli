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
            Player targetPlayer = game.ChooseNonActivePlayer();
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
