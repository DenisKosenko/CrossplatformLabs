namespace LabsLibrary
{
	using Alchemy;
	using System;
	using System.Collections.Generic;

	public class Lab3Runner
	{
		public Lab3Runner(string firstLine, string secondLine, string thirdLine, string startElement, string finishElement)
		{
			_firstLine = firstLine;
			_secondLine = secondLine;
			_thirdLine = thirdLine;
			_startElement = startElement;
			_finishElement = finishElement;
		}

		private readonly string _firstLine;
		private readonly string _secondLine;
		private readonly string _thirdLine;

		private readonly string _startElement;
		private readonly string _finishElement;

		public string RunLab()
		{
			Graph _graph;
			string first = "";
			string last = "";
			_graph = new Graph();
			var inputData = new List<string>() { _firstLine, _secondLine, _thirdLine };
			LoadRecipes(_graph, first, last, inputData);
			Dijkstra d = new Dijkstra(_graph);
			int res = d.FindShortestPathLength(first, last);

			return res.ToString();
		}

		public void LoadRecipes(Graph graph, string first, string last, List<string> inputData)
		{
			{
				for (int i = 0; i < 2; i++)
				{
					Tuple<string, string> items = GetItems(inputData[i]);
					if (items != null)
					{
						graph.AddVertex(items.Item1);
						graph.AddVertex(items.Item2);
						graph.AddEdge(items.Item1, items.Item2);
					}
				}

				first = _startElement;
				last = _finishElement;
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