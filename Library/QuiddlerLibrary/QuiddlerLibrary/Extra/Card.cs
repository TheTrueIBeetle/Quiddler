/**
 * Project Name: QuiddlerLibrary
 * File Name: Card.cs
 * Author(s): L. Bas, M. Ivanov
 * Date Started: 2022-01-31
 * Context: Card class to hold the 1 property, letter
 */

using System;

namespace QuiddlerLibrary
{
    internal class Card
    {
        public string Letter { get; set; }
        public int Points { get; set; }
        public Card(string letter, int points)
        {
            this.Letter = letter;
            this.Points = points;
        }
    }
}
