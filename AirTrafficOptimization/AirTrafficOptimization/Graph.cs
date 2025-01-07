using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficOptimization
{
    class Edge
    {
        public int From;
        public int To;
        public double Weight;

        public Edge(int from, int to, double weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }

    class Graph
    {
        public static List<List<int>> FindSCCs(int n, List<Edge> edges)
        {
            var adj = new List<int>[n];
            var transpose = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adj[i] = new List<int>();
                transpose[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                adj[edge.From].Add(edge.To);
                transpose[edge.To].Add(edge.From);
            }

            var visited = new bool[n];
            var stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                    DFS(i, adj, visited, stack);
            }

            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
            var sccs = new List<List<int>>();
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                if (!visited[node])
                {
                    var component = new List<int>();
                    ReverseDFS(node, transpose, visited, component);
                    sccs.Add(component);
                }
            }

            return sccs;
        }

        public static void DFS(int node, List<int>[] adj, bool[] visited, Stack<int> stack)
        {
            visited[node] = true;
            foreach (var neighbor in adj[node])
            {
                if (!visited[neighbor])
                    DFS(neighbor, adj, visited, stack);
            }
            stack.Push(node);
        }

        public static void ReverseDFS(int node, List<int>[] transpose, bool[] visited, List<int> component)
        {
            visited[node] = true;
            component.Add(node);
            foreach (var neighbor in transpose[node])
            {
                if (!visited[neighbor])
                    ReverseDFS(neighbor, transpose, visited, component);
            }
        }
        public static double[] GetShortestPath(List<Edge> edges, int start, int numberOfNodes)
        {
            var distances = Enumerable.Repeat(double.MaxValue, numberOfNodes).ToArray();
            distances[start] = 0;

            var priorityQueue = new SortedSet<(double, int)>();
            priorityQueue.Add((0, start));

            while (priorityQueue.Count > 0)
            {
                var (currentDistance, currentNode) = priorityQueue.First();
                priorityQueue.Remove(priorityQueue.First());

                foreach (var edge in edges.Where(e => e.From == currentNode))
                {
                    int neighbor = edge.To;
                    double newDistance = currentDistance + edge.Weight;

                    if (newDistance < distances[neighbor])
                    {
                        priorityQueue.Remove((distances[neighbor], neighbor));
                        distances[neighbor] = newDistance;
                        priorityQueue.Add((newDistance, neighbor));
                    }
                }
            }

            return distances;
        }
    }
}
