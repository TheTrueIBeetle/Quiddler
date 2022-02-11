/**
 * Project Name: QuiddlerLibrary
 * File Name: Player.cs
 * Author(s): L. Bas, M. Ivanov
 * Date Started: 2022-01-24
 * Context: Concrete player class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace QuiddlerLibrary
{
    internal class Player : IPlayer
    {
        private Deck deck;
        private List<Card> cardsInHand = new List<Card>();
        private static Application SpellChecker = new Application();
        private int pointsAccum = 0;

        public int CardCount { get { return cardsInHand.Count; } }

        public int TotalPoints { get { return pointsAccum; } }

        public Player(Deck d)
        {
            this.deck = d;
        }
        ~Player()
        {
            SpellChecker.Quit();
        }

        public bool Discard(string card)
        {
            // do a check to see if string is a valid letter (using cards letter prop)
            for (int i = 0; i < cardsInHand.Count; i++)
            {               
                if (card == cardsInHand[i].Letter)
                {
                    cardsInHand.RemoveAt(i);
                    this.deck.discardEntity = cardsInHand[i];
                    return true;
                }
            }
            return false;
        }

        // function to return a card that was drawn
        public string DrawCard()
        {
            this.deck.cardsDrawnTotal++;
            this.cardsInHand.Add(deck.cardsList.ElementAt(deck.cardsList.Count - 1));
            string cardDrawn = deck.cardsList.ElementAt(deck.cardsList.Count - 1).Letter;

            this.deck.cardsList.RemoveAt(deck.cardsList.Count - 1); // removes card drawn from deck
            return cardDrawn;
        }

        // function to return the top discard card
        public string PickupTopDiscard()
        {
            string discardCard = this.deck.discardEntity.Letter;
            this.cardsInHand.Add(deck.discardEntity);
            this.deck.discardEntity = null;
            return discardCard;
        }

        // returns points for word that user entered
        public int PlayWord(string candidate)
        {
            // trim string first so there is no whitespace
            string trimmedString = String.Concat(candidate.Where(c => !Char.IsWhiteSpace(c)));

            int pointsForWord = TestWord(candidate);
            if (pointsForWord > 0)
            {
                char[] charArr = trimmedString.ToCharArray();
                foreach (char c in charArr)
                {
                    string characterStr = c.ToString();
                    //Search for each character in hand corresponding with candidate characters and remove them from hand
                    for (int i = 0; i < cardsInHand.Count; i++)
                    {
                        if (characterStr == cardsInHand.ElementAt(i).Letter)
                        {
                            cardsInHand.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            this.pointsAccum += pointsForWord;
            return pointsForWord;
        }

        // returns cards point value if the word the user entered exists 
        public int TestWord(string candidate)
        {
            // trim string first so there is no whitespace
            string trimmedString = String.Concat(candidate.Where(c => !Char.IsWhiteSpace(c)));

            int accumulativeScore = 0;
            if (SpellChecker.CheckSpelling(trimmedString))
            {
                // get points that word is worth using card's combo
                char[] charArr = trimmedString.ToCharArray();
                foreach (char c in charArr)
                {
                    string characterStr = c.ToString();
                    // now search for card with this letter (in string form), then grab point value
                    for (int i = 0; i < cardsInHand.Count; i++)
                    {
                        if (characterStr == cardsInHand.ElementAt(i).Letter)
                        {
                            accumulativeScore += cardsInHand.ElementAt(i).Points;
                            break;
                        }
                    }
                }
            }
            return accumulativeScore; // returns 0 if spellcheck fails
        }

        // return cards based on how many user has in hand
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (Card c in cardsInHand)
            {
                sb.Append(c.Letter);                  
                sb.Append(" ");
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
