using System;

namespace LoveLetter.Cards
{
    internal sealed class Priest : Card
    {
        public override string Name => nameof(Priest);

        public override byte Number => 2;

        public override void Play(Game game, Player currentPlayer)
        {
            Console.WriteLine($"Playing {Name}...");
            Player targetPlayer = game.ChooseNonActivePlayer();

            Card hand = targetPlayer.Hand;
            Console.WriteLine($"Player {targetPlayer.Name} has a {hand.Name} ({hand.Number}).");
            Console.ReadLine();
        }
    }
}
