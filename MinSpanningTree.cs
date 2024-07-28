using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ITCS_6114_Project_2.Graph;

namespace ITCS_6114_Project_2;
public class MinSpanningTree
{
    public static void Prim(Graph graph)
    {
        var frontier = new PriorityQueue<Vertex, int>();
        var visited = new HashSet<Vertex>();
        //I just reuse the Dist variable in for key
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
            if (visited.Contains(curr))
            {
                continue;
            }
            visited.Add(curr);
            foreach (var edge in curr.Edges)
            {
                if (!visited.Contains(edge.To) && edge.Weight < edge.To.Dist)
                {
                    edge.To.Parent = curr;
                    edge.To.Dist = edge.Weight;
                    frontier.Enqueue(edge.To, edge.To.Dist);
                }
            }
        }

        PrintPrim(graph);
    }

    public static void PrintPrim(Graph graph)
    {
        int totalCost = 0;
        Console.WriteLine("Minimum Spanning Tree Edges:");
        foreach (var vertex in graph.Vertices.Values)
        {
            if (vertex.Parent != null)
            {
                Console.WriteLine($"{vertex.Parent.Name} - {vertex.Name}: {vertex.Dist}");
                totalCost += vertex.Dist;
            }
        }
        Console.WriteLine($"Total Cost: {totalCost}");
    }
}
