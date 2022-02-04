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

            int numPlayers = GetNumPlayers();
            int numCardsToEachPlayer = NumCardsDealtToEachPlayer();

            iDeck.CardsPerPlayer = numCardsToEachPlayer;
            Console.WriteLine($"\nCards were dealt to {numPlayers} player(s)");

            // add each player to allPlayers
            for (int i = 0; i < numPlayers; i++)
            {
                allPlayers.Add(iDeck.NewPlayer());
            }

            

            /*       
            Console.WriteLine("\npoints of card v: " + deck.GetPointsForCard("v"));
            */
        }

        public static int GetNumPlayers()
        {
            string playerCountInput;
            int playerCountInputToInt;

            Console.Write("\nHow many players are there? (1-8): ");
            playerCountInput = Console.ReadLine();
            playerCountInputToInt = Convert.ToInt32(playerCountInput);

            return playerCountInputToInt;
        }

        public static int NumCardsDealtToEachPlayer()
        {
            string numCardsInput;
            int numCardsInputToInt;

            Console.Write("\nHow many cards will be dealt to each player? (3-10): ");
            numCardsInput = Console.ReadLine();
            numCardsInputToInt = Convert.ToInt32(numCardsInput);

            return numCardsInputToInt;
        }
    }

}
