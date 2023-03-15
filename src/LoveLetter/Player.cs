using System;
using System.Collections.Generic;

namespace LoveLetter
{
    public sealed class Player
    {
        public readonly List<Card> playedCards;

        public Player(char name, Card initialHand)
        {
            Name = name;
            Hand = initialHand ?? throw new ArgumentNullException(nameof(initialHand));
            playedCards = new List<Card>();
        }

        public char Name { get; }

        public Card Hand { get; private set; }

        public void Print()
        {
            Console.Write($"Player {Name}:");
            foreach (Card card in playedCards)
            {
                Console.Write($" {card.Number}");
            }

            Console.WriteLine();
        }

        public void PlayTurn(Card newCard)
        {
            Console.WriteLine($"  ~*~ Player {Name}'s turn ~*~");
            Console.WriteLine();

            Console.WriteLine("Your cards:");
            Card oldCard = Hand;
            Console.WriteLine($"* {oldCard.Number}: {oldCard.Name}");
            Console.WriteLine($"* {newCard.Number}: {newCard.Name}");
            Console.WriteLine();

            (Card chosenCard, Card otherCard) = ChooseCardToPlay(oldCard, newCard);
            Console.WriteLine();

            playedCards.Add(chosenCard);
            Hand = otherCard;

            chosenCard.Play();
        }

        private static (Card chosenCard, Card otherCard) ChooseCardToPlay(Card card1, Card card2)
        {
            Console.WriteLine("Which card do you play?");
            while (true)
            {
                Console.Write("> ");

                if (!byte.TryParse(Console.ReadLine(), out byte selection))
                {
                    continue;
                }

                if (selection == card1.Number)
                {
                    return (card1, card2);
                }

                if (selection == card2.Number)
                {
                    return (card2, card1);
                }
            }
        }
    }
}