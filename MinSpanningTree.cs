using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCS_6114_Project_2;
public class MinSpanningTree
{
    public static void Prim(Graph graph)
    {
        var startNode = graph.Vertices.First().Key;
        var mstEdges = new List<(string, string, int)>();
        var totalCost = 0;

        var visited = new HashSet<string>();
        var priorityQueue = new PriorityQueue<(string, string, int), int>();

        visited.Add(startNode);
        foreach (var edge in graph.Vertices[startNode].Edges)
        {
            priorityQueue.Enqueue((startNode, edge.To, edge.Weight), edge.Weight);
        }

        while (priorityQueue.Count > 0 && visited.Count < graph.Vertices.Count)
        {
            var (from, to, weight) = priorityQueue.Dequeue();
            if (!visited.Contains(to))
            {
                visited.Add(to);
                mstEdges.Add((from, to, weight));
                totalCost += weight;

                foreach (var edge in graph.Vertices[to].Edges)
                {
                    if (!visited.Contains(edge.To))
                    {
                        priorityQueue.Enqueue((to, edge.To, edge.Weight), edge.Weight);
                    }
                }
            }
        }

        PrintMST(mstEdges, totalCost);
    }

    private static void PrintMST(List<(string, string, int)> edges, int totalCost)
    {
        Console.WriteLine("Minimum Spanning Tree Edges:");
        foreach (var (from, to, weight) in edges)
        {
            Console.WriteLine($"{from} - {to}: {weight}");
        }
        Console.WriteLine($"Total Cost: {totalCost}");
    }
}
