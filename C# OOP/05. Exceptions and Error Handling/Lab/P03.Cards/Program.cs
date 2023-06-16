using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace P03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> cards = new Stack<string>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries));
            List<Card> deck = new List<Card>();
            while(cards.Count > 0)
            {
                string[] cardInfo = cards.Pop().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Card card = new Card(cardInfo[0], cardInfo[1].ToCharArray()[0]);
                    deck.Add(card);
                }
                catch (ArgumentException e)
                {

                    Console.WriteLine(e.Message);
                }

            }
            foreach(Card card in deck)
            {
                Console.Write(card + " ");
            }
        }
    }
}
