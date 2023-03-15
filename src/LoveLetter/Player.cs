using System;

namespace LoveLetter
{
    public sealed class Player
    {
        public Player(char name, Card initialHand)
        {
            Name = name;
            Hand = initialHand ?? throw new ArgumentNullException(nameof(initialHand));
        }

        public char Name { get; }

        public Card Hand { get; }
    }
}