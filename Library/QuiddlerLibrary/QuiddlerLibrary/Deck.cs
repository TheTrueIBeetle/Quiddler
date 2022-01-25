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
        string IDeck.About => "Quiddler (TM) Library, Michael I & Luke B.";
        
        public int CardCount => throw new NotImplementedException();
        public int CardsPerPlayer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TopDiscard => throw new NotImplementedException();

      
        public Deck()
        {
        }
        
        //Methods
        public IPlayer NewPlayer()
        {
            Player p = new Player();
            for (int i = 0; i <= CardsPerPlayer; i++)
            {
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
