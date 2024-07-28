using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCS_6114_Project_2
{
    public class ShortestPath
    {
        public static void Dijkstra(Graph graph)
        {
            var frontier = new PriorityQueue<string, int>();
            var distances = new Dictionary<string, int>();
            var previous = new Dictionary<string, string>();
            foreach (var vertex in graph.Vertices)
            {
                distances[vertex.Key] = int.MaxValue;
            }
            distances[graph.SourceNode] = 0;

            frontier.Enqueue(graph.SourceNode, 0);

            while (frontier.Count > 0)
            {
                var curr = frontier.Dequeue();
                if(!graph.Vertices.ContainsKey(curr))
                {
                    continue;
                }
                foreach (var edge in graph.Vertices[curr].Edges)
                {
                    var adjVer = edge.To;
                    int newDist = distances[curr] + edge.Weight;

                    if (newDist < distances[adjVer])
                    {
                        distances[adjVer] = newDist;
                        previous[adjVer] = curr;
                        frontier.Enqueue(adjVer, newDist);
                    }
                }
            }

            PrintDijkstra(graph.SourceNode, distances, previous);
        }

        private static void PrintDijkstra(string source, Dictionary<string, int> distances, Dictionary<string, string?> previous)
        {
            Console.WriteLine($"Shortest paths from source {source}:");
            foreach (var vertex in distances.Keys)
            {
                if (distances[vertex] == int.MaxValue)
                {
                    Console.WriteLine($"{vertex} is unreachable from {source}");
                }
                else
                {
                    Console.Write($"{vertex} (Cost: {distances[vertex]}): ");
                    PrintPath(vertex, previous);
                    Console.WriteLine();
                }
            }
        }

        private static void PrintPath(string vertex, Dictionary<string, string?> previous)
        {
            var path = new Stack<string>();
            while (vertex != null)
            {
                path.Push(vertex);
                previous.TryGetValue(vertex, out var value);
                vertex = value;
            }

            while (path.Count > 0)
            {
                Console.Write(path.Pop());
                if (path.Count > 0) Console.Write(" -> ");
            }
        }
    }
}
