using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.RandomList
{
    internal class RandomList : List<string>
    {
        public RandomList() { random = new Random(); }
        private Random random;
        public string GetRandomElement()
        {
            int index = random.Next(0,Count);
            return this[index];
        }
        public void RemoveRandomElement()
        {
            int index = random.Next(0,Count);
            this.RemoveAt(index);
        }
    }
}
