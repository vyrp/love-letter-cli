using System;

namespace LoveLetter.Cards
{
    internal sealed class Baron : Card
    {
        public override string Name => nameof(Baron);

        public override byte Number => 3;

        public override void Play(Game game, Player currentPlayer)
        {
            Console.WriteLine($"Playing {Name}...");

            Card currentPlayerHand = currentPlayer.Hand;

            Player targetPlayer = game.ChooseNonActivePlayer();
            Card targetPlayerHand = targetPlayer.Hand;
            Console.WriteLine($"Player {targetPlayer.Name} has a {targetPlayerHand.Name} ({targetPlayerHand.Number}).");

            if (currentPlayerHand.Number > targetPlayerHand.Number)
            {
                Console.WriteLine("They have been knocked out of the round!");
                game.KnockOut(targetPlayer);
            }
            else if (currentPlayerHand.Number < targetPlayerHand.Number)
            {
                Console.WriteLine("You have been knocked out of the round...");
                game.KnockOut(currentPlayer);
            }
            else
            {
                Console.WriteLine("It's a draw.");
            }

            Console.ReadLine();
        }
    }
}
