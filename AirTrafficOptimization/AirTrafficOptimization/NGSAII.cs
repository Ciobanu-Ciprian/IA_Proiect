using System;
using System.Collections.Generic;
using System.Linq;
using graph;
class NSGAII
{
    static Random random = new Random();


    class Solution
    {
        public List<Edge> Edges;
        public int Objective1;
        public double Objective2;

        public Solution(List<Edge> edges)
        {
            Edges = edges;
        }
    }

    static List<Edge> allEdges = new List<Edge>();
    static int numberOfNodes;

    static Solution CreateRandomSolution()
    {
        var edges = new List<Edge>(allEdges.Where(e => random.NextDouble() > 0.5));
        EnsureConnectivity(edges, allEdges);
        return new Solution(edges);
    }

    static void EnsureConnectivity(List<Edge> edges, List<Edge> allEdges)
    {
        int[] parent = new int[numberOfNodes];
        for (int i = 0; i < numberOfNodes; i++) parent[i] = i;
        List<List<int>> sccs = Graph.FindSCCs(numberOfNodes, edges);

        for (int i = 0; i < sccs.Count; i++)
            for (int j = 0; j < sccs.Count;j++)
                if (i!=j)
                {
                    var e = allEdges.Where(x => sccs[i].Contains(x.From) && sccs[j].Contains(x.To)).OrderBy(x=>x.Weight).First();
                    if (e != null)
                        edges.Add(e);
                }
    }

    static void EvaluateSolution(Solution solution)
    {
        solution.Objective1 = solution.Edges.Count;

        double totalCommuteTime = 0;
        int totalPairs = 0;

        for (int i = 0; i < numberOfNodes; i++)
        {
            totalCommuteTime += Graph.GetShortestPath(solution.Edges, i, numberOfNodes).AsEnumerable<double>().Sum();
        }

        solution.Objective2 = totalCommuteTime;
    }

    static void DisplaySolution(Solution solution)
    {
        foreach (var edge in solution.Edges)
        {
            Console.WriteLine($"From Node {edge.From} to Node {edge.To}, Travel Time: {edge.Weight}");
        }

        Console.WriteLine($"Objective 1 (Number of Edges): {solution.Objective1}");
        Console.WriteLine($"Objective 2 (Total Commute Time): {solution.Objective2:F2}");
        Console.WriteLine("--------------------------------------");
    }

    static void RunNSGAII(int populationSize, int generations)
    {
        var population = new List<Solution>();
        for (int i = 0; i < populationSize; i++)
        {
            var solution = CreateRandomSolution();
            EvaluateSolution(solution);
            population.Add(solution);
        }

        for (int generation = 0; generation < generations; generation++)
        {
            var offspring = new List<Solution>();
            for (int i = 0; i < populationSize; i++)
            {
                var parent1 = population[random.Next(population.Count)];
                var parent2 = population[random.Next(population.Count)];
                offspring.Add(Crossover(parent1, parent2));
            }

            foreach (var child in offspring)
            {
                Mutate(child);
                EvaluateSolution(child);
            }
            population.AddRange(offspring);
            population = NonDominatedSorting(population).Take(populationSize).ToList();
        }

        Console.WriteLine("Final Pareto Front Solutions:");
        foreach (var solution in population)
        {
            DisplaySolution(solution);
        }
    }

    static Solution Crossover(Solution parent1, Solution parent2)
    {
        var childEdges = new List<Edge>(parent1.Edges.Union(parent2.Edges).Where(e => random.NextDouble() > 0.5));
        EnsureConnectivity(childEdges, allEdges);
        return new Solution(childEdges);
    }

    static void Mutate(Solution solution)
    {
        if (random.NextDouble() > 0.8 && solution.Edges.Count > 1)
        {
            var edgeToRemove = solution.Edges.ElementAt(random.Next(solution.Edges.Count));
            solution.Edges.Remove(edgeToRemove);
        }

        EnsureConnectivity(solution.Edges, allEdges);
    }

    static List<Solution> NonDominatedSorting(List<Solution> population)
    {
        var sorted = new List<Solution>();
        foreach (var solution in population)
        {
            if (!population.Any(other => Dominates(other, solution)))
            {
                sorted.Add(solution);
            }
        }
        return sorted.OrderBy(s => s.Objective1).ThenBy(s => s.Objective2).ToList();
    }

    static bool Dominates(Solution s1, Solution s2)
    {
        return (s1.Objective1 <= s2.Objective1 && s1.Objective2 <= s2.Objective2) &&
               (s1.Objective1 < s2.Objective1 || s1.Objective2 < s2.Objective2);
    }

