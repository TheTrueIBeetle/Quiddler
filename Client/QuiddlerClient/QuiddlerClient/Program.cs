/**
 * Project Name: QuiddlerClient
 * File Name: Program.cs
 * Author(s): L. Bas, M. Ivanov
 * Date Started: 2022-01-20
 * Context: main class
 */

using System;

namespace QuiddlerClient
{
    sealed class Program
    {
        static void Main(string[] args)
        {
            QuiddlerLibrary.IDeck iDeck = new QuiddlerLibrary.Deck();
            QuiddlerLibrary.Deck deck = new QuiddlerLibrary.Deck();
            Console.WriteLine(iDeck.About);

            Console.WriteLine("\nDeck initialized with the following 118 cards:");
            Console.WriteLine(iDeck.ToString());

            // test stuff 
            Console.WriteLine("\npoints of card t: " + deck.GetPointsForCard("t"));
            Console.WriteLine("\npoints of card er: " + deck.GetPointsForCard("er"));
            Console.WriteLine("\npoints of card v: " + deck.GetPointsForCard("v"));
        }
    }
}
