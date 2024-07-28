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
            var frontier = new PriorityQueue<Graph.Vertex, int>();
            foreach (var vertex in graph.Vertices.Values)
            {
                vertex.Dist = int.MaxValue;
                vertex.Parent = null;
            }
            graph.SourceNode.Dist = 0;

            frontier.Enqueue(graph.SourceNode, 0);

            while (frontier.Count > 0)
            {
                var curr = frontier.Dequeue();
                foreach (var edge in curr.Edges)
                {
                    var adjVer = edge.To;
                    int newDist = curr.Dist + edge.Weight;

                    if (newDist < adjVer.Dist)
                    {
                        adjVer.Dist = newDist;
                        adjVer.Parent = curr;
                        frontier.Enqueue(adjVer, newDist);
                    }
                }
            }

            PrintDijkstra(graph);
        }

        public static void PrintDijkstra(Graph graph)
        {
            Console.WriteLine("Shortest paths from the source node:");
            foreach (var vertex in graph.Vertices.Values)
            {
                if (vertex.Dist == int.MaxValue)
                {
                    Console.WriteLine($"{vertex.Name} is unreachable from {graph.SourceNode.Name}");
                }
                else
                {
                    Console.Write($"{vertex.Name}: {vertex.Dist} via ");
                    PrintPath(vertex);
                    Console.WriteLine();
                }
            }
        }

        private static void PrintPath(Graph.Vertex vertex)
        {
            if (vertex.Parent == null)
            {
                Console.Write(vertex.Name);
                return;
            }
            PrintPath(vertex.Parent);
            Console.Write($" -> {vertex.Name}");
        }
    }
}
