using System;


namespace TSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вершин");
            var vertex = int.Parse(Console.ReadLine()!);
            var matrixDistance = new MatrixDistance(vertex);
            Console.WriteLine("Матрица дистанций:");
            for (var i = 0; i < vertex; i++)
            {
                for (var j = 0; j < vertex; j++)
                {
                    Console.Write(matrixDistance.DistanceMatrix[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            var permutations = new GeneratorPermutations(vertex);
            var ways = permutations.GetPermutations();
            var finder = new TspFinder(ways, matrixDistance);
            Console.WriteLine("Минимальный маршрут: " + finder.Find());
        }
    }
}