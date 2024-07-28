using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCS_6114_Project_2;

public class Graph
{
    public int VerticesCount { get; private set; }
    public int EdgesCount { get; private set; }
    public bool IsDirected { get; private set; }
    public Dictionary<string, Vertex> Vertices { get; private set; }
    public Vertex SourceNode { get; private set; }

    public Graph(string[] lines)
    {
        Vertices = [];

        string[] firstLine = lines[0].Split(' ');
        VerticesCount = int.Parse(firstLine[0]);
        EdgesCount = int.Parse(firstLine[1]);
        IsDirected = firstLine[2] == "D";

        for (int i = 1; i <= EdgesCount; i++)
        {
            string[] edgeParts = lines[i].Split(' ');
            string from = edgeParts[0];
            string to = edgeParts[1];
            int weight = int.Parse(edgeParts[2]);

            AddEdge(from, to, weight);
        }

        SourceNode = Vertices[lines[EdgesCount + 1]];
    }
    public void AddEdge(string from, string to, int weight)
    {
        if (!Vertices.TryGetValue(from, out Vertex? fromV))
        {
            fromV = new Vertex(from);
            Vertices[from] = fromV;
        }

        if (!Vertices.TryGetValue(to, out Vertex? toV))
        {
            toV = new Vertex(to);
            Vertices[to] = toV;
        }

        fromV.Edges.Add(new Edge(toV, weight));

        if (!IsDirected)
        {
            toV.Edges.Add(new Edge(fromV, weight));
        }
    }

    public class Vertex
    {
        public string Name { get; private set; }
        public List<Edge> Edges { get; private set; }
        public int Dist { get; set; }
        public Vertex Parent { get; set; }

        public Vertex(string name)
        {
            Name = name;
            Edges = new List<Edge>();
            Dist = int.MaxValue;
            Parent = null;
        }
    }

    public class Edge
    {
        public Vertex To { get; private set; }
        public int Weight { get; private set; }

        public Edge(Vertex to, int weight)
        {
            To = to;
            Weight = weight;
        }
    }

    public void PrintGraph()
    {
        Console.WriteLine($"Graph has {VerticesCount} vertices and {EdgesCount} edges.");
        Console.WriteLine(IsDirected ? "The graph is directed." : "The graph is undirected.");
        Console.WriteLine($"The source node is: {SourceNode.Name}");

        foreach (var vertex in Vertices.Values)
        {
            Console.Write($"{vertex.Name}: ");
            foreach (var edge in vertex.Edges)
            {
                Console.Write($"({edge.To.Name}, {edge.Weight}) ");
            }
            Console.WriteLine();
        }
    }
}