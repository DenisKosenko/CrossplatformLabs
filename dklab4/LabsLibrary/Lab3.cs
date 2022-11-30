namespace LabsLibrary
{
	using Alchemy;

	public static class Lab3
	{
		public static string Run(string input = "INPUT.TXT")
		{
			Graph _graph;
			string first = "";
			string last = "";
			_graph = new Graph();
			LoadRecipes(input, _graph, first, last);
			Dijkstra d = new Dijkstra(_graph);
			int res = d.FindShortestPathLength(first, last);

			return res.ToString();
		}

		public static void LoadRecipes(string input, Graph graph, string first, string last)
		{
			using (var reader = new StreamReader(input))
			{
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
								graph.AddVertex(items.Item1);
								graph.AddVertex(items.Item2);
								graph.AddEdge(items.Item1, items.Item2);
							}
						}

						first = reader.ReadLine();
						last = reader.ReadLine();
					}
				}
			}
		}

		private static Tuple<string, string> GetItems(string readLine)
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
	}
}