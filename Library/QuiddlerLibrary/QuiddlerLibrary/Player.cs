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
    public class Player : IPlayer
    {

        public int CardCount => throw new NotImplementedException();

        public int TotalPoints => throw new NotImplementedException();

        public bool Discard(string card)
        {
            throw new NotImplementedException();
        }

        public string DrawCard()
        {
            throw new NotImplementedException();
        }

        public string PickupTopDiscard()
        {
            throw new NotImplementedException();
        }

        public int PlayWord(string candidate)
        {
            throw new NotImplementedException();
        }

        public int TestWord(string candidate)
        {
            throw new NotImplementedException();
        }
    }
}
