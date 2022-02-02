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
            QuiddlerLibrary.IDeck deck = new QuiddlerLibrary.Deck();
            Console.WriteLine(deck.About);

            Console.WriteLine("\nDeck initialized with the following 118 cards:");
            Console.WriteLine(deck.ToString());
        }
    }
}
