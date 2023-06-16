using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P03.Cards
{
    public class Card
    {
        private string name;
        private char suit;
        private Dictionary<char, char> suits = new Dictionary<char, char>()
        {
            { 'S' , '\u2660' },
            { 'C' , '\u2663' },
            { 'H' , '\u2665' },
            { 'D' , '\u2666' }
        };

        public Card(string name, char suit) 
        {
            this.Name = name;
            this.Suit = suit;
        }
        
        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (!Regex.IsMatch(value, @"[2-9JKQA]|[10]{2}"))
                {
                    throw new ArgumentException("Invalid card!");
                }
                this.name = value;
            }
        }
        public char Suit
        {
            get { return this.suit; }
            private set 
            {
                
                if(!this.suits.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                this.suit = this.suits[value];
            }
        }
        public override string ToString()
        {
            return $"[{this.Name}{this.Suit}]";
        }
    }
}
