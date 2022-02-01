/**
 * Project Name: QuiddlerLibrary
 * File Name: IDeck.cs
 * Author(s): L. Bas, M. Ivanov
 * Date Started: 2022-01-24
 * Context: IDeck interface to be superclass for deck concrete
 */


namespace QuiddlerLibrary
{
    public interface IDeck
    {      
        public string About { get; } // identify the library and its developer               
        public int CardCount { get; } // undealt cards indicator      
        public int CardsPerPlayer { get; set; } // # of cards initially dealt to each player
        public string TopDiscard { get; } // indicate top card on discard pile


        public IPlayer NewPlayer(); // populates NewPlayer with CardsPerPlayer cards
        public string ToString(); // describes inventory of cards available in the deck (alphabetical order)      
    }
}
