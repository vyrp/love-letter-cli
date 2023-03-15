using System;

using LoveLetter.Cards;

namespace LoveLetter
{
    public abstract class Card
    {
        public static readonly Card Princess = new Princess();
        public static readonly Card Countess = new Countess();
        public static readonly Card King = new King();
        public static readonly Card Chancellor = new Chancellor();
        public static readonly Card Prince = new Prince();
        public static readonly Card Handmaid = new Handmaid();
        public static readonly Card Baron = new Baron();
        public static readonly Card Priest = new Priest();
        public static readonly Card Guard = new Guard();
        public static readonly Card Spy = new Spy();

        private protected Card()
        {
        }

        public abstract string Name { get; }

        public abstract byte Number { get; }

        public void Play()
        {
            Console.WriteLine($"Playing {Name}...");
            Console.ReadLine();
        }
    }
}