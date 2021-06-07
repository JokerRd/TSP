using System;
using System.Collections.Generic;

namespace TSP
{
    public class MatrixDistance
    {
        public int[,] DistanceMatrix { get; }
        
        public MatrixDistance(int countVertex)
        {
            DistanceMatrix = GenerateMatrix(countVertex);
        }
        
        private int[,] GenerateMatrix(int countVertex)
        {
            var rnd = new Random();
            var matrix = new int[countVertex,countVertex];
            for (var i = 0; i < countVertex; i++)
            {
                for (var j = 0; j < countVertex; j++)
                {
                    if (i == j) continue;
                    if (matrix[j, i] != 0)
                    {
                        matrix[i, j] = matrix[j, i];
                    }
                    else
                    {
                        matrix[i, j] = rnd.Next(10, 80);
                    }
                }
            }

            return matrix;
        }
    }
}