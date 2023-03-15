using System;

namespace LoveLetter
{
    public sealed class Deck
    {
        private readonly Card[] cards;

        private Deck(Card[] cards)
        {
            this.cards = cards;
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
            throw new NotImplementedException();
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