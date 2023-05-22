using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace P04.Froggy
{
    internal class Lake : IEnumerable<int>
    {
        public Lake(params int[] data) 
        {
            stones = new List<int>(data);
        }
        private List<int> stones;

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i++)
            {
                if (i % 2 == 0)
                    yield return stones[i];
            }
            for (int i = stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 == 1)
                yield return stones[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
    }
}
