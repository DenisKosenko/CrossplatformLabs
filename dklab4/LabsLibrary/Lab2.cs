namespace LabsLibrary
{
	public static class Lab2
	{
		public static string Run(string input = "INPUT.TXT")
		{
			var inputData = File.ReadLines(input);

			int m = Convert.ToInt32(inputData.First().Trim());
			if (m < 1 || m > 255)
			{
				return "Out of range exception!";
			}
			else
			{
				var wordsList = inputData.Skip(1).OrderBy(str => str.Length).ToList();
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