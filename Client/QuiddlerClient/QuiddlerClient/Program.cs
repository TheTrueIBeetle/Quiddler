﻿/**
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

            // instance of deck interface
            QuiddlerLibrary.IDeck iDeck = new QuiddlerLibrary.Deck();
            Console.WriteLine(iDeck.About);

            Console.WriteLine($"\nDeck initialized with the following {iDeck.CardCount} cards:");
            Console.WriteLine(iDeck.ToString());

            int numPlayers = GetNumPlayers();
            bool correctVal = false;
            do
            {
                int numCardsToEachPlayer = NumCardsDealtToEachPlayer();
                try
                {
                    iDeck.CardsPerPlayer = numCardsToEachPlayer;
                    correctVal = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("\nPlease enter an in-range number of cards to be dealt");
                }
            } while (correctVal == false);
           
            
            Console.WriteLine($"\nCards were dealt to {numPlayers} player(s)");

            // add each player to allPlayers
            for (int i = 0; i < numPlayers; i++)
            {
                allPlayers.Add(iDeck.NewPlayer());
            }

            bool gameNotDone = true;
            while (gameNotDone)
            {
                for (int i = 0; i < allPlayers.Count; i++)
                {
                    Console.WriteLine("\n--------------------------------------------------------------");
                    Console.WriteLine($"Player {i + 1} ({allPlayers[i].TotalPoints} points)");
                    Console.WriteLine("--------------------------------------------------------------\n");

                    Console.WriteLine($"The deck now contains the following {iDeck.CardCount} cards...");
                    Console.WriteLine($"{iDeck.ToString()}");

                    Console.WriteLine($"\nYour cards are: {allPlayers[i].ToString()}");
                    Console.WriteLine($"Do you want the top card in the discard pile which is '{iDeck.TopDiscard}'? (y/n): ");
                    string pickupDiscardkey = Console.ReadLine();

                    switch (pickupDiscardkey)
                    {
                        case "y":
                            Console.WriteLine($"You received: {allPlayers[i].PickupTopDiscard()}");
                            Console.WriteLine($"Your cards are: {allPlayers[i].ToString()}");
                            break;
                        case "n":
                            Console.WriteLine($"The dealer dealt you '{allPlayers[i].DrawCard()}'");
                            Console.WriteLine($"There is now {iDeck.CardCount} cards left in the deck");
                            Console.WriteLine($"Your cards are: {allPlayers[i].ToString()}");
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }

                    Console.WriteLine("Test a word you might have for points value? (y/n): ");
                    string testWordKey = Console.ReadLine();
                    switch (testWordKey)
                    {
                        case "y":
                            Console.WriteLine($"Enter a word using your letters {allPlayers[i].ToString()} leaving a space between cards: ");
                            string candidateWord = Console.ReadLine();
                            int wordValue = allPlayers[i].TestWord(candidateWord);
                            Console.WriteLine($"The word [{candidateWord}] is worth {wordValue} points");
                            if (wordValue > 0)
                            {
                                Console.WriteLine($"Would you like to play the word [{candidateWord}]? (y/n): ");
                                string playWordKey = Console.ReadLine();
                                switch (playWordKey)
                                {
                                    case "y":
                                        allPlayers[i].PlayWord(candidateWord);
                                        Console.WriteLine($"Your cards are now {allPlayers[i].ToString()} and you have {allPlayers[i].TotalPoints} points");
                                        Console.WriteLine("Enter a card from your hand to discard: ");
                                        string discard1 = Console.ReadLine();
                                        allPlayers[i].Discard(discard1);
                                        Console.WriteLine($"Your cards are now: {allPlayers[i].ToString()}");
                                        break;
                                    case "n":
                                        Console.WriteLine("Not playing word...");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input");
                                        break;
                                }
                                break;
                            }
                            break;
                        case "n":
                            Console.WriteLine("Enter a card from your hand to discard: ");
                            string discard2 = Console.ReadLine();
                            allPlayers[i].Discard(discard2);
                            Console.WriteLine($"Your cards are now: {allPlayers[i].ToString()}");
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }

                Console.WriteLine("Would you like each player to take another turn? (y/n): ");
                string key = Console.ReadLine();
                switch (key)
                {
                    case "y":
                        continue;
                    case "n":
                        Console.WriteLine("Retiring the game..");
                        Console.WriteLine("\nFinal scores:");
                        Console.WriteLine("--------------------");
                        for (int h = 0; h < allPlayers.Count; h++)
                        {
                            Console.WriteLine($"Player {h + 1}: {allPlayers[h].TotalPoints} points");
                        }
                        Console.WriteLine("\nGame over");
                        gameNotDone = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public static int GetNumPlayers()
        {
            string playerCountInput;
            int playerCountInputToInt;
            do
            {
                Console.Write("\nHow many players are there? (1-8): ");
                playerCountInput = Console.ReadLine();
                playerCountInputToInt = Convert.ToInt32(playerCountInput);

                if (playerCountInputToInt >= 1 && playerCountInputToInt <= 8)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please provide an in-range number of players");
                }
            } while (true);

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
