using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSP
{
    public class GeneratorPermutations
    {
        private List<int []> _permutations;
        private readonly int[] _init;
        
        private void Reshuffle(int[] sequence, int length)
        {
            for (var i = 0; i < length; i++)
            {
                var temp = sequence[length - 1];
                for (var j = length - 1; j > 0; j--)
                {
                    sequence[j] = sequence[j - 1];
                }
                sequence[0] = temp;
                if (i < length - 1) AddPermutations(sequence);
                if (length > 0) Reshuffle(sequence, length - 1);
            }
        }
        
        public List<int[]> GetPermutations()
        {
            _permutations = new List<int[]> { _init };
            Reshuffle(_init, _init.Length);
            return _permutations;
        }
        
        private void AddPermutations(IReadOnlyList<int> sequence)
        {
            var newSeq = sequence.ToArray();
            if (!_permutations.Contains(newSeq))
            {
                _permutations.Add(newSeq);
            }
        }

        public GeneratorPermutations(int countVertex)
        {
            _init = GenerateInit(countVertex);
        }

        private static int[] GenerateInit(int countVertex)
        {
            var result = new int[countVertex];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = i + 1;
            }

            return result;
        }

    }
}