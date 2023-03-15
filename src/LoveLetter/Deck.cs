﻿using System;

namespace LoveLetter
{
    public sealed class Deck
    {
        private readonly Card[] cards;
        private int count;

        private Deck(Card[] cards)
        {
            this.cards = cards;
            count = cards.Length;
        }

        public static Deck CreateDefault()
        {
            var cards = new[]
            {
                Card.Princess,
                Card.Countess,
                Card.King,
                Card.Chancellor,
                Card.Chancellor,
                Card.Prince,
                Card.Prince,
                Card.Handmaid,
                Card.Handmaid,
                Card.Baron,
                Card.Baron,
                Card.Priest,
                Card.Priest,
                Card.Guard,
                Card.Guard,
                Card.Guard,
                Card.Guard,
                Card.Guard,
                Card.Guard,
                Card.Spy,
                Card.Spy,
            };

            Shuffle(cards);

            return new Deck(cards);
        }

        public Card Draw()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Deck is empty.");
            }

            return cards[--count];
        }

        public void Print()
        {
            Console.WriteLine($"Deck: {count:00} card(s)");
            Console.WriteLine();
        }

        private static void Shuffle(Card[] cards)
        {
            int n = cards.Length;
            Random rnd = Random.Shared;

            for (int i = 0; i < n - 1; i++)
            {
                int j = rnd.Next(i, n);

                if (j != i)
                {
                    Card temp = cards[i];
                    cards[i] = cards[j];
                    cards[j] = temp;
                }
            }
        }
    }
}