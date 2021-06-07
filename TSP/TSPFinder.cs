using System.Collections.Generic;

namespace TSP
{
    public class TspFinder
    {
        private List<int[]> Ways { get; set; }
        
        private MatrixDistance MatrixDistance { get; set; }
        

        public TspFinder(List<int[]> ways, MatrixDistance matrixDistance)
        {
            Ways = ways;
            MatrixDistance = matrixDistance;
        }

        public int Find()
        {
            var min = 99999;
            foreach (var list in Ways)
            {
                var length = 0;
                for (var i = 0; i < list.Length; i++)
                {
                    if (i == list.Length - 1)
                    {
                        length += MatrixDistance.DistanceMatrix[list[i] - 1, list[0] - 1];
                    }
                    else
                    {
                        length += MatrixDistance.DistanceMatrix[list[i] - 1, list[i + 1] - 1];
                    }
                }

                if (min > length)
                {
                    min = length;
                }

                length = 0;
            }

            return min;
        }
    }
}