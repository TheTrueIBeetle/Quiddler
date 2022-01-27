/**
 * Project Name: QuiddlerLibrary
 * File Name: Player.cs
 * Author(s): L. Bas, M. Ivanov
 * Date Started: 2022-01-24
 * Context: Concrete player class
 */

using System;

namespace QuiddlerLibrary
{
    internal class Player : IPlayer
    {
        private Deck deck;

        public int CardCount => throw new NotImplementedException();

        public int TotalPoints => throw new NotImplementedException();

        public Player(Deck d)
        {
            this.deck = d;
        }

        public bool Discard(string card)
        {
            this.deck.CardsPerPlayer--;
            return true;
        }

        public string DrawCard()
        {
            this.deck.CardsPerPlayer++;
            return "";
        }

        public string PickupTopDiscard()
        {
            return "";
        }

        public int PlayWord(string candidate)
        {
            return 0;
        }

        public int TestWord(string candidate)
        {
            return 0;
        }
    }
}
