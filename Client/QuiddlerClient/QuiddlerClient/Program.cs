/**
 * Project Name: QuiddlerClient
 * File Name: Program.cs
 * Author(s): L. Bas, M. Ivanov
 * Date Started: 2022-01-20
 * Context: main class
 */

using QuiddlerLibrary;
using System;
using System.Collections.Generic;

namespace QuiddlerClient
{
    sealed class Program
    {
        static void Main(string[] args)
        {
            // holds all the players playing
            List<IPlayer> allPlayers = new List<IPlayer>();
            
            QuiddlerLibrary.IDeck iDeck = new QuiddlerLibrary.Deck();
            Console.WriteLine(iDeck.About);

            Console.WriteLine($"\nDeck initialized with the following {iDeck.CardCount} cards:");
            Console.WriteLine(iDeck.ToString());

            GetNumPlayers();

            int num = NumCardsDealtToEachPlayer();
            iDeck.CardsPerPlayer = num;
            
            // add each player to allPlayers
            for(int i = 0; i < GetNumPlayers(); i++)
            {
                allPlayers.Add(iDeck.NewPlayer());
            }

            cardsDealtText();

            /*       
            Console.WriteLine("\npoints of card t: " + deck.GetPointsForCard("t"));
            Console.WriteLine("\npoints of card er: " + deck.GetPointsForCard("er"));
            Console.WriteLine("\npoints of card v: " + deck.GetPointsForCard("v"));
            */
        }

        public static int GetNumPlayers()
        {
            string playerCountInput;
            int playerCountInputToInt;

            Console.WriteLine("How many players are there? (1-8): ");
            playerCountInput = Console.ReadLine();
            playerCountInputToInt = Convert.ToInt32(playerCountInput);

            return playerCountInputToInt;
        }

        public static int NumCardsDealtToEachPlayer()
        {
            string numCardsInput;
            int numCardsInputToInt;

            Console.WriteLine("How many cards will be dealt to each player? (3-10): ");
            numCardsInput = Console.ReadLine();
            numCardsInputToInt = Convert.ToInt32(numCardsInput);

            return numCardsInputToInt;
        }

        public static void cardsDealtText()
        {
            Console.WriteLine($"Cards were dealt to ${GetNumPlayers()}");
        }
    }

}
