using ITCS_6114_Project_2;

string filePath = $"{Directory.GetParent(AppContext.BaseDirectory).FullName}/Inputs";

/*
 * Want to generate a new graph? Use this function within the GenerateGraph class!
 * public static string[] GenerateRandomGraph(int nodeCount, int edgeCount, bool isDirected)
 * 
 * Want to add your own inputs?
 * Just added your txt to the folder at {Directory.GetParent(AppContext.BaseDirectory).FullName}/Inputs
 * Then follow the structure of the code below to read the lines into a new Graph()
 */

/* Testing graph
Graph UDGraph1 = new(File.ReadAllLines($"{filePath}/test.txt"));

UDGraph1.PrintGraph();
ShortestPath.Dijkstra(UDGraph1);
MinSpanningTree.Prim(UDGraph1);
*/

#region Shortest Path Algorithm
Console.WriteLine($"\nShortest Paths\n\nUndirected Graph 1\n");
Graph UGraph1 = new(File.ReadAllLines($"{filePath}/U1.txt"));
UGraph1.PrintGraph();
ShortestPath.Dijkstra(UGraph1);

Console.WriteLine($"\nUndirected Graph 2\n");

Graph UGraph2 = new(File.ReadAllLines($"{filePath}/U2.txt"));
UGraph2.PrintGraph();
ShortestPath.Dijkstra(UGraph2);

Console.WriteLine($"\nDirected Graph 1\n");

Graph DGraph1 = new(File.ReadAllLines($"{filePath}/D1.txt"));
DGraph1.PrintGraph();
ShortestPath.Dijkstra(DGraph1);

Console.WriteLine($"\nDirected Graph 3\n");

Graph DGraph2 = new(File.ReadAllLines($"{filePath}/D2.txt"));
DGraph2.PrintGraph();
ShortestPath.Dijkstra(DGraph2);
#endregion Shortest Path Algorithm

#region Minimum Spanning Tree Algorithm
Console.WriteLine($"\nMinimum Spanning Trees\n\nGraph 1\n");
Graph MGraph1 = new(File.ReadAllLines($"{filePath}/CU1.txt"));
MGraph1.PrintGraph();
MinSpanningTree.Prim(MGraph1);

Console.WriteLine($"\nGraph 2\n");

Graph MGraph2 = new(File.ReadAllLines($"{filePath}/CU2.txt"));
MGraph2.PrintGraph();
MinSpanningTree.Prim(MGraph2);

Console.WriteLine($"\nGraph 3\n");

Graph MGraph3 = new(File.ReadAllLines($"{filePath}/CU3.txt"));
MGraph3.PrintGraph();
MinSpanningTree.Prim(MGraph3);

Console.WriteLine($"\nGraph 4\n");

Graph MGraph4 = new(File.ReadAllLines($"{filePath}/CU4.txt"));
MGraph4.PrintGraph();
MinSpanningTree.Prim(MGraph4);
#endregion Minimum Spanning Tree Algorithm

Console.WriteLine("Press Enter to exit...");
Console.ReadLine();