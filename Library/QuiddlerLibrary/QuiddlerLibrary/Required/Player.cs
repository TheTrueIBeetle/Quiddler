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

        public int CardCount => throw new NotImplementedException();

        public int TotalPoints => throw new NotImplementedException();

        public Player(Deck d)
        {
            this.deck = d;
        }

        public bool Discard(string card)
        {
            this.deck.allPlayerCardsTotal++;
            //Do a check to see if string is a valid letter (using cards letter prop)
            for (int i = 0; i < cardsInHand.Count; i++)
            {
                if (card == cardsInHand.ElementAt(i).Letter)
                {
                    cardsInHand.RemoveAt(i);
                    this.deck.discardPile.Push(cardsInHand.ElementAt(i));
                    return true;
                }
            }
            return false;
        }

        public string DrawCard()
        {
            this.deck.allPlayerCardsTotal++;
            this.cardsInHand.Add(deck.cardsList.ElementAt(deck.cardsList.Count - 1));
            string cardDrawn = deck.cardsList.ElementAt(deck.cardsList.Count - 1).Letter;

            this.deck.cardsList.RemoveAt(deck.cardsList.Count - 1); //Removes card drawn from deck
            return cardDrawn;
        }

        public string PickupTopDiscard()
        {
            this.deck.allPlayerCardsTotal++;
            string discardCard = this.deck.discardPile.Pop().Letter;
            return discardCard;
        }

        public int PlayWord(string candidate)
        {
            return 0;
        }

        public int TestWord(string candidate)
        {
            //Trim string first so there is no whitespace
            string trimmedString = String.Concat(candidate.Where(c => !Char.IsWhiteSpace(c)));

            int accumulativeScore = 0;
            if (SpellChecker.CheckSpelling(trimmedString))
            {
                //Get points that word is worth using card's combo
                char[] charArr = trimmedString.ToCharArray();
                foreach (char c in charArr)
                {
                    string characterStr = c.ToString();
                    //Now search for card with this letter (in string form), then grab point value
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
            return accumulativeScore; //Returns 0 if spellcheck fails
        }

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
