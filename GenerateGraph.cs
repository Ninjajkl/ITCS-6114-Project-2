using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCS_6114_Project_2;
public class GenerateGraph
{
    private static readonly Random Random = new Random();

    public static string[] GenerateRandomGraph(int nodeCount, int edgeCount, bool isDirected)
    {
        if (nodeCount < 1 || edgeCount < 1 || edgeCount > nodeCount * (nodeCount - 1) / (isDirected ? 1 : 2))
        {
            throw new ArgumentException("Invalid number of nodes or edges");
        }

        var nodes = new List<string>();
        for (char c = 'A'; c < 'A' + nodeCount; c++)
        {
            nodes.Add(c.ToString());
        }

        var edges = new HashSet<(string, string)>();
        var edgeList = new List<(string, string, int)>();

        while (edgeList.Count < edgeCount)
        {
            var from = nodes[Random.Next(nodeCount)];
            var to = nodes[Random.Next(nodeCount)];

            if (from == to || edges.Contains((from, to)) || (!isDirected && edges.Contains((to, from))))
            {
                continue;
            }

            var weight = Random.Next(1, 100);
            edges.Add((from, to));
            edgeList.Add((from, to, weight));

            if (!isDirected)
            {
                edges.Add((to, from));
            }
        }

        var result = new List<string>
            {
                $"{nodeCount} {edgeCount} {(isDirected ? 'D' : 'U')}"
            };
        foreach (var (from, to, weight) in edgeList)
        {
            result.Add($"{from} {to} {weight}");
        }

        result.Add(nodes[0]);
        return result.ToArray();
    }
}