/**
 * Project Name: QuiddlerLibrary
 * File Name: Helper.cs
 * Author(s): L. Bas, M. Ivanov
 * Date Started: 2022-01-24
 * Context: Helper toolbox class to hold various static helper methods. A lot of the messy logic goes in this class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                cardList.Add(new Card("b", 8));
                cardList.Add(new Card("c", 8));
                cardList.Add(new Card("f", 6));
                cardList.Add(new Card("h", 7));
                cardList.Add(new Card("j", 13));
                cardList.Add(new Card("k", 8));
                cardList.Add(new Card("m", 5));
                cardList.Add(new Card("p", 6));
                cardList.Add(new Card("q", 15));
                cardList.Add(new Card("v", 11));
                cardList.Add(new Card("w", 10));
                cardList.Add(new Card("x", 12));
                cardList.Add(new Card("z", 14));
                cardList.Add(new Card("qu", 9));
                cardList.Add(new Card("in", 7));
                cardList.Add(new Card("er", 7));
                cardList.Add(new Card("cl", 10));
                cardList.Add(new Card("th", 9));
            }
            for (int i = 0; i <= 4; i++)
            {
                cardList.Add(new Card("d", 5));
                cardList.Add(new Card("g", 6));
                cardList.Add(new Card("l", 3));
                cardList.Add(new Card("s", 3));
                cardList.Add(new Card("y", 4));
            }
            for (int i = 0; i <= 6; i++)
            {
                cardList.Add(new Card("n", 5));
                cardList.Add(new Card("r", 5));
                cardList.Add(new Card("t", 3));
                cardList.Add(new Card("u", 4));
            }
            for (int i = 0; i <= 8; i++)
            {
                cardList.Add(new Card("i", 2));
                cardList.Add(new Card("o", 2));
            }
            for (int i = 0; i < 10; i++)
            {
                cardList.Add(new Card("a", 2));
            }
            for (int i = 0; i < 12; i++)
            {
                cardList.Add(new Card("e", 2));
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

        public static string ShowStackContents(Stack<Card> stack) //TODO: Finish this
        {
            List<Card> list = new List<Card>();
            //Dictionary<string, int> hashMap = new Dictionary<string, int>();  
            int count = 0;
            while (count < stack.Count)
            {
                list.Add(stack.Pop());
                count++;
            }
            //Count how many of each card in the list
            /*int a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z, qu, In, er, cl, th;
            a = b = c = d = e = f = g = h = i = j = k = l = m = n = o = p = q = r = s = t = u = v = w = x = y = z = qu = In = er = cl = th = 0;
            foreach(Card counterCard in list)
            {
                switch (counterCard.Letter)
                {
                    case "a":
                        a++;
                        break;
                    case "b":
                        b++;
                        break;
                    case "c":
                        c++;
                        break;
                    case "d":
                        d++;
                        break;
                    case "e":
                        e++;
                        break;
                    case "f":
                        f++;
                        break;
                    case "g":
                        g++;
                        break;
                    case "h":
                        h++;
                        break;
                    case "i":
                        i++;
                        break;
                    case "j":
                        j++;
                        break;
                    case "k":
                        k++;
                        break;
                    case "l":
                        l++;
                        break;
                    case "m":
                        m++;
                        break;
                    case "n":
                        n++;
                        break;
                    case "o":
                        o++;
                        break;
                    case "p":
                        p++;
                        break;
                    case "q":
                        q++;
                        break;
                    case "r":
                        r++;
                        break;
                    case "s":
                        s++;
                        break;
                    case "t":
                        t++;
                        break;
                    case "u":
                        u++;
                        break;
                    case "v":
                        v++;
                        break;
                    case "w":
                        w++;
                        break;
                    case "x":
                        x++;
                        break;
                    case "y":
                        y++;
                        break;
                    case "z":
                        z++;
                        break;
                    case "qu":
                        qu++;
                        break;
                    case "in":
                        In++;
                        break;
                    case "er":
                        er++;
                        break;
                    case "cl":
                        cl++;
                        break;
                    case "th":
                        th++;
                        break;
                    default:
                        break;
                }
            }
            List<Card> uniqueList = list.Distinct().ToList();*/

            //Create and return string
            StringBuilder sb = new StringBuilder();
            foreach (Card card in list)
            {
                sb.Append(card.Letter + ", ");
            }
            return sb.ToString();
        }
    }
}
