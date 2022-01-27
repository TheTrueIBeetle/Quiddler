/**
 * Project Name: QuiddlerLibrary
 * File Name: Deck.cs
 * Author(s): L. Bas, M. Ivanov
 * Date Started: 2022-01-24
 * Context: Concrete deck class
 */

using System;

namespace QuiddlerLibrary
{
    public class Deck : IDeck
    {
        internal static int allPlayerCardsTotal = 0; //This member keeps track of all players cards in hand at all times
        string IDeck.About => "Quiddler (TM) Library, Michael I & Luke B.";
        
        public int CardCount { get { return 118 - allPlayerCardsTotal; } }
        public int CardsPerPlayer { get { return CardsPerPlayer; } 
            set { 
                if (value < 3 || value > 10) {
                    throw new ArgumentOutOfRangeException($"Value must be greater than 3 and less than 10. Value given: {value}");
                }
                else {
                    CardsPerPlayer = value;
                }
            } 
        }
        public string TopDiscard => throw new NotImplementedException();

      
        public Deck()
        {
        }
        
        //Methods
        public IPlayer NewPlayer()
        {
            Player p = new Player(this); //Giving player constructor an instance of this deck
            for (int i = 0; i <= CardsPerPlayer; i++)
            {
                allPlayerCardsTotal++;
                p.DrawCard();
            }
            return p;
        }
        public override string ToString()
        {
            return "";
            //TODO: Change eventually to show contents of deck
        }

    }
}
