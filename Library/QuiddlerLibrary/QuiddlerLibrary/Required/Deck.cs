/**
 * Project Name: QuiddlerLibrary
 * File Name: Deck.cs
 * Author(s): L. Bas, M. Ivanov
 * Date Started: 2022-01-24
 * Context: Concrete deck class
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace QuiddlerLibrary
{
    public class Deck : IDeck
    {
        // array of card letters whose indexes coorespond to the card points & letters
        private readonly string[] CardLetters = {"a", "e", "i", "o", "l", "s", "t", "u", "y", "d", "m", "n", "r",
        "f", "g", "p", "h", "er", "in", "b", "c", "k", "qu", "th", "w", "cl", "v", "x", "j", "z", "q"};

        // array of card letters in alphabetical order used for displaying the deck
        private readonly string[] AlphabeticalCardLetters = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
        "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "cl", "er", "in",
        "qu", "th"};

        // array of card counts whose indexes coorespond to the card letters
        private readonly int[] CardCounts = {10, 12, 8, 8, 4, 4, 6, 6, 4, 4, 2, 6, 6, 2, 4, 2, 2, 2, 2, 2, 2, 2, 2,
        2, 2, 2, 2, 2, 2, 2, 2};

        // TODO: add points
        private readonly int[] CardPoints = {2, 2, 2, 2, 3, 3, 3, 4, 4, 5, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 8,
        9, 9, 10, 10, 11, 12, 13, 14, 15};

        internal Stack<Card> discardPile;
        internal static int allPlayerCardsTotal = 0; //This member keeps track of all players cards in hand at all times

        // holds the list of card letters & their counts
        internal List<Card> cardsList = new List<Card>();

        public Deck()
        {
            InitializeNewDeck();
        }

        private void InitializeNewDeck()
        {
            cardsList = new List<Card>();

            for (int i = 0; i < CardCounts.Length; i++)
            {
                int valueCounter = 0;
                // add the amount of cards that belong to the letter
                while (valueCounter < CardCounts[i])
                {
                    cardsList.Add(new Card(CardLetters[i], CardCounts[i]));
                    valueCounter++;
                }
            }

            // shuffle (not sure if shuffle here or in a function) 
            Random random = new Random();
            cardsList = cardsList.OrderBy(card => random.Next()).ToList();
        }
    

        public string About => "Quiddler (TM) Library, Michael I & Luke B.";

        public int CardsPerPlayer
        {
            get { return CardsPerPlayer; }
            set
            {
                if (value < 3 || value > 10)
                {
                    throw new ArgumentOutOfRangeException($"Value must be greater than 3 and less than 10. Value given: {value}");
                }
                else
                {
                    CardsPerPlayer = value;
                }
            }
        }

        public string TopDiscard { get { return discardPile.Peek().Letter; } }

        public int CardCount { get { return 118 - allPlayerCardsTotal; } }

        public IPlayer NewPlayer()
        {
            Player p = new Player(this); //Giving player constructor an instance of this deck
            for (int i = 0; i <= CardsPerPlayer; i++)
            {
                // allPlayerCardsTotal++;
                p.DrawCard();
            }
            return p;
        }

        // grab the cards points at the specified index
        private int GetLettersValue(int valueIndex)
        {
            return CardPoints[valueIndex];
        }

        // grab the index of the current letter
        private int GetLettersIndex(string letterIndex)
        {
            for (int i = 0; i < CardLetters.Length; ++i)
            {
                if (letterIndex == CardLetters[i]) return i;
            }
            return 0;
        }

        // match the cards letter value with the cards points value and return
        public int GetPointsForCard(string card)
        {     
            return GetLettersValue(GetLettersIndex(card));
        } 
    

        // counts how many cards are per each letter
        private int LetterCounter(string letter)
        {
            int letterCounter = 0;

            for (int i = 0; i < cardsList.Count; i++)
            {
                if (letter == cardsList[i].Letter) letterCounter++;
            }
            return letterCounter;
        }

        public override string ToString()
        {
            string cardString = "";

            for (int i = 0; i < AlphabeticalCardLetters.Length; i++)
            {
                if (AlphabeticalCardLetters[i] == "m" || AlphabeticalCardLetters[i] == "y") cardString += "\n";
                cardString += AlphabeticalCardLetters[i] + "(" + LetterCounter(AlphabeticalCardLetters[i]) + ") ";
            }
            return cardString;
        }
    }
}
