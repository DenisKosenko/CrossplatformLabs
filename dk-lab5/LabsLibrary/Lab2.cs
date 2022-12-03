using System.Collections.Generic;
using System.Linq;

namespace LabsLibrary
{
	public class Lab2Runner
	{
		public Lab2Runner(string firstLine, string secondLine, string thirdLine)
		{
			_firstLine = firstLine;
			_secondLine = secondLine;
			_thirdLine = thirdLine;
		}

		private readonly string _firstLine;
		private readonly string _secondLine;
		private readonly string _thirdLine;

		public string RunLab()
		{
			int m = 3;
			if (m < 1 || m > 255)
			{
				return "Out of range exception!";
			}
			else
			{
				var wordsList = new List<string>() { _firstLine, _secondLine, _thirdLine }.OrderBy(str => str.Length).ToList();
				return GetMaxLengthOfWordsChain(wordsList).ToString();
			}
		}

		public static int GetMaxLengthOfWordsChain(List<string> wordsList)
		{
			if (wordsList.Count == 1)
			{
				return wordsList.Count;
			}
			var buf = wordsList.Select(word => new { word, count = 1 }).ToDictionary(key => key.word, value => value.count);
			for (int i = 0; i < wordsList.Count; i++)
			{
				for (int j = i + 1; j < wordsList.Count; j++)
				{
					if (wordsList[j].StartsWith(wordsList[i]))
					{
						buf[wordsList[j]]++;
					}
				}
			}
			return buf.Values.Max();
		}
	}
}