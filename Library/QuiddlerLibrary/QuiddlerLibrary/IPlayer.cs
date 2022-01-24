
namespace QuiddlerLibrary
{
    interface IPlayer
    {
        int CardCount { get; } // indicate how many cards are in the players hand
        int TotalPoints { get; } // total points scored by a player

        string DrawCard(); // draw a card
        bool Discard(string card); // discard a card
        string PickupTopDiscard(); // add top card from discard pile to players hand 
        int PlayWord(string candidate); // represents a word
        int TestWord(string candidate); // return point value based on some criteria 
        string ToString(); // return hand's card values 
    }
}