    static void Main(string[] args)
    {
        numberOfNodes = 10;
        allEdges.Add(new Edge(0, 1, 1.0));
        allEdges.Add(new Edge(0, 2, 2.0));
        allEdges.Add(new Edge(0, 3, 3.0));
        allEdges.Add(new Edge(0, 4, 4.0));
        allEdges.Add(new Edge(0, 5, 5.0));
        allEdges.Add(new Edge(0, 6, 6.0));
        allEdges.Add(new Edge(0, 7, 7.0));
        allEdges.Add(new Edge(0, 8, 8.0));
        allEdges.Add(new Edge(0, 9, 9.0));

        allEdges.Add(new Edge(1, 0, 1.1));
        allEdges.Add(new Edge(1, 2, 2.1));
        allEdges.Add(new Edge(1, 3, 3.1));
        allEdges.Add(new Edge(1, 4, 4.1));
        allEdges.Add(new Edge(1, 5, 5.1));
        allEdges.Add(new Edge(1, 6, 6.1));
        allEdges.Add(new Edge(1, 7, 7.1));
        allEdges.Add(new Edge(1, 8, 8.1));
        allEdges.Add(new Edge(1, 9, 9.1));

        allEdges.Add(new Edge(2, 0, 1.2));
        allEdges.Add(new Edge(2, 1, 2.2));
        allEdges.Add(new Edge(2, 3, 3.2));
        allEdges.Add(new Edge(2, 4, 4.2));
        allEdges.Add(new Edge(2, 5, 5.2));
        allEdges.Add(new Edge(2, 6, 6.2));
        allEdges.Add(new Edge(2, 7, 7.2));
        allEdges.Add(new Edge(2, 8, 8.2));
        allEdges.Add(new Edge(2, 9, 9.2));

        allEdges.Add(new Edge(3, 0, 1.3));
        allEdges.Add(new Edge(3, 1, 2.3));
        allEdges.Add(new Edge(3, 2, 3.3));
        allEdges.Add(new Edge(3, 4, 4.3));
        allEdges.Add(new Edge(3, 5, 5.3));
        allEdges.Add(new Edge(3, 6, 6.3));
        allEdges.Add(new Edge(3, 7, 7.3));
        allEdges.Add(new Edge(3, 8, 8.3));
        allEdges.Add(new Edge(3, 9, 9.3));

        allEdges.Add(new Edge(4, 0, 1.4));
        allEdges.Add(new Edge(4, 1, 2.4));
        allEdges.Add(new Edge(4, 2, 3.4));
        allEdges.Add(new Edge(4, 3, 4.4));
        allEdges.Add(new Edge(4, 5, 5.4));
        allEdges.Add(new Edge(4, 6, 6.4));
        allEdges.Add(new Edge(4, 7, 7.4));
        allEdges.Add(new Edge(4, 8, 8.4));
        allEdges.Add(new Edge(4, 9, 9.4));

        allEdges.Add(new Edge(5, 0, 1.5));
        allEdges.Add(new Edge(5, 1, 2.5));
        allEdges.Add(new Edge(5, 2, 3.5));
        allEdges.Add(new Edge(5, 3, 4.5));
        allEdges.Add(new Edge(5, 4, 5.5));
        allEdges.Add(new Edge(5, 6, 6.5));
        allEdges.Add(new Edge(5, 7, 7.5));
        allEdges.Add(new Edge(5, 8, 8.5));
        allEdges.Add(new Edge(5, 9, 9.5));

        allEdges.Add(new Edge(6, 0, 1.6));
        allEdges.Add(new Edge(6, 1, 2.6));
        allEdges.Add(new Edge(6, 2, 3.6));
        allEdges.Add(new Edge(6, 3, 4.6));
        allEdges.Add(new Edge(6, 4, 5.6));
        allEdges.Add(new Edge(6, 5, 6.6));
        allEdges.Add(new Edge(6, 7, 7.6));
        allEdges.Add(new Edge(6, 8, 8.6));
        allEdges.Add(new Edge(6, 9, 9.6));

        allEdges.Add(new Edge(7, 0, 1.7));
        allEdges.Add(new Edge(7, 1, 2.7));
        allEdges.Add(new Edge(7, 2, 3.7));
        allEdges.Add(new Edge(7, 3, 4.7));
        allEdges.Add(new Edge(7, 4, 5.7));
        allEdges.Add(new Edge(7, 5, 6.7));
        allEdges.Add(new Edge(7, 6, 7.7));
        allEdges.Add(new Edge(7, 8, 8.7));
        allEdges.Add(new Edge(7, 9, 9.7));

        allEdges.Add(new Edge(8, 0, 1.8));
        allEdges.Add(new Edge(8, 1, 2.8));
        allEdges.Add(new Edge(8, 2, 3.8));
        allEdges.Add(new Edge(8, 3, 4.8));
        allEdges.Add(new Edge(8, 4, 5.8));
        allEdges.Add(new Edge(8, 5, 6.8));
        allEdges.Add(new Edge(8, 6, 7.8));
        allEdges.Add(new Edge(8, 7, 8.8));
        allEdges.Add(new Edge(8, 9, 9.8));

        allEdges.Add(new Edge(9, 0, 1.9));
        allEdges.Add(new Edge(9, 1, 2.9));
        allEdges.Add(new Edge(9, 2, 3.9));
        allEdges.Add(new Edge(9, 3, 4.9));
        allEdges.Add(new Edge(9, 4, 5.9));
        allEdges.Add(new Edge(9, 5, 6.9));
        allEdges.Add(new Edge(9, 6, 7.9));
        allEdges.Add(new Edge(9, 7, 8.9));
        allEdges.Add(new Edge(9, 8, 9.9));

      RunNSGAII(20, 1000);
    }
}
