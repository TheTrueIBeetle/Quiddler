
namespace QuiddlerLibrary
{
    interface IDeck
    {      
        string About { get; } // identify the library and its developer
                              
        /*
        int CardCount { get; } // undealt cards indicator      
        int CardsPerPlayer { get; set; } // # of cards initially dealt to each player
        string TopDiscard { get; } // indicate top card on discard pile

        public IPlayer NewPlayer(); // populates NewPlayer with CardsPerPlayer cards
        string ToString(); // describes inventory of cards available in the deck (alphabetical order)      
        */
    }
}
