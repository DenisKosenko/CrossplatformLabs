using Alchemy.Dijkstra;

const string inputFile = "input.txt";
const string outputFile = "output.txt";
Graph _graph;
string first = "";
string last = "";

_graph = new Graph();
LoadRecipes();
Dijkstra d = new Dijkstra(_graph);
int res = d.FindShortestPathLength(first, last);
WriteResult(res);

void WriteResult(int res)
{
    using (var writer = new StreamWriter(outputFile, false))
    {
        writer.Write(res);
    }
}

void LoadRecipes()
{
    using ( var reader = new StreamReader(inputFile))
    {
        // первая строка - размер
        string? sizeList = reader.ReadLine();
        if (sizeList != null)
        {
            if (byte.TryParse(sizeList, out byte size))
            {
                for (int i = 0; i < size; i++)
                {
                    Tuple<string, string> items = GetItems(reader.ReadLine());
                    if (items != null)
                    {
                        _graph.AddVertex(items.Item1);
                        _graph.AddVertex(items.Item2);
                        _graph.AddEdge(items.Item1, items.Item2);
                    }
                }
                first = reader.ReadLine();
                last = reader.ReadLine();
            }
        }
    }
}

Tuple<string, string> GetItems(string readLine)
{
    int pos = readLine.IndexOf("->");
    if (pos > 0)
    {
        string first = readLine.Substring(0, pos).Trim();
        string second = readLine.Substring(pos + 2).Trim();
        return new Tuple<string, string>(first, second);
    }
    return null;
}