/**
 * Project Name: QuiddlerLibrary
 * File Name: Helper.cs
 * Author(s): L. Bas, M. Ivanov
 * Date Started: 2022-01-24
 * Context: Helper toolbox class to hold some static helper methods
 */

using System;
using System.Collections.Generic;
using System.Linq;


namespace QuiddlerLibrary
{
    internal class Helper
    {
        public static Stack<Card> InitNewCardStack()
        {
            Stack<Card> cardStack = new Stack<Card>();
            List<Card> cardList = new List<Card>();
            for (int i = 0; i <= 2; i++)
            {
                cardList.Add(new Card("b"));
                cardList.Add(new Card("c"));
                cardList.Add(new Card("f"));
                cardList.Add(new Card("h"));
                cardList.Add(new Card("j"));
                cardList.Add(new Card("k"));
                cardList.Add(new Card("m"));
                cardList.Add(new Card("p"));
                cardList.Add(new Card("q"));
                cardList.Add(new Card("v"));
                cardList.Add(new Card("w"));
                cardList.Add(new Card("x"));
                cardList.Add(new Card("z"));
                cardList.Add(new Card("qu"));
                cardList.Add(new Card("in"));
                cardList.Add(new Card("er"));
                cardList.Add(new Card("cl"));
                cardList.Add(new Card("th"));
            }
            for (int i = 0; i <= 4; i++)
            {
                cardList.Add(new Card("d"));
                cardList.Add(new Card("g"));
                cardList.Add(new Card("l"));
                cardList.Add(new Card("s"));
                cardList.Add(new Card("y"));
            }
            for (int i = 0; i <= 6; i++)
            {
                cardList.Add(new Card("n"));
                cardList.Add(new Card("r"));
                cardList.Add(new Card("t"));
                cardList.Add(new Card("u"));
            }
            for (int i = 0; i <= 8; i++)
            {
                cardList.Add(new Card("i"));
                cardList.Add(new Card("o"));
            }
            for (int i = 0; i < 10; i++)
            {
                cardList.Add(new Card("a"));
            }
            for (int i = 0; i < 12; i++)
            {
                cardList.Add(new Card("e"));
            }

            //Shuffle list
            Random rand = new Random();
            List<Card> shuffledList = cardList.OrderBy(item => rand.Next()).ToList();

            //Loops through list and push onto stack, then return it
            foreach(Card c in shuffledList)
            {
                cardStack.Push(c);
            }
            return cardStack;
        }
    }
}
