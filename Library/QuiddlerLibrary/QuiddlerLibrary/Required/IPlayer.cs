/**
 * Project Name: QuiddlerLibrary
 * File Name: IPlayer.cs
 * Author(s): L. Bas, M. Ivanov
 * Date Started: 2022-01-24
 * Context: IPlayer interface to be superclass for concrete player
 */


namespace QuiddlerLibrary
{
    public interface IPlayer
    {
        public int CardCount { get; } // indicate how many cards are in the players hand
        public int TotalPoints { get; } // total points scored by a player

        public string DrawCard(); // draw a card
        public bool Discard(string card); // discard a card
        public string PickupTopDiscard(); // add top card from discard pile to players hand 
        public int PlayWord(string candidate); // represents a word
        public int TestWord(string candidate); // return point value based on some criteria 
        public string ToString(); // return hand's card values 
    }
}
