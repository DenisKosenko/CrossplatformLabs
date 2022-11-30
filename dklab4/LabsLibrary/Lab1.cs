namespace LabsLibrary
{
	public static class Lab1
	{
		public static string Run(string input = "INPUT.TXT")
		{
			int inputNumber = Convert.ToInt32(File.ReadLines(input).First().Trim());
			if (inputNumber >= 1 && inputNumber <= 109)
			{
				int result = 0;
				for (int i = 1; i <= inputNumber; i += 2)
				{
					if (i % 3 != 0 && i % 5 != 0)
					{
						result++;
					}
				}

				return result.ToString();
			}
			else
			{
				return "Number is out of range";
			}
		}
	}
}